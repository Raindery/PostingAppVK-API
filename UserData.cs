using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PostingAppVK_API
{
    internal static class UserData
    {
        private const string USER_DATA_DIRECTORY_NAME = "UserData";
        private const string USER_DATA_FILE_NAME = "UserData.json";

        private static Dictionary<string, string> _userData = new Dictionary<string, string>();
        public static string UserDataDirectoryPath
        {
            get { return Path.Combine(Application.LocalUserAppDataPath, USER_DATA_DIRECTORY_NAME); }
        }

        public static string UserDataFilePath
        {
            get { return Path.Combine(Application.LocalUserAppDataPath, UserDataDirectoryPath, USER_DATA_FILE_NAME); }
        }


        public static bool DataFileExsist()
        {
            return File.Exists(UserDataFilePath);
        }

        public static void CreateDataFileIfNotExsist()
        {
            if (!Directory.Exists(UserDataDirectoryPath))
                Directory.CreateDirectory(UserDataDirectoryPath);

            if(!DataFileExsist())
                File.Create(UserDataFilePath).Close();
        }

        public static Dictionary<string, string> GetUserData()
        {
            return _userData;
        }

        public static string GetUserDataFieldValue(string name)
        {
            string value;
            if (_userData.TryGetValue(name, out value))
                return value;

            return string.Empty;
        }

        public static void AddUserDataField(string name, string value)
        {
            string currentValue;
            if(_userData.TryGetValue(name, out currentValue))
            {
                if (currentValue.Equals(value))
                    return;
            }

            _userData[name] = value;
        }
        
        public static void SaveUserData()
        {
            if (!DataFileExsist())
                return;

            string content = JsonConvert.SerializeObject(_userData);

            File.WriteAllText(UserDataFilePath, content);
        }

        public static void UpdateUserData()
        {
            if (!DataFileExsist())
                return;

            string userDataString = File.ReadAllText(UserDataFilePath);

            _userData = JsonConvert.DeserializeObject<Dictionary<string, string>>(userDataString);
            if (_userData == null)
                _userData = new Dictionary<string, string>();
        }
    }
}
