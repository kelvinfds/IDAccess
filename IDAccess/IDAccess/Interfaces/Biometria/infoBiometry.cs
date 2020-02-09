using System.Collections.Generic;
using System.Runtime.Serialization;

namespace IDAccess.Interfaces.Biometria
{

    public class infoBiometry
    {
        public List<templates> templates { get; set; }
    }

    public class templates
    {
        [DataMember(EmitDefaultValue = false)]
        public long id;
        [DataMember(EmitDefaultValue = false)]
        public int finger_position;
        [DataMember(EmitDefaultValue = false)]
        public int finger_type;
        [DataMember(EmitDefaultValue = false)]
        public string template;
        [DataMember(EmitDefaultValue = false)]
        public long user_id;
    }

    //public class infoBiometry
    //{
    //    [DataMember(EmitDefaultValue = false)]
    //    public templates template;
    //}
    //[DataContract]
    //public class templates
    //{
    //    [DataMember(EmitDefaultValue = false)]
    //    public long id;
    //    [DataMember(EmitDefaultValue = false)]
    //    public int finger_position;
    //    [DataMember(EmitDefaultValue = false)]
    //    public int finger_type;
    //    [DataMember(EmitDefaultValue = false)]
    //    public string template;
    //    [DataMember(EmitDefaultValue = false)]
    //    public long user_id;
    //}

    //    public class infoBiometry
    //    {
    //        //public long id;
    //        //public int finger_position;
    //        //public int finger_type;
    //        //public string template;
    //        //public long user_id;


    //        [DataMember(EmitDefaultValue = false)]
    //        public long id;
    //        [DataMember(EmitDefaultValue = false)]
    //        public int finger_position;
    //        [DataMember(EmitDefaultValue = false)]
    //        public int finger_type;
    //        [DataMember(EmitDefaultValue = false)]
    //        public byte[] template;
    //        [DataMember(EmitDefaultValue = false)]
    //        public long user_id;
    //    }

}