namespace IDAccess.Interfaces.Users
{
    public class ResponseUsers
    {
        public long id;
        public string name;
        public string registration;
        public string password;
        public string salt;

        public ResponseUsers(long id, string name, string registration, string password, string salt)
        {
            this.id = id;
            this.name = name;
            this.registration = registration;
            this.password = password;
            this.salt = salt;
        }

        public ResponseUsers()
        {
        }
    }
}
