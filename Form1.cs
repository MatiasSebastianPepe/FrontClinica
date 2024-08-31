using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Front
{
    public partial class Clinica : Form
    {
        private string connectionString = "Server=localhost;Database=clinicadb;Uid=pepe;Pwd=root;";
        public Clinica()
        {
            InitializeComponent();

            // Redondear las esquinas del botón
            int borderRadius = 20; // Ajusta este valor para cambiar el radio de las esquinas
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, borderRadius, borderRadius), 180, 90);
            path.AddArc(new Rectangle(incButton.Width - borderRadius, 0, borderRadius, borderRadius), 270, 90);
            path.AddArc(new Rectangle(incButton.Width - borderRadius, incButton.Height - borderRadius, borderRadius, borderRadius), 0, 90);
            path.AddArc(new Rectangle(0, incButton.Height - borderRadius, borderRadius, borderRadius), 90, 90);
            path.CloseFigure();
            incButton.Region = new Region(path);

            incButton.FlatStyle = FlatStyle.Flat;
            incButton.FlatAppearance.BorderSize = 0; // Sin borde
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void usuaioTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void incButton_Click(object sender, EventArgs e)
        {
            // Usar la cadena de conexión en el método
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM Usuarios WHERE username=@Username AND password=SHA2(@Password, 256)";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", usuarioTB.Text);
                cmd.Parameters.AddWithValue("@Password", contrasenaTB.Text);

                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();

                if (count == 1)
                {

                    Pacientes pacientesForm = new Pacientes();

                    // Mostrar el formulario Pacientes
                    pacientesForm.ShowDialog();

                    // Opcionalmente, puedes cerrar el formulario de inicio de sesión actual
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Login failed. Please check your username and password.");
                }
            }
        }

        private void contrasenaTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita que se produzca el sonido "ding"
                incButton_Click(this, EventArgs.Empty); // Llama al método del botón "Buscar"
            }
        }

    }
}
