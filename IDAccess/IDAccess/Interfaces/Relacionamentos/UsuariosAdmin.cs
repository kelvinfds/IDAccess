using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAccess.Interfaces.Relacionamentos
{
    public class UsuariosAdmin
    {
        public long user_id;
        public int role;

        public UsuariosAdmin(long user_id, int role)
        {
            this.user_id = user_id;
            this.role = role;
        }
    }
}
