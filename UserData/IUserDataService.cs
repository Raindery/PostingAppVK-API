namespace UserDataService
{
    public interface IUserDataService
    {
        public Dictionary<string, string> UserData { get; }
        public string UserDataDirectoryPath { get; }
        public string UserDataFilePath { get; }

        public bool DataFileExsist();
        public void CreateDataFile();
        public string? GetUserDataField(string fieldName);
        public void AddUserDataString(string fieldName, string fieldValue);
        public void SaveUserData();
        public void UpdateUserData();
    }
}
