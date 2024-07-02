using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;


namespace CapaNegocio
{
    public class CN_Usuarios
    {
        private CD_Usuarios objCapaDato = new CD_Usuarios();//Es para acceder a todos los metodos que estan en CD_Usuarios como select, delete o update

        public List<Usuario> Listar()
        {
            return objCapaDato.Listar();
        }
    }
}

