using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAccess.Interfaces.Relacionamentos
{
    class RegraseHorarios
    {
        public long access_rule_id;
        public long time_zone_id;

        public RegraseHorarios(long access_rule_id, long time_zone_id)
        {
            this.access_rule_id = access_rule_id;
            this.time_zone_id = time_zone_id;
        }
    }
}
