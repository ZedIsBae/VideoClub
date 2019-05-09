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
    public partial class PanelPrincipal : Form
    {
        public PanelPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new ConexionBBDD().conecta();

          //  MySqlCommand comando = new MySqlCommand("SELECT * from usuarios where " + " usuario = '" +textBox1.Text +"' and pass ='" + textBox2.Text+"' ;", conexion);
            MySqlCommand comando = new MySqlCommand("SELECT * from usuarios where usuario=@usuario and pass=@pass", conexion);
            comando.Parameters.AddWithValue("@usuario", textBox1.Text);
            comando.Parameters.AddWithValue("@pass", textBox2.Text);

            MySqlDataReader resultado = comando.ExecuteReader();
            if (resultado.Read())
            {
                MessageBox.Show("Acceso Jakiado", "Abdul trabaja ");

                this.Visible = false;
                VideoClub1 ventana = new VideoClub1();
                ventana.Visible = true;
                this.Visible = false;  // oculta el panel de loggin             
            }
            else
            {
                MessageBox.Show("Se cansó de trabajar", "Abdul Trabajando...");
            }
            

        }

       
    }
}
