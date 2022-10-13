using Newtonsoft.Json;

namespace UserDataService
{
    public class UserDataService : IUserDataService
    {
        public const string USER_DATA_DIRECTORY_NAME = "UserData";
        public const string USER_DATA_FILE_NAME = "UserData.json";

        private readonly Dictionary<string, string> _userData;
        private readonly string _userDataDirectoryPath;
        private readonly string _userDataFilePath;


        public Dictionary<string, string> UserData { get => _userData; }
        public string UserDataDirectoryPath
        {
            get
            {
                if (_userDataDirectoryPath != null)
                    return _userDataDirectoryPath;
                throw new ArgumentNullException(nameof(_userDataDirectoryPath));
            }
        }
        public string UserDataFilePath
        {
            get
            {
                if (_userDataFilePath != null)
                    return _userDataFilePath;
                throw new ArgumentNullException(nameof(_userDataFilePath));
            }
        }


        public UserDataService(string userDataPath)
        {
            _userDataDirectoryPath = Path.Combine(userDataPath, USER_DATA_DIRECTORY_NAME);
            _userDataFilePath = Path.Combine(UserDataDirectoryPath, USER_DATA_FILE_NAME);

            _userData = new Dictionary<string, string>();
        }

        public bool DataFileExsist()
        {
            return File.Exists(UserDataFilePath);
        }

        public void CreateDataFile()
        {
            if (!Directory.Exists(UserDataDirectoryPath))
            {
                try
                {
                    Directory.CreateDirectory(UserDataDirectoryPath);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            FileStream? fileStream = null;
            try
            {
                fileStream = File.Create(UserDataFilePath);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                if(fileStream != null)
                    fileStream.Close();
            }
        }

        public string? GetUserDataField(string fieldName)
        {
            if (_userData.TryGetValue(fieldName, out string? value) && value != string.Empty)
                return value;
            return null;
        }

        public void AddUserDataString(string fieldName, string fieldValue)
        {
            if (fieldName == null)
                throw new ArgumentNullException(nameof(fieldName));

            if (_userData.TryGetValue(fieldName, out string? currentValue) && currentValue.Equals(fieldValue))
                return;

            _userData[fieldName] = fieldValue;
        }

        public void SaveUserData()
        {
            if (!DataFileExsist())
                CreateDataFile();

            string data = JsonConvert.SerializeObject(_userData);

            if (data == null)
                return;
            
            try
            {
                File.WriteAllText(UserDataFilePath, data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateUserData()
        {
            string userDataString;
            try
            {
               userDataString = File.ReadAllText(UserDataFilePath);
            }
            catch (Exception)
            {
                throw;
            }
                
            _userData.Clear();
            var newUserData = JsonConvert.DeserializeObject<Dictionary<string, string>>(userDataString);

            if (newUserData == null)
                return;

            foreach (var n in newUserData)
            {
                _userData.Add(n.Key, n.Value);
            }
        }
    }
}
