using System;
using System.Drawing;
using System.Windows.Forms;

namespace FigurasGeometricas
{
    public partial class FrmElipse : Form
    {
        private TextBox txtA, txtB, txtArea, txtPerimetro;
        private PictureBox picElipse;
        private Button btnCalcularArea, btnCalcularPerimetro;

        public FrmElipse()
        {
            this.Text = "Elipse";
            this.Size = new Size(540, 360);
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
            btn.BackColor = Color.FromArgb(233, 30, 99); // rosa fuerte
            btn.ForeColor = Color.White;
            btn.FlatAppearance.BorderSize = 0;
            btn.Height = 30;
            btn.Width = 150;
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
            int labelX = 30, textBoxX = 160, spacingY = 35, startY = 20, widthBox = 140;

            Label lblA = new Label() { Text = "Semieje mayor (a):", Location = new Point(labelX, startY) };
            txtA = new TextBox() { Location = new Point(textBoxX, startY), Width = widthBox };

            Label lblB = new Label() { Text = "Semieje menor (b):", Location = new Point(labelX, startY + spacingY) };
            txtB = new TextBox() { Location = new Point(textBoxX, startY + spacingY), Width = widthBox };

            btnCalcularArea = new Button() { Text = "Calcular Área", Location = new Point(textBoxX, startY + spacingY * 2) };
            btnCalcularArea.Click += btnCalcularArea_Click;
            EstilizarBoton(btnCalcularArea);

            btnCalcularPerimetro = new Button() { Text = "Calcular Perímetro", Location = new Point(textBoxX, startY + spacingY * 3) };
            btnCalcularPerimetro.Click += btnCalcularPerimetro_Click;
            EstilizarBoton(btnCalcularPerimetro);

            Label lblArea = new Label() { Text = "Área:", Location = new Point(labelX, startY + spacingY * 4) };
            txtArea = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 4), Width = widthBox, ReadOnly = true };

            Label lblPerimetro = new Label() { Text = "Perímetro:", Location = new Point(labelX, startY + spacingY * 5) };
            txtPerimetro = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 5), Width = widthBox, ReadOnly = true };

            foreach (var caja in new[] { txtA, txtB, txtArea, txtPerimetro })
                EstilizarCaja(caja);

            picElipse = new PictureBox()
            {
                Location = new Point(340, 30),
                Size = new Size(160, 160),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };

            try
            {
                picElipse.Image = Image.FromFile("imagenes/elipse.png");
            }
            catch
            {
                picElipse.BackColor = Color.LightGray;
            }

            this.Controls.AddRange(new Control[]
            {
                lblA, txtA,
                lblB, txtB,
                btnCalcularArea, btnCalcularPerimetro,
                lblArea, txtArea,
                lblPerimetro, txtPerimetro,
                picElipse
            });
        }

        private void btnCalcularArea_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(txtA.Text);
                double b = double.Parse(txtB.Text);
                double area = Math.PI * a * b;
                txtArea.Text = area.ToString("F2");
            }
            catch
            {
                MessageBox.Show("Verifica que a y b sean números válidos.");
            }
        }

        private void btnCalcularPerimetro_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(txtA.Text);
                double b = double.Parse(txtB.Text);
                double perimetro = Math.PI * (3 * (a + b) - Math.Sqrt((3 * a + b) * (a + 3 * b)));
                txtPerimetro.Text = perimetro.ToString("F2");
            }
            catch
            {
                MessageBox.Show("Verifica que a y b sean números válidos.");
            }
        }
    }
}
