using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Vetedinario
{
    class ConexionBBDD
    {
        public MySqlConnection conecta()
        {

            /*Se necesitan 5 parametros:
             * 1ª Server: IP o nombre del servidor
             * 2ª Database: Nombre de la BBDD
             * 3ª UID: User id(not null)
             * 4ª Password: Contraseña
             * 5ª Port: puerto, por defecto es el 3306
             */
             MySqlConnection conexion = new MySqlConnection(
                 "Server= 127.0.0.1;"+
                 "Database= videoclub;"+
                 "Uid= root1234;"+
                 "Password = ;"+         
                 "Port= 3306");
            conexion.Open();
            return conexion;
        }

    }
}
