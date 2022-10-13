using VKApiService.Base;
using Newtonsoft.Json;

namespace VKApiService
{
    public class VkApiService : IVkApiService
    {
        private string? _token;
        private readonly VkApiConfig _config;

        public string? Token { get => _token; }
        public VkApiConfig Config { get => _config; }


        public VkApiService(VkApiConfig config)
        {
            _config = config;
        }

        public string GetAuthorizationUrl()
        {
            return $"https://oauth.vk.com/authorize?client_id={Config.AppId}&display=page&redirect_uri=https://oauth.vk.com/blank.html&scope=wall,account&revoke=1&response_type=token&v={Config.ApiVersion}";
        }

        public void SetNewToken(string token)
        {
            _token = token;
        }

        public async Task<VkApiResponse> SendPostToGroup(long id, string postContent)
        {
            if(_token == null)
                throw new ArgumentNullException(nameof(_token), "Token is not set!");
                
            string requestString =
                $"{_config.VkApiUrl}wall.post?access_token={_token}&owner_id={id}&message={postContent}&signed=1&v={_config.ApiVersion}";

            VkApiResponse dataResponse = await SendRequestAndGetResponse(requestString);
            return dataResponse;
        }

        public async Task<VkApiResponse> GetObjectInfo(string screenName)
        {
            if (_token == null)
                throw new ArgumentNullException(nameof(_token), "Token is not set!");

            string requestString = 
                $"{_config.VkApiUrl}utils.resolveScreenName?access_token={_token}&screen_name={screenName}&v={_config.ApiVersion}";

            VkApiResponse responseData = await SendRequestAndGetResponse(requestString);
            return responseData;
        }

        public async Task<VkApiResponse> GetProfileInfo()
        {
            if (_token == null)
                throw new ArgumentNullException(nameof(_token), "Token is not set!");

            string requestString = 
                $"{_config.VkApiUrl}account.getProfileInfo?access_token={_token}&v={_config.ApiVersion}";

            VkApiResponse responseData = await SendRequestAndGetResponse(requestString);
            return responseData;
        }

        public async Task<VkApiResponse<ulong>> GetUnixTimestamp()
        {
            if (_token == null)
                throw new ArgumentNullException(nameof(_token), "Token is not set!");

            string requestString = 
                $"{_config.VkApiUrl}utils.getServerTime?access_token={_token}&v={_config.ApiVersion}";

            VkApiResponse<ulong> responseData = await SendRequestAndGetResponse<ulong>(requestString);
            return responseData;
        }

        public async Task<VkApiResponse> GetTokenData()
        {
            if (_token == null)
                throw new ArgumentNullException(nameof(_token), "Token is not set!");

            string requestString = 
                $"{_config.VkApiUrl}secure.checkToken?access_token={_config.AppSecret}&token={_token}&v={_config.ApiVersion}";

            VkApiResponse dataResponse  = await SendRequestAndGetResponse(requestString);
            return dataResponse;
        }

        public async Task<bool> TokenExpired()
        {
            VkApiResponse tokenDataResponse = await GetTokenData();
            VkApiResponse<ulong> unixTimestamp = await GetUnixTimestamp();

            ulong tokenExpiredTimestamp = 0;
            if (tokenDataResponse.ResponseData != null)
            {
                tokenExpiredTimestamp = (ulong)(long)tokenDataResponse.ResponseData["expire"];
            }
            else if (tokenDataResponse.ErrorData != null)
            {
                int errorCode = (int)(long)tokenDataResponse.ErrorData["error_code"];
                if (errorCode == 15)
                    return true;
                else
                    throw new Exception("Failed get token expired data!");
            }
                
            return unixTimestamp.ResponseData >= tokenExpiredTimestamp;
        }


        private async Task<VkApiResponse> SendRequestAndGetResponse(string requestString) 
        {
            VkApiResponse<Dictionary<string, object>> responseData = 
                await SendRequestAndGetResponse<Dictionary<string, object>>(requestString);

            return new VkApiResponse(responseData);
        }

        private async Task<VkApiResponse<T>> SendRequestAndGetResponse<T>(string requestString)
        {
            var client = new HttpClient();
            var message = new HttpRequestMessage(HttpMethod.Get, new Uri(requestString));

            VkApiResponse<T>? responseData;
            try
            {
                HttpResponseMessage response = await client.SendAsync(message);
                string responseDataJson = await response.Content.ReadAsStringAsync();
                responseData = JsonConvert.DeserializeObject<VkApiResponse<T>>(responseDataJson);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                client.Dispose();
            }

            if (responseData == null)
                throw new ArgumentNullException(nameof(responseData), "Response data is null!");

            return responseData;
        }
    }
}
