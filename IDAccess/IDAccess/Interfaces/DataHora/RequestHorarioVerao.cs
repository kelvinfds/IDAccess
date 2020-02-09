using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace IDAccess.Interfaces.DataHora
{
    public class RequestHorarioVerao
    {
        [DataMember(EmitDefaultValue = false)]
        public start_date_time start_date_time;
        [DataMember(EmitDefaultValue = false)]
        public end_date_time end_date_time;

        public RequestHorarioVerao() { }
    }

    [DataContract]
    public class start_date_time
    {
        [DataMember(EmitDefaultValue = false)]
        public int year;
        [DataMember(EmitDefaultValue = false)]
        public int month;
        [DataMember(EmitDefaultValue = false)]
        public int day;
    }
    [DataContract]
    public class end_date_time
    {
        [DataMember(EmitDefaultValue = false)]
        public int year;
        [DataMember(EmitDefaultValue = false)]
        public int month;
        [DataMember(EmitDefaultValue = false)]
        public int day;
    }
}
