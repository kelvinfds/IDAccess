using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAccess.Interfaces.Cartão
{
    public class ResponseCard
    {
        public long id;
        public UInt64 value;
        public long user_id;

        public ResponseCard(long id, UInt64 value, long user_id)
        {
            this.id = id;
            this.value = value;
            this.user_id = user_id;
        }
    }
}
