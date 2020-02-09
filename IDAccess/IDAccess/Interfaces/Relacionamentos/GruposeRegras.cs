using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAccess.Interfaces.Relacionamentos
{
    class GruposeRegras
    {
        public long group_id;
        public long access_rule_id;

        public GruposeRegras(long group_id, long access_rule_id)
        {
            this.group_id = group_id;
            this.access_rule_id = access_rule_id;
        }
    }
}
