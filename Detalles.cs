using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Front
{
    public partial class Detalles : Form
    {
        private string connectionString = "Server=localhost;Database=clinicadb;Uid=pepe;Pwd=root;";

        private List<byte[]> selectedImages = new List<byte[]>();

        public Detalles(int id, string nombre, string telefono, string correo, string fechaNacimiento, string antecedentes, string consulta, Image fotoPerfil)
        {
            InitializeComponent();

            this.FormClosed += new FormClosedEventHandler(Pacientes_FormClosed);

            this.Load += new System.EventHandler(this.DetallesForm_Load);


            idDet.Text = id.ToString();
            nombreDet.Text = nombre;
            telefonoDet.Text = telefono;
            correoDet.Text = correo;
            fechaNacimientoDet.Text = fechaNacimiento;
            antecedentesDet.Text = antecedentes;
            consultaDet.Text = consulta;
            this.fotoPerfil.Image = fotoPerfil;

            int borderRadius = 20;

            ApplyRoundedCorners(addImg, borderRadius);
            ApplyRoundedCorners(deleteBtnDet, borderRadius);
            ApplyRoundedCorners(editaBtnDet, borderRadius);
            ApplyRoundedCorners(agregaBtnDet, borderRadius);
            ApplyRoundedCorners(button1, borderRadius);     
            ApplyRoundedCorners(button4, borderRadius);
            ApplyRoundedCorners(button2, borderRadius);
            ApplyRoundedCorners(button3, borderRadius);

        }




        private void Detalles_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
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
            btn.FlatAppearance.BorderSize = 0; // Sin borde
        }

        private void addImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Configuración del OpenFileDialog
                openFileDialog.Multiselect = true; // Permitir selección múltiple
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"; // Filtro de tipos de archivo
                openFileDialog.Title = "Selecciona hasta 6 imágenes";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                // Mostrar el diálogo y verificar si el usuario seleccionó archivos
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Verificar si el usuario seleccionó más de 6 imágenes
                    if (openFileDialog.FileNames.Length > 6)
                    {
                        MessageBox.Show("Por favor, selecciona un máximo de 6 imágenes.", "Límite de selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Lista de PictureBoxes en los que se cargarán las imágenes
                    PictureBox[] pictureBoxes = { fotoVisita1, fotoVisita2, fotoVisita3, fotoVisita4, fotoVisita5, fotoVisita6 };

                    // Procesar y asignar las imágenes seleccionadas
                    for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                    {
                        string fileName = openFileDialog.FileNames[i];
                        Image image = Image.FromFile(fileName);
                        pictureBoxes[i].Image = image;

                        // Si necesitas convertir la imagen a byte[] para almacenarla en la base de datos, puedes hacerlo aquí:
                        byte[] imageBytes = File.ReadAllBytes(fileName);

                        // Guardar en la base de datos o realizar otras acciones necesarias
                    }

                    MessageBox.Show($"{openFileDialog.FileNames.Length} imágenes seleccionadas y cargadas.");
                }
            }
        }


        private void agregaBtnDet_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que se haya ingresado una fecha y descripción
                if (string.IsNullOrWhiteSpace(fechaVisita.Text) || string.IsNullOrWhiteSpace(descripcionVisita.Text))
                {
                    MessageBox.Show("Por favor, ingresa la fecha y descripción de la visita.", "Campos obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO detallespaciente (id, fechaVisita, descripcionVisita, fotoVisita1, fotoVisita2, fotoVisita3, fotoVisita4, fotoVisita5, fotoVisita6) " +
                                   "VALUES (@id, @fechaVisita, @descripcionVisita, @fotoVisita1, @fotoVisita2, @fotoVisita3, @fotoVisita4, @fotoVisita5, @fotoVisita6); " +
                                   "SELECT LAST_INSERT_ID();";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Asignar el valor del id desde idDet
                        command.Parameters.AddWithValue("@id", Convert.ToInt32(idDet.Text));

                        // Asignar valores de los TextBox
                        command.Parameters.AddWithValue("@fechaVisita", fechaVisita.Text);
                        command.Parameters.AddWithValue("@descripcionVisita", descripcionVisita.Text);

                        // Lista de PictureBoxes a procesar
                        PictureBox[] pictureBoxes = { fotoVisita1, fotoVisita2, fotoVisita3, fotoVisita4, fotoVisita5, fotoVisita6 };

                        // Procesar cada PictureBox para extraer la imagen y convertirla a byte[]
                        for (int i = 0; i < pictureBoxes.Length; i++)
                        {
                            string paramName = $"@fotoVisita{i + 1}";
                            PictureBox pictureBox = pictureBoxes[i];

                            if (pictureBox.Image != null)
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    pictureBox.Image.Save(ms, pictureBox.Image.RawFormat);
                                    command.Parameters.AddWithValue(paramName, ms.ToArray());
                                }
                            }
                            else
                            {
                                command.Parameters.AddWithValue(paramName, 0); // Asignar 0 si no hay imagen
                            }
                        }

                        // Ejecutar la consulta y obtener el idVisita generado
                        int idVisita = Convert.ToInt32(command.ExecuteScalar());

                        // Actualizar el DataGridView con los nuevos datos
                        dataGridViewDetalles.Rows.Add(idVisita, fechaVisita.Text, descripcionVisita.Text);
                    }
                }

                MessageBox.Show("Visita agregada con éxito.");

                // Limpiar los TextBox y los PictureBox
                fechaVisita.Clear();
                descripcionVisita.Clear();
                foreach (PictureBox pictureBox in new[] { fotoVisita1, fotoVisita2, fotoVisita3, fotoVisita4, fotoVisita5, fotoVisita6 })
                {
                    pictureBox.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la visita: " + ex.Message);
            }
        }



        private void DetallesForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT idVisita, fechaVisita, descripcionVisita FROM detallespaciente WHERE id = @id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Asignar el valor del id desde idDet
                        command.Parameters.AddWithValue("@id", Convert.ToInt32(idDet.Text));

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Agregar las filas al DataGridView
                                dataGridViewDetalles.Rows.Add(reader["idVisita"].ToString(), reader["fechaVisita"].ToString(), reader["descripcionVisita"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las visitas: " + ex.Message);
            }
        }

        private void deleteBtnDet_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que haya una fila seleccionada en el DataGridView
                if (dataGridViewDetalles.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, selecciona una visita para eliminar.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmar la eliminación
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta visita?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                // Obtener el índice de la fila seleccionada
                int selectedIndex = dataGridViewDetalles.SelectedRows[0].Index;

                // Obtener la fecha de la visita seleccionada (asumiendo que la primera columna del DataGridView es la fecha)
                string fechaSeleccionada = dataGridViewDetalles.Rows[selectedIndex].Cells["fecha"].Value.ToString();

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Eliminar el registro de la base de datos
                    string query = "DELETE FROM detallespaciente WHERE id = @id AND fechaVisita = @fechaVisita";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", Convert.ToInt32(idDet.Text));
                        command.Parameters.AddWithValue("@fechaVisita", fechaSeleccionada);
                        command.ExecuteNonQuery();
                    }
                }

                // Eliminar la fila seleccionada del DataGridView
                dataGridViewDetalles.Rows.RemoveAt(selectedIndex);

                MessageBox.Show("Visita eliminada con éxito.", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la visita: " + ex.Message);
            }
        }

        private void editaBtnDet_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que haya una fila seleccionada en el DataGridView
                if (dataGridViewDetalles.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, selecciona una visita para editar.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el índice de la fila seleccionada
                int selectedIndex = dataGridViewDetalles.SelectedRows[0].Index;

                // Obtener la fecha original de la visita seleccionada
                string fechaOriginal = dataGridViewDetalles.Rows[selectedIndex].Cells["fecha"].Value.ToString();

                // Obtener los nuevos valores de los TextBox
                string nuevaFecha = fechaVisita.Text;
                string nuevaDescripcion = descripcionVisita.Text;

                // Verificar que se hayan ingresado nuevos valores
                if (string.IsNullOrWhiteSpace(nuevaFecha) || string.IsNullOrWhiteSpace(nuevaDescripcion))
                {
                    MessageBox.Show("Por favor, ingresa una nueva fecha y descripción.", "Campos obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Actualizar el registro en la base de datos
                    string query = "UPDATE detallespaciente SET fechaVisita = @nuevaFecha, descripcionVisita = @nuevaDescripcion WHERE id = @id AND fechaVisita = @fechaOriginal";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nuevaFecha", nuevaFecha);
                        command.Parameters.AddWithValue("@nuevaDescripcion", nuevaDescripcion);
                        command.Parameters.AddWithValue("@id", Convert.ToInt32(idDet.Text));
                        command.Parameters.AddWithValue("@fechaOriginal", fechaOriginal);

                        command.ExecuteNonQuery();
                    }
                }

                // Actualizar la fila seleccionada en el DataGridView
                dataGridViewDetalles.Rows[selectedIndex].Cells["fecha"].Value = nuevaFecha;
                dataGridViewDetalles.Rows[selectedIndex].Cells["DetallesDGV"].Value = nuevaDescripcion;

                MessageBox.Show("Visita editada con éxito.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los TextBox
                fechaVisita.Clear();
                descripcionVisita.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar la visita: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que haya una fila seleccionada en el DataGridView
                if (dataGridViewDetalles.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, selecciona una visita para ver las imágenes.", "Ver imágenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el idVisita de la fila seleccionada
                int idVisita = Convert.ToInt32(dataGridViewDetalles.SelectedRows[0].Cells["idVisita"].Value);

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL para obtener las imágenes
                    string query = "SELECT fotoVisita1, fotoVisita2, fotoVisita3, fotoVisita4, fotoVisita5, fotoVisita6 " +
                                   "FROM detallespaciente WHERE idVisita = @idVisita";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idVisita", idVisita);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Asignar las imágenes a los PictureBox
                                SetPictureBoxImage(fotoVisita1, reader["fotoVisita1"]);
                                SetPictureBoxImage(fotoVisita2, reader["fotoVisita2"]);
                                SetPictureBoxImage(fotoVisita3, reader["fotoVisita3"]);
                                SetPictureBoxImage(fotoVisita4, reader["fotoVisita4"]);
                                SetPictureBoxImage(fotoVisita5, reader["fotoVisita5"]);
                                SetPictureBoxImage(fotoVisita6, reader["fotoVisita6"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las imágenes: " + ex.Message);
            }
        }

        private void SetPictureBoxImage(PictureBox pictureBox, object imageData)
        {
            if (imageData != DBNull.Value)
            {
                byte[] imageBytes = (byte[])imageData;
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    pictureBox.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pictureBox.Image = null; // O una imagen predeterminada si lo prefieres
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Cierra el formulario actual
            this.Hide();

            // Crea una nueva instancia del formulario Pacientes
            Pacientes formularioPacientes = new Pacientes();

            // Muestra el formulario Pacientes
            formularioPacientes.Show();
        }

        private void fotoVisita1_Click(object sender, EventArgs e)
        {
            // Crear una lista de imágenes a mostrar
            List<Image> images = new List<Image>
    {
        fotoVisita1.Image,
        fotoVisita2.Image,
        fotoVisita3.Image,
        fotoVisita4.Image,
        fotoVisita5.Image,
        fotoVisita6.Image
    }.Where(img => img != null).ToList(); // Filtra las imágenes nulas

            // Encontrar el índice de la imagen clickeada
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null && pictureBox.Image != null)
            {
                int initialIndex = images.IndexOf(pictureBox.Image);

                // Crear una instancia del formulario de vista previa y pasar la lista de imágenes
                Fotos fotosForm = new Fotos(images, initialIndex);
                fotosForm.ShowDialog(); // Mostrar el formulario como modal
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Crear y configurar el OpenFileDialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                // Mostrar el diálogo y verificar si se seleccionó un archivo
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Cargar la imagen seleccionada en el PictureBox
                    fotoPerfil.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Verificar si el PictureBox tiene una imagen
            if (fotoPerfil.Image != null)
            {
                // Convertir la imagen del PictureBox a un arreglo de bytes
                using (MemoryStream ms = new MemoryStream())
                {
                    fotoPerfil.Image.Save(ms, fotoPerfil.Image.RawFormat);
                    byte[] imagenBytes = ms.ToArray();

                    // Obtener el id del paciente del TextBox
                    int pacienteID = int.Parse(idDet.Text);


                    // Consulta SQL para actualizar la imagen
                    string query = "UPDATE Pacientes SET fotoPerfil = @Imagen WHERE id = @PacienteID";

                    // Conectar a la base de datos y ejecutar la consulta
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Imagen", imagenBytes);
                            command.Parameters.AddWithValue("@PacienteID", pacienteID);

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                    }

                    MessageBox.Show("Imagen guardada exitosamente en la base de datos.");
                }
            }
            else
            {
                MessageBox.Show("No hay ninguna imagen cargada en el PictureBox.");
            }
        }

        private void Pacientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }


}
