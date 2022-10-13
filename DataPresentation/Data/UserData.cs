namespace DataPresentation.Data
{
    public class UserData
    { 
        public string? Firstname { get; private set; }
        public string? Lastname { get; private set; }


        public UserData()
        {

        }

        public void SetUserData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}
