namespace VKApiService.Base
{
    public interface IVkApiService
    {
        public string? Token { get; }
        public VkApiConfig Config { get; }

        public Task<VkApiResponse> GetTokenData();
        public Task<bool> TokenExpired();
        public Task<VkApiResponse<ulong>> GetUnixTimestamp();
        public Task<VkApiResponse> GetObjectInfo(string screenName);
        public Task<VkApiResponse> GetProfileInfo();
        public Task<VkApiResponse> SendPostToGroup(long id, string postContent);
        public string GetAuthorizationUrl();
        public void SetNewToken(string token);
    }
}
