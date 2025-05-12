using System;
using System.Drawing;
using System.Windows.Forms;

namespace FigurasGeometricas
{
    public partial class FrmRombo : Form
    {
        private TextBox txtDiagonalMayor, txtDiagonalMenor, txtLado, txtArea, txtPerimetro;
        private PictureBox picRombo;
        private Button btnCalcularArea, btnCalcularPerimetro;

        public FrmRombo()
        {
            this.Text = "Rombo";
            this.Size = new Size(550, 400);
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
            btn.BackColor = Color.FromArgb(156, 39, 176); // morado
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
            int labelX = 30, textBoxX = 170, spacingY = 35, startY = 20, widthBox = 140;

            Label lblDiagonalMayor = new Label() { Text = "Diagonal Mayor (D):", Location = new Point(labelX, startY) };
            txtDiagonalMayor = new TextBox() { Location = new Point(textBoxX, startY), Width = widthBox };

            Label lblDiagonalMenor = new Label() { Text = "Diagonal Menor (d):", Location = new Point(labelX, startY + spacingY) };
            txtDiagonalMenor = new TextBox() { Location = new Point(textBoxX, startY + spacingY), Width = widthBox };

            Label lblLado = new Label() { Text = "Lado:", Location = new Point(labelX, startY + spacingY * 2) };
            txtLado = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 2), Width = widthBox };

            btnCalcularArea = new Button() { Text = "Área", Location = new Point(textBoxX, startY + spacingY * 3) };
            btnCalcularArea.Click += btnCalcularArea_Click;
            EstilizarBoton(btnCalcularArea);

            btnCalcularPerimetro = new Button() { Text = "Perímetro", Location = new Point(textBoxX, startY + spacingY * 4) };
            btnCalcularPerimetro.Click += btnCalcularPerimetro_Click;
            EstilizarBoton(btnCalcularPerimetro);

            Label lblArea = new Label() { Text = "Área:", Location = new Point(labelX, startY + spacingY * 5) };
            txtArea = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 5), Width = widthBox, ReadOnly = true };

            Label lblPerimetro = new Label() { Text = "Perímetro:", Location = new Point(labelX, startY + spacingY * 6) };
            txtPerimetro = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 6), Width = widthBox, ReadOnly = true };

            foreach (var caja in new[] { txtDiagonalMayor, txtDiagonalMenor, txtLado, txtArea, txtPerimetro })
                EstilizarCaja(caja);

            picRombo = new PictureBox()
            {
                Location = new Point(340, 30),
                Size = new Size(180, 180),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };

            try
            {
                picRombo.Image = Image.FromFile("imagenes/rombo.png");
            }
            catch
            {
                picRombo.BackColor = Color.LightGray;
            }

            this.Controls.AddRange(new Control[]
            {
                lblDiagonalMayor, txtDiagonalMayor,
                lblDiagonalMenor, txtDiagonalMenor,
                lblLado, txtLado,
                btnCalcularArea, btnCalcularPerimetro,
                lblArea, txtArea,
                lblPerimetro, txtPerimetro,
                picRombo
            });
        }

        private void btnCalcularArea_Click(object sender, EventArgs e)
        {
            try
            {
                double D = double.Parse(txtDiagonalMayor.Text);
                double d = double.Parse(txtDiagonalMenor.Text);
                double area = (D * d) / 2;
                txtArea.Text = area.ToString("F2");
            }
            catch
            {
                MessageBox.Show("Verifica que las diagonales sean valores numéricos válidos.");
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
