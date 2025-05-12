using System;
using System.Drawing;
using System.Windows.Forms;

namespace FigurasGeometricas
{
    public partial class FrmRectangulo : Form
    {
        private TextBox txtBase, txtAltura, txtArea, txtPerimetro;
        private PictureBox picRectangulo;
        private Button btnCalcularArea, btnCalcularPerimetro;

        public FrmRectangulo()
        {
            this.Text = "Rectángulo";
            this.Size = new Size(550, 370);
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
            btn.BackColor = Color.FromArgb(0, 188, 212); // azul cyan
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
            int labelX = 30, textBoxX = 160, spacingY = 35, startY = 20, widthBox = 140;

            Label lblBase = new Label() { Text = "Base:", Location = new Point(labelX, startY) };
            txtBase = new TextBox() { Location = new Point(textBoxX, startY), Width = widthBox };

            Label lblAltura = new Label() { Text = "Altura:", Location = new Point(labelX, startY + spacingY) };
            txtAltura = new TextBox() { Location = new Point(textBoxX, startY + spacingY), Width = widthBox };

            btnCalcularArea = new Button() { Text = "Área", Location = new Point(textBoxX, startY + spacingY * 2) };
            btnCalcularArea.Click += btnCalcularArea_Click;
            EstilizarBoton(btnCalcularArea);

            btnCalcularPerimetro = new Button() { Text = "Perímetro", Location = new Point(textBoxX, startY + spacingY * 3) };
            btnCalcularPerimetro.Click += btnCalcularPerimetro_Click;
            EstilizarBoton(btnCalcularPerimetro);

            Label lblArea = new Label() { Text = "Área:", Location = new Point(labelX, startY + spacingY * 4) };
            txtArea = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 4), Width = widthBox, ReadOnly = true };

            Label lblPerimetro = new Label() { Text = "Perímetro:", Location = new Point(labelX, startY + spacingY * 5) };
            txtPerimetro = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 5), Width = widthBox, ReadOnly = true };

            foreach (var caja in new[] { txtBase, txtAltura, txtArea, txtPerimetro })
                EstilizarCaja(caja);

            picRectangulo = new PictureBox()
            {
                Location = new Point(330, 30),
                Size = new Size(180, 180),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };

            try
            {
                picRectangulo.Image = Image.FromFile("imagenes/rectangulo.png");
            }
            catch
            {
                picRectangulo.BackColor = Color.LightGray;
            }

            this.Controls.AddRange(new Control[]
            {
                lblBase, txtBase, lblAltura, txtAltura,
                btnCalcularArea, btnCalcularPerimetro,
                lblArea, txtArea, lblPerimetro, txtPerimetro,
                picRectangulo
            });
        }

        private void btnCalcularArea_Click(object sender, EventArgs e)
        {
            try
            {
                double b = double.Parse(txtBase.Text);
                double h = double.Parse(txtAltura.Text);
                double area = b * h;
                txtArea.Text = area.ToString("F2");
            }
            catch
            {
                MessageBox.Show("Verifica que base y altura sean valores numéricos válidos.");
            }
        }

        private void btnCalcularPerimetro_Click(object sender, EventArgs e)
        {
            try
            {
                double b = double.Parse(txtBase.Text);
                double h = double.Parse(txtAltura.Text);
                double perimetro = 2 * (b + h);
                txtPerimetro.Text = perimetro.ToString("F2");
            }
            catch
            {
                MessageBox.Show("Verifica que base y altura sean valores numéricos válidos.");
            }
        }
    }
}
