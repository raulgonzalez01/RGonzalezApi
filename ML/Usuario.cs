using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { set; get; }


        public string Nombre { set; get; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Sexo { get; set; }

        public int Edad { get; set; }

        public string Correo { get; set; }


        public List<object> Usuarios { get; set; }
    }
}
