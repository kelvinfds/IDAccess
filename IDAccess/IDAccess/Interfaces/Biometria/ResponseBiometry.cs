namespace IDAccess.Interfaces.Biometria
{
    public class ResponseBiometry
    {
        public long id;
        public string template;
        public long user_id;

        public ResponseBiometry(long id, string template, long user_id)
        {
            this.id = id;
            this.template = template;
            this.user_id = user_id;
        }
    }
}
