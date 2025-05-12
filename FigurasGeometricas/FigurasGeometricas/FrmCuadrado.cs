using System;
using System.Drawing;
using System.Windows.Forms;

namespace FigurasGeometricas
{
    public partial class FrmCuadrado : Form
    {
        private TextBox txtLado, txtArea, txtPerimetro;
        private PictureBox picCuadrado;
        private Button btnCalcularArea, btnCalcularPerimetro;

        public FrmCuadrado()
        {
            this.Text = "Cuadrado";
            this.Size = new Size(500, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Font = new Font("Poppins", 9);
            this.BackColor = Color.FromArgb(240, 244, 248);

            InicializarControles();
        }

        private void EstilizarBoton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.FromArgb(76, 175, 80); // verde material
            btn.ForeColor = Color.White;
            btn.FlatAppearance.BorderSize = 0;
            btn.Height = 30;
            btn.Width = 140;
            btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        }

        private void EstilizarCaja(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.WhiteSmoke;
            txt.Font = new Font("Segoe UI", 9);
        }

        private void InicializarControles()
        {
            int labelX = 30, textBoxX = 150, spacingY = 35, startY = 20, widthBox = 140;

            Label lblLado = new Label() { Text = "Lado:", Location = new Point(labelX, startY) };
            txtLado = new TextBox() { Location = new Point(textBoxX, startY), Width = widthBox };

            btnCalcularArea = new Button() { Text = "Área", Location = new Point(textBoxX, startY + spacingY) };
            btnCalcularArea.Click += btnCalcularArea_Click;
            EstilizarBoton(btnCalcularArea);

            btnCalcularPerimetro = new Button() { Text = "Perímetro", Location = new Point(textBoxX, startY + spacingY * 2) };
            btnCalcularPerimetro.Click += btnCalcularPerimetro_Click;
            EstilizarBoton(btnCalcularPerimetro);

            Label lblArea = new Label() { Text = "Área:", Location = new Point(labelX, startY + spacingY * 3) };
            txtArea = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 3), Width = widthBox, ReadOnly = true };

            Label lblPerimetro = new Label() { Text = "Perímetro:", Location = new Point(labelX, startY + spacingY * 4) };
            txtPerimetro = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 4), Width = widthBox, ReadOnly = true };

            foreach (var caja in new[] { txtLado, txtArea, txtPerimetro })
                EstilizarCaja(caja);

            picCuadrado = new PictureBox()
            {
                Location = new Point(310, 30),
                Size = new Size(160, 160),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };

            try
            {
                picCuadrado.Image = Image.FromFile("imagenes/cuadrado.png");
            }
            catch
            {
                picCuadrado.BackColor = Color.LightGray;
            }

            this.Controls.AddRange(new Control[]
            {
                lblLado, txtLado, btnCalcularArea, btnCalcularPerimetro,
                lblArea, txtArea, lblPerimetro, txtPerimetro,
                picCuadrado
            });
        }

        private void btnCalcularArea_Click(object sender, EventArgs e)
        {
            try
            {
                double lado = double.Parse(txtLado.Text);
                double area = lado * lado;
                txtArea.Text = area.ToString("F2");
            }
            catch
            {
                MessageBox.Show("Verifica que el lado sea un valor numérico válido.");
            }
        }

        private void btnCalcularPerimetro_Click(object sender, EventArgs e)
        {
            try
            {
                double lado = double.Parse(txtLado.Text);
                double perimetro = 4 * lado;
                txtPerimetro.Text = perimetro.ToString("F2");
            }
            catch
            {
                MessageBox.Show("Verifica que el lado sea un valor numérico válido.");
            }
        }
    }
}
