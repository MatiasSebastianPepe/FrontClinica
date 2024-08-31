using System;
using System.Collections.Generic;
using System.Drawing; // Asegúrate de incluir este using
using System.Windows.Forms;

namespace Front
{
    public partial class Fotos : Form
    {
        private List<System.Drawing.Image> _images; // Usa System.Drawing.Image para evitar conflictos
        private int _currentIndex;

        public Fotos(List<System.Drawing.Image> images, int initialIndex)
        {
            InitializeComponent();

            _images = images;
            _currentIndex = initialIndex;

            // Mostrar la imagen inicial
            ShowImage();

            int borderRadius = 20;

            ApplyRoundedCorners(close, borderRadius);
            ApplyRoundedCorners(download, borderRadius);
            ApplyRoundedCorners(buttonNext, borderRadius);
            ApplyRoundedCorners(buttonPrevious, borderRadius);
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

        private void ShowImage()
        {
            if (_images != null && _images.Count > 0)
            {
                pictureBoxFull.Image = _images[_currentIndex];
                pictureBoxFull.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (_images != null && _images.Count > 0)
            {
                _currentIndex = (_currentIndex + 1) % _images.Count;
                ShowImage();
            }
        }

        

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void download_Click(object sender, EventArgs e)
        {
            if (pictureBoxFull.Image != null)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                    saveFileDialog.Title = "Guardar imagen";
                    saveFileDialog.FileName = "imagen"; // Nombre de archivo predeterminado

                    // Mostrar el diálogo de guardar archivo
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Obtener la extensión seleccionada
                        string fileExtension = System.IO.Path.GetExtension(saveFileDialog.FileName);

                        // Determinar el formato de la imagen basado en la extensión
                        System.Drawing.Imaging.ImageFormat imageFormat;
                        switch (fileExtension.ToLower())
                        {
                            case ".jpg":
                            case ".jpeg":
                                imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case ".png":
                                imageFormat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                            case ".bmp":
                                imageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                            default:
                                MessageBox.Show("Formato de archivo no soportado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                        }

                        // Guardar la imagen en la ubicación seleccionada
                        pictureBoxFull.Image.Save(saveFileDialog.FileName, imageFormat);
                        MessageBox.Show("Imagen guardada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay imagen para descargar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (_images != null && _images.Count > 0)
            {
                _currentIndex = (_currentIndex - 1 + _images.Count) % _images.Count;
                ShowImage();
            }
        }
    }
}
