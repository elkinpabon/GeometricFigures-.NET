using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FigurasGeometricas
{
    public partial class Form1 : Form

    {
        private Dictionary<string, string> figuraImagenes = new Dictionary<string, string>();


        private void AbrirFormularioHijo(Form formularioHijo)
        {
            if (panelContenido.Controls.Count > 0)
                panelContenido.Controls[0].Dispose();

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(formularioHijo);
            panelContenido.Tag = formularioHijo;
            formularioHijo.Show();
        }


        public Form1()
        {
            InitializeComponent();

        }
        private void btnTriangulo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmTriangulo());
        }

        private void btnCuadrado_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmCuadrado());
        }

        private void btnCirculo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmCirculo());
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRectangulo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmRectangulo());
        }

        private void btnRombo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmRombo());
        }

        private void btnTrapecio_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmTrapecio());
        }

        private void btnOvalo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmOvalo());
        }

        private void btnElipse_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmElipse());
        }

        private void btnDeltoide_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmDeltoide());
        }

        private void btnRomboide_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmRomboide());
        }

        private void btnPoligonosRegulares_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmPoligonosRectangulares());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "¿Estás seguro de que deseas salir?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

                        if (confirm == DialogResult.Yes)
                        {
                            Application.Exit();
                        }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                string ruta = Path.Combine(Application.StartupPath, "imagenes", "main.png");
                if (File.Exists(ruta))
                {
                    pictureBox1.Image = Image.FromFile(ruta);
                    pictureBox1.Size = new Size(605, 272);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    MessageBox.Show("La imagen no fue encontrada en:\n" + ruta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar la imagen:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmTrianguloHeron());
        }
    }
}
