using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Front
{
    public partial class Pacientes : Form
    {
        private string connectionString = "Server=localhost;Database=clinicadb;Uid=pepe;Pwd=root;";
        private Image defaultImage;

        public Pacientes()
        {
            InitializeComponent();

            this.FormClosed += new FormClosedEventHandler(Pacientes_FormClosed);

            defaultImage = pictureBox1.Image;


            int borderRadius = 20; // Ajusta este valor para cambiar el radio de las esquinas

            // Aplica los bordes redondeados a cada botón
            ApplyRoundedCorners(agregarBtn, borderRadius);
            ApplyRoundedCorners(deleteBtn, borderRadius);
            ApplyRoundedCorners(detallesBtn, borderRadius);
            ApplyRoundedCorners(button1, borderRadius);


            LoadPacientes();
        }

        private void Pacientes_Load(object sender, EventArgs e)
        {
        }

        private void agregarBtn_Click(object sender, EventArgs e)
        {
            // Validar que todos los TextBox no estén vacíos
            if (string.IsNullOrWhiteSpace(nombreTB.Text) || string.IsNullOrWhiteSpace(telefonoTB.Text) ||
                string.IsNullOrWhiteSpace(correoTB.Text) || string.IsNullOrWhiteSpace(FdNTB.Text) ||
                string.IsNullOrWhiteSpace(antTB.Text) || string.IsNullOrWhiteSpace(consTB.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que nombreTB sea un string (no contiene números)
            if (nombreTB.Text.Any(char.IsDigit))
            {
                MessageBox.Show("El nombre no debe contener números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que telefonoTB sea numérico
            if (!telefonoTB.Text.All(char.IsDigit))
            {
                MessageBox.Show("El teléfono debe contener solo números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que correoTB tenga formato de correo electrónico
            try
            {
                var correo = new System.Net.Mail.MailAddress(correoTB.Text);
                if (correo.Address != correoTB.Text)
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("Por favor, ingresa un correo electrónico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que FdNTB tenga formato de fecha
            DateTime fechaNacimiento;
            if (!DateTime.TryParse(FdNTB.Text, out fechaNacimiento))
            {
                MessageBox.Show("Por favor, ingresa una fecha válida (formato: dd/mm/aaaa).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Pacientes (nombre, telefono, correo, fechaNacimiento, antecedentes, motivoVisita, fotoPerfil) " +
                                   "VALUES (@nombre, @telefono, @correo, @fechaNacimiento, @antecedentes, @motivoVisita, @fotoPerfil)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", nombreTB.Text);
                        command.Parameters.AddWithValue("@telefono", telefonoTB.Text);
                        command.Parameters.AddWithValue("@correo", correoTB.Text);
                        command.Parameters.AddWithValue("@fechaNacimiento", FdNTB.Text);
                        command.Parameters.AddWithValue("@antecedentes", antTB.Text);
                        command.Parameters.AddWithValue("@motivoVisita", consTB.Text);

                        // Convertir la imagen actual del PictureBox a bytes y guardarla solo si no es nula
                        if (pictureBox1.Image != null)
                        {
                            byte[] imageBytes = ImageToByteArray(pictureBox1.Image);
                            command.Parameters.AddWithValue("@fotoPerfil", imageBytes);
                        }
                        else
                        {
                            // Si no hay imagen en el PictureBox, asignar DBNull.Value
                            command.Parameters.AddWithValue("@fotoPerfil", 0);
                        }


                        // Ejecutar la consulta
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Paciente agregado con éxito.");

                // Limpiar los TextBox después de agregar los datos
                nombreTB.Clear();
                telefonoTB.Clear();
                correoTB.Clear();
                FdNTB.Clear();
                antTB.Clear();
                consTB.Clear();
                pictureBox1.Image = defaultImage;


                // Recargar los datos en el DataGridView
                LoadPacientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el paciente: " + ex.Message);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar la fila seleccionada?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = "DELETE FROM Pacientes WHERE id = @id";

                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@id", id);
                                command.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Paciente eliminado con éxito.");

                        LoadPacientes();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el paciente: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void detallesBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT id, nombre, telefono, correo, fechaNacimiento, antecedentes, motivoVisita, fotoPerfil FROM Pacientes WHERE id = @id";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string nombre = reader["nombre"].ToString();
                                    string telefono = reader["telefono"].ToString();
                                    string correo = reader["correo"].ToString();
                                    string fechaNacimiento = reader["fechaNacimiento"].ToString();
                                    string antecedentes = reader["antecedentes"].ToString();
                                    string consulta = reader["motivoVisita"].ToString();

                                    Image fotoPerfil = defaultImage; // Asignar la imagen por defecto

                                    // Verificar si hay datos válidos en la columna fotoPerfil
                                    if (!(reader["fotoPerfil"] is DBNull))
                                    {
                                        byte[] fotoPerfilBytes = (byte[])reader["fotoPerfil"];
                                        if (fotoPerfilBytes.Length > 0 && !fotoPerfilBytes.SequenceEqual(new byte[] { 0 }))
                                        {
                                            try
                                            {
                                                using (MemoryStream ms = new MemoryStream(fotoPerfilBytes))
                                                {
                                                    fotoPerfil = Image.FromStream(ms);
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                // Si ocurre un error al cargar la imagen, se usa la imagen por defecto
                                                fotoPerfil = defaultImage;
                                            }
                                        }
                                    }

                                    // Pasar la imagen al formulario Detalles
                                    Detalles detallesForm = new Detalles(id, nombre, telefono, correo, fechaNacimiento, antecedentes, consulta, fotoPerfil);
                                    detallesForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("No se encontraron datos para este paciente.");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los detalles: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un paciente para ver los detalles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void ApplyRoundedCorners(System.Windows.Forms.Button btn, int borderRadius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, borderRadius, borderRadius), 180, 90);
            path.AddArc(new Rectangle(btn.Width - borderRadius, 0, borderRadius, borderRadius), 270, 90);
            path.AddArc(new Rectangle(btn.Width - borderRadius, btn.Height - borderRadius, borderRadius, borderRadius), 0, 90);
            path.AddArc(new Rectangle(0, btn.Height - borderRadius, borderRadius, borderRadius), 90, 90);
            path.CloseFigure();
            btn.Region = new Region(path);

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
        }

        private void LoadPacientes()
        {
            dataGridView1.Rows.Clear();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT id, nombre, telefono, correo, fechaNacimiento, antecedentes, motivoVisita FROM Pacientes";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                dataGridView1.Rows.Add(
                                    reader["id"].ToString(),
                                    reader["nombre"].ToString(),
                                    reader["telefono"].ToString(),
                                    reader["correo"].ToString(),
                                    reader["fechaNacimiento"].ToString(),
                                    reader["antecedentes"].ToString(),
                                    reader["motivoVisita"].ToString()
                                 
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los pacientes: " + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Abre el diálogo para seleccionar un archivo.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Eliminar la imagen anterior (si la hay).
                if (pictureBox1.Image != null && pictureBox1.Image != Front.Properties.Resources.perfil)
                {
                    pictureBox1.Image.Dispose();
                }

                // Carga la imagen desde el archivo seleccionado.
                string filePath = openFileDialog1.FileName;
                Image originalImage = Image.FromFile(filePath);

                // Redimensiona la imagen.
                Image resizedImage = ResizeImage(originalImage, 144, 144);

                // Asigna la imagen redimensionada al PictureBox.
                pictureBox1.Image = resizedImage;
            }
        }

        private Image ResizeImage(Image image, int targetWidth, int targetHeight)
        {
            // Calcular el ratio de la imagen original.
            float originalRatio = (float)image.Width / image.Height;
            float targetRatio = (float)targetWidth / targetHeight;

            int newWidth, newHeight;
            if (originalRatio > targetRatio)
            {
                // La imagen es más ancha en relación a la altura, ajustar basado en el ancho.
                newWidth = targetWidth;
                newHeight = (int)(targetWidth / originalRatio);
            }
            else
            {
                // La imagen es más alta en relación al ancho, ajustar basado en la altura.
                newWidth = (int)(targetHeight * originalRatio);
                newHeight = targetHeight;
            }

            // Crear una nueva imagen con las dimensiones del PictureBox.
            Bitmap resizedImage = new Bitmap(targetWidth, targetHeight);

            // Crear un objeto Graphics para dibujar la imagen.
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                // Establecer el color de fondo (por ejemplo, blanco).
                g.Clear(Color.White);

                // Configurar la calidad del redimensionamiento.
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                // Calcular la posición para centrar la imagen.
                int posX = (targetWidth - newWidth) / 2;
                int posY = (targetHeight - newHeight) / 2;

                // Dibujar la imagen redimensionada en la posición calculada.
                g.DrawImage(image, posX, posY, newWidth, newHeight);
            }

            return resizedImage;
        }

        private byte[] ImageToByteArray(Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }


        private void buscar_Click(object sender, EventArgs e)
        {
            string searchText = Busqueda.Text.Trim();

            // Limpiar las filas existentes en el DataGridView
            dataGridView1.Rows.Clear();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query;

                    if (string.IsNullOrEmpty(searchText))
                    {
                        // Si el texto de búsqueda está vacío, mostrar todos los pacientes
                        query = "SELECT id, nombre, telefono, correo, fechaNacimiento, antecedentes, motivoVisita FROM Pacientes";
                    }
                    else
                    {
                        // Si hay texto de búsqueda, filtrar por nombre
                        query = "SELECT id, nombre, telefono, correo, fechaNacimiento, antecedentes, motivoVisita FROM Pacientes WHERE nombre LIKE @nombre";
                    }

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(searchText))
                        {
                            command.Parameters.AddWithValue("@nombre", "%" + searchText + "%");
                        }

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataGridView1.Rows.Add(reader["id"].ToString(), reader["nombre"].ToString(), reader["telefono"].ToString(),
                                                       reader["correo"].ToString(), reader["fechaNacimiento"],
                                                       reader["antecedentes"].ToString(), reader["motivoVisita"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar pacientes: " + ex.Message);
            }
        }

        private void Busqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita que se produzca el sonido "ding"
                buscar_Click(this, EventArgs.Empty); // Llama al método del botón "Buscar"
            }
        }

        private void Pacientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
