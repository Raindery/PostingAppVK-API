using NUnit.Framework;
using VKApiService;
using VKApiService.Base;

namespace Tests
{

    [TestFixture]
    public class VkApiServiceTests
    {
        private readonly string _token =
            "tokenValue";
        private readonly VkApiConfig _config = new VkApiConfig(
            vkApiUrl: "https://api.vk.com/method/",
            appId: "",
            appSecret: "",
            apiVersion: "5.131"
            );

        private readonly string groupScreenName = "owlskingdom";
        private readonly long groupId = -91172451;


        private IVkApiService _vkApiService;
        [OneTimeSetUp]
        public void SetUpOnce()
        {
            _vkApiService = new VkApiService(_config);
            _vkApiService.SetNewToken(_token);
        }

        [Test]
        public async Task GetTokenDataTest()
        {
            VkApiResponse tokenData = await _vkApiService.GetTokenData();

            Assert.NotNull(tokenData);
            Assert.NotNull(tokenData.ResponseData, "API request success");
            Assert.Null(tokenData.ErrorData, "API request error");
        }

        [Test]
        public async Task GetObjectInfo()
        {
            
            VkApiResponse objectInfoData = await _vkApiService.GetObjectInfo(groupScreenName);

            Assert.NotNull(objectInfoData);
            Assert.NotNull(objectInfoData.ResponseData, "API request success");
            Assert.Null(objectInfoData.ErrorData, "API request error");
        }

        [Test]
        public async Task SendPostToGroupTest()
        {
            VkApiResponse sendPostData = await _vkApiService.SendPostToGroup(groupId, "Привет!");

            Assert.NotNull(sendPostData);
            Assert.NotNull(sendPostData.ResponseData, "API request success");
            Assert.Null(sendPostData.ErrorData, "API request error");
        }

        [Test]
        public async Task GetTimestampTest()
        {
            VkApiResponse<ulong> timestamp = await _vkApiService.GetUnixTimestamp();

            Assert.NotNull(timestamp);
            Assert.NotNull(timestamp.ResponseData, "API request success");
            Assert.Null(timestamp.ErrorData, "API request error");
        }

        [Test]
        public async Task GetPorfileInfoTest()
        {
            VkApiResponse profileInfoData = await _vkApiService.GetProfileInfo();

            Assert.NotNull(profileInfoData);
            Assert.NotNull(profileInfoData.ResponseData, "API request success");
            Assert.Null(profileInfoData.ErrorData, "API request error");
        }
    }
}
