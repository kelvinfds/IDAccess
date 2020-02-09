using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAccess.Interfaces.Relacionamentos
{
    class UsuarioseGrupos
    {
        public long user_id;
        public long group_id;

        public UsuarioseGrupos(long user_id, long group_id)
        {
            this.user_id = user_id;
            this.group_id = group_id;
        }
    }
}
