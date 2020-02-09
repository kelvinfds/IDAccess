using System.Runtime.Serialization;

namespace IDAccess.Interfaces.Status
{
    public class infoStatus
    {
        [DataMember(EmitDefaultValue = false)]
        public uptimes uptime;
        [DataMember(EmitDefaultValue = false)]
        public int time;
        [DataMember(EmitDefaultValue = false)]
        public networks network;
        [DataMember(EmitDefaultValue = false)]
        public string serial;
        [DataMember(EmitDefaultValue = false)]
        public string version;
    }
    [DataContract]
    public class uptimes
    {
        [DataMember(EmitDefaultValue = false)]
        public int days;
        [DataMember(EmitDefaultValue = false)]
        public int hours;
        [DataMember(EmitDefaultValue = false)]
        public int minutes;
        [DataMember(EmitDefaultValue = false)]
        public int seconds;
    }

    [DataContract]
    public class networks
    {
        [DataMember(EmitDefaultValue = false)]
        public string mac;
        [DataMember(EmitDefaultValue = false)]
        public string ip;
        [DataMember(EmitDefaultValue = false)]
        public string netmask;
        [DataMember(EmitDefaultValue = false)]
        public string gateway;
    }
}
