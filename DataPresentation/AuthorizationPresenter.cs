using DataPresentation.Common;
using VKApiService.Base;
using VKApiService;
using UserDataService;
using DataPresentation.Data;

namespace DataPresentation
{
    public class AuthorizationPresenter : BasePresenter<IAuthorizationView, UserData>
    {
        private UserData? _userData;
        private readonly IVkApiService _vkApiService;
        private readonly IUserDataService _userDataService;


        public AuthorizationPresenter(IApplicationController applicationController, IAuthorizationView view, IVkApiService vkApiService, IUserDataService userDataService) : base(applicationController, view)
        {
            _vkApiService = vkApiService;
            _userDataService = userDataService;
            View.OnChangePage += GetAndSetToken;
        }

        public override void Run(UserData userData)
        {
            _userData = userData;
            View.Show();
        }


        private async void GetAndSetToken()
        {
            string currentPageUrl = View.CurrentPageUrl;

            if (currentPageUrl.Contains("error"))
            {
                View.Close();
                return;
            }
                

            if (!currentPageUrl.Contains("access_token"))
                return;

            string dataString = currentPageUrl.Substring(currentPageUrl.IndexOf('#') + 1);
            string[] parametersAndValues = dataString.Split('=', '&');

            var tokenData = new Dictionary<string, string>();

            for(int i = 0; i < parametersAndValues.Length-1; i+=2)
            {
                tokenData.Add(parametersAndValues[i], parametersAndValues[i + 1]);
            }

            _vkApiService.SetNewToken(tokenData["access_token"]);

            if (_vkApiService.Token == null || _vkApiService.Token == string.Empty)
                throw new ArgumentNullException(nameof(_vkApiService.Token), "Token is not set!");

            _userDataService.AddUserDataString(UserDataNames.VK_API_TOKEN, _vkApiService.Token);
            _userDataService.SaveUserData();

            VkApiResponse profileInfoData = await _vkApiService.GetProfileInfo();
            if (profileInfoData.ResponseData != null)
            {
                if (_userData == null)
                    throw new ArgumentNullException(nameof(_userData), "User data is null!");

                string? firstName = profileInfoData.ResponseData["first_name"].ToString();
                string? lastName = profileInfoData.ResponseData["last_name"].ToString();

                if (firstName == null || lastName == null)
                    throw new Exception("Failed to get first or last name");

                _userData.SetUserData(firstName, lastName);
            }

            View.Close();
        }
    }
}
