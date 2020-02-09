using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace IDAccess.Interfaces.Cartão
{
    public class RequestCard
    {
        public IList<Cards> cards {get; set;}
    }

    public class Cards
    {
        [DataMember(EmitDefaultValue = false)]
        public long id;
        [DataMember(EmitDefaultValue = false)]
        public UInt64 value;
        [DataMember(EmitDefaultValue = false)]
        public long user_id;
    }
}
