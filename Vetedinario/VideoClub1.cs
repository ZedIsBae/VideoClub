using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Vetedinario
{
    public partial class VideoClub1 : Form
    {
        public VideoClub1()
        {
            

            InitializeComponent();
            rellenaComboAutores();
            rellenaPeliculas();


        }

        //Codigo para cerrar este form
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Application.Exit();
        }

        private void rellenaComboAutores()
        {
            MySqlConnection conexion = new ConexionBBDD().conecta();
            MySqlCommand comando = new MySqlCommand("SELECT * FROM actors ORDER BY first_name", conexion);
            MySqlDataReader resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                String id = resultado.GetString(0);
                String first_name = resultado.GetString("first_name");
                String last_name = resultado.GetString("last_name");
                String gender = resultado.GetString("gender");
                desplegableActores.Items.Add( id+ "        " + gender + "     " + first_name + "        "+ last_name);
            }
            conexion.Close();
        }
        private void rellenaPeliculas()
        { 
            MySqlConnection conexion = new ConexionBBDD().conecta();
            MySqlCommand comando = new MySqlCommand("SELECT * FROM movies ORDER BY name", conexion);
            MySqlDataReader resultado = comando.ExecuteReader();
            while (resultado.Read())
            {
                String id = resultado.GetString(0);
                String name = resultado.GetString("name");
                String year = resultado.GetString("year");
                String rank = "";
                if (!resultado.IsDBNull(3)){
                    rank = resultado.GetString(3);
                }
                //  String gender = resultado.GetString("gender");
                desplegablePeliculas.Items.Add( id+ "        " + year+ "     " +    rank+"        "+  name);
            }
            conexion.Close();
        }

       
    }
}
