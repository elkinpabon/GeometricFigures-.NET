using System;
using System.Drawing;
using System.Windows.Forms;

namespace FigurasGeometricas
{
    public partial class FrmCirculo : Form
    {
        private TextBox txtRadio, txtArea, txtPerimetro;
        private PictureBox picCirculo;
        private Button btnCalcularArea, btnCalcularPerimetro;

        public FrmCirculo()
        {
            this.Text = "Círculo";
            this.Size = new Size(500, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Font = new Font("Poppins", 9);
            this.BackColor = Color.FromArgb(240, 244, 248); // fondo suave

            InicializarControles();
        }

        private void EstilizarBoton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.FromArgb(255, 87, 34); // naranja Material Design
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

            Label lblRadio = new Label() { Text = "Radio:", Location = new Point(labelX, startY) };
            txtRadio = new TextBox() { Location = new Point(textBoxX, startY), Width = widthBox };

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

            foreach (var caja in new[] { txtRadio, txtArea, txtPerimetro })
                EstilizarCaja(caja);

            picCirculo = new PictureBox()
            {
                Location = new Point(310, 30),
                Size = new Size(160, 160),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };

            try
            {
                picCirculo.Image = Image.FromFile("imagenes/circulo.png");
            }
            catch
            {
                picCirculo.BackColor = Color.LightGray;
            }

            this.Controls.AddRange(new Control[]
            {
                lblRadio, txtRadio, btnCalcularArea, btnCalcularPerimetro,
                lblArea, txtArea, lblPerimetro, txtPerimetro,
                picCirculo
            });
        }

        private void btnCalcularArea_Click(object sender, EventArgs e)
        {
            try
            {
                double r = double.Parse(txtRadio.Text);
                double area = Math.PI * r * r;
                txtArea.Text = area.ToString("F2");
            }
            catch
            {
                MessageBox.Show("Verifica que el radio sea un número válido.");
            }
        }

        private void btnCalcularPerimetro_Click(object sender, EventArgs e)
        {
            try
            {
                double r = double.Parse(txtRadio.Text);
                double perimetro = 2 * Math.PI * r;
                txtPerimetro.Text = perimetro.ToString("F2");
            }
            catch
            {
                MessageBox.Show("Verifica que el radio sea un número válido.");
            }
        }
    }
}
