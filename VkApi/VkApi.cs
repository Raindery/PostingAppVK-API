using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace PostingAppVK_API
{
    internal static class VkApi
    {
        private const string VK_API_URL = "https://api.vk.com/method/";
        private const string APP_ID = "";
        private const string APP_SECRET = "";
        private const string API_VERSION = "5.131";

        private static string _token;

        public static void SetToken(string token)
        {
            _token = token;
        }

        public static async Task<VkApiResponse<Dictionary<string, string>>> SendPostToGroup(int id, string postContent)
        {
            string requestString = $"{VK_API_URL}wall.post?access_token={_token}&owner_id={id}&message={postContent}&signed=1&v={API_VERSION}";

            var response = await SendVkApiRequest<Dictionary<string, string>>(requestString);


            return response;
        }

        public static async Task<VkApiResponse<Dictionary<string, string>>> SendPostToGroupWithCaptcha(int id, string postContent, string captchaSid, string captchaText)
        {
            string requestString = $"{VK_API_URL}wall.post?access_token={_token}&owner_id={id}&message={postContent}&signed=1&captcha_sid={captchaSid}&captcha_key={captchaText}&v={API_VERSION}";

            var response = await SendVkApiRequest<Dictionary<string, string>>(requestString);

            return response;
        }

        public static async Task<bool> IsTokenExpired()
        {
            if (_token == null)
                return true;

            string requestString = $"{VK_API_URL}secure.checkToken?access_token={APP_SECRET}&token={_token}&v={API_VERSION}";

            var response = await SendVkApiRequest<Dictionary<string, string>>(requestString);

            ulong expire = ulong.Parse(response.ResponseData["expire"]);
            ulong currentTime = await GetUnixTimestamp();

            return currentTime >= expire;
        }

        public static async Task<ulong> GetUnixTimestamp()
        {
            string requestString = $"{VK_API_URL}utils.getServerTime?access_token={_token}&v={API_VERSION}";

            var response = await SendVkApiRequest<ulong>(requestString);

            return response.ResponseData;
        }

        public static async Task<VkApiResponse<Dictionary<string, string>>> GetId(string screenName)
        {
            string requestString = $"{VK_API_URL}utils.resolveScreenName?access_token={_token}&screen_name={screenName}&v={API_VERSION}";

            var response = await SendVkApiRequest<Dictionary<string, string>>(requestString);

            return response;
        }

        public static async Task<VkApiResponse<Dictionary<string, object>>> GetProfileInfo()
        {
            string requestString = $"{VK_API_URL}account.getProfileInfo?access_token={_token}&v={API_VERSION}";
            var response = await SendVkApiRequest<Dictionary<string, object>>(requestString);
            return response;
        }

        public static string GetAuthorezationUrl()
        {
            return $"https://oauth.vk.com/authorize?client_id={APP_ID}&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope=wall,account&revoke=1&response_type=token&v={API_VERSION}";
        }

        private async static Task<VkApiResponse<T>> SendVkApiRequest<T>(string requestString)
        {
            string content;

            HttpWebRequest request = HttpWebRequest.CreateHttp(requestString);
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();

            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    content = reader.ReadToEnd();
                }
            }

            response.Close();

            if(content != string.Empty)
                return JsonConvert.DeserializeObject<VkApiResponse<T>>(content);

            return null;
        }
    }

    public class VkApiResponse<T>
    {
        
        [JsonProperty("response")]
        public T ResponseData
        {
            get; protected set;
        }

        [JsonProperty("error")]
        public Dictionary<string, object> ErrorData
        {
            get; protected set;
        }
    }
}
