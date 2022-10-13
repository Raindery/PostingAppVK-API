namespace VKApiService
{
    public class VkApiConfig
    {
        public string VkApiUrl { get; private set; }
        public string AppId { get; private set; }
        public string AppSecret { get; private set; }
        public string ApiVersion { get; private set; }

        public VkApiConfig(
            string vkApiUrl, 
            string appId, 
            string appSecret, 
            string apiVersion
        )
        {
            VkApiUrl = vkApiUrl;
            AppId = appId;
            AppSecret = appSecret;
            ApiVersion = apiVersion;
        }

    }
}
