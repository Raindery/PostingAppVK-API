using DataPresentation;
using DataPresentation.Common;
using DataPresentation.Data;
using VKApiService;
using VKApiService.Base;
using UserDataService;
using LightInject;


namespace Views
{
    internal static class Program
    {
        static async Task Main()
        {
            ApplicationConfiguration.Initialize();

            var vkApiConfig = new VkApiConfig(
                vkApiUrl: "https://api.vk.com/method/",
                appId: "APP_ID_VALUE",
                appSecret: "APP_SECRET_VALUE",
                apiVersion: "5.131"
            );

            var vkApiService = new VkApiService(vkApiConfig);
            var userDataService = new UserDataService.UserDataService(Application.LocalUserAppDataPath);

            if (!userDataService.DataFileExsist())
                userDataService.CreateDataFile();
            userDataService.UpdateUserData();

            var userData = new UserData();
            string? token = userDataService.GetUserDataField(UserDataNames.VK_API_TOKEN);
            if (token != null && token != string.Empty)
            {
                vkApiService.SetNewToken(token);
                bool isTokenExpired = await vkApiService.TokenExpired();

                if (!isTokenExpired)
                {
                    VkApiResponse userInfoData = await vkApiService.GetProfileInfo();
                    if (userInfoData == null || userInfoData.ResponseData == null)
                        throw new ArgumentNullException(nameof(userInfoData), "Failed to get profile info");

                    string? firstName = userInfoData.ResponseData["first_name"].ToString();
                    string? lastName = userInfoData.ResponseData["last_name"].ToString();

                    if (firstName != null && lastName != null)
                        userData.SetUserData(firstName, lastName);
                    else
                        userData.SetUserData(" ", " ");
                }
            }


            Thread setupThread = new Thread(() =>
            {
                var authorizationView = new AuthorizationView(vkApiService.GetAuthorizationUrl());

                var controller = new ApplicationController(new ServiceContainer())
                .RegisterView<IMainView, MainView>()
                .RegisterView<ISendPostProcessView, SendPostProcessView>()
                .RegisterInstance<IAuthorizationView>(authorizationView)
                .RegisterInstance<IVkApiService>(vkApiService)
                .RegisterInstance<IUserDataService>(userDataService);

                controller.Run<MainViewPresenter, UserData>(userData);
            });
            setupThread.SetApartmentState(ApartmentState.STA);
            setupThread.Start();
            setupThread.Join();
        }
    }
}