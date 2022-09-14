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

        private static Dictionary<string, string> _data;
        public static string UserDataDirectoryPath
        {
            get { return Path.Combine(Application.LocalUserAppDataPath, USER_DATA_DIRECTORY_NAME); }
        }

        public static string UserDataFilePath
        {
            get { return Path.Combine(Application.LocalUserAppDataPath, UserDataDirectoryPath, USER_DATA_FILE_NAME); }
        }

        public static Dictionary<string, string> Data
        {
            get
            {
                if (_data == null)
                    UpdateUserData();
                return _data;       
            }
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

        
        public static void SaveUserDataInFile(Dictionary<string, string> userData)
        {
            if (!DataFileExsist())
                return;

            string content = JsonConvert.SerializeObject(userData);

            File.WriteAllText(UserDataFilePath, content);
        }

        public static void UpdateUserData()
        {
            if (!DataFileExsist())
                return;

            string userDataString = File.ReadAllText(UserDataFilePath);

            _data = JsonConvert.DeserializeObject<Dictionary<string, string>>(userDataString);
        }
    }
}
