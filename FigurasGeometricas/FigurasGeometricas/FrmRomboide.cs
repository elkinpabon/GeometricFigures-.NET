using System;
using System.Drawing;
using System.Windows.Forms;

namespace FigurasGeometricas
{
    public partial class FrmRomboide : Form
    {
        private TextBox txtBase, txtAltura, txtLado, txtArea, txtPerimetro;
        private PictureBox picRomboide;
        private Button btnCalcularArea, btnCalcularPerimetro;

        public FrmRomboide()
        {
            this.Text = "Romboide";
            this.Size = new Size(550, 380);
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
            btn.BackColor = Color.FromArgb(139, 195, 74); // verde claro
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
            int labelX = 30, textBoxX = 170, spacingY = 35, startY = 20, widthBox = 140;

            Label lblBase = new Label() { Text = "Base:", Location = new Point(labelX, startY) };
            txtBase = new TextBox() { Location = new Point(textBoxX, startY), Width = widthBox };

            Label lblAltura = new Label() { Text = "Altura:", Location = new Point(labelX, startY + spacingY) };
            txtAltura = new TextBox() { Location = new Point(textBoxX, startY + spacingY), Width = widthBox };

            Label lblLado = new Label() { Text = "Lado:", Location = new Point(labelX, startY + spacingY * 2) };
            txtLado = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 2), Width = widthBox };

            btnCalcularArea = new Button() { Text = "Calcular Área", Location = new Point(textBoxX, startY + spacingY * 3) };
            btnCalcularArea.Click += btnCalcularArea_Click;
            EstilizarBoton(btnCalcularArea);

            btnCalcularPerimetro = new Button() { Text = "Calcular Perímetro", Location = new Point(textBoxX, startY + spacingY * 4) };
            btnCalcularPerimetro.Click += btnCalcularPerimetro_Click;
            EstilizarBoton(btnCalcularPerimetro);

            Label lblArea = new Label() { Text = "Área:", Location = new Point(labelX, startY + spacingY * 5) };
            txtArea = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 5), Width = widthBox, ReadOnly = true };

            Label lblPerimetro = new Label() { Text = "Perímetro:", Location = new Point(labelX, startY + spacingY * 6) };
            txtPerimetro = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 6), Width = widthBox, ReadOnly = true };

            foreach (var caja in new[] { txtBase, txtAltura, txtLado, txtArea, txtPerimetro })
                EstilizarCaja(caja);

            picRomboide = new PictureBox()
            {
                Location = new Point(340, 30),
                Size = new Size(180, 180),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };

            try
            {
                picRomboide.Image = Image.FromFile("imagenes/romboide.png");
            }
            catch
            {
                picRomboide.BackColor = Color.LightGray;
            }

            this.Controls.AddRange(new Control[]
            {
                lblBase, txtBase,
                lblAltura, txtAltura,
                lblLado, txtLado,
                btnCalcularArea, btnCalcularPerimetro,
                lblArea, txtArea,
                lblPerimetro, txtPerimetro,
                picRomboide
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
                MessageBox.Show("Verifica que base y altura sean números válidos.");
            }
        }

        private void btnCalcularPerimetro_Click(object sender, EventArgs e)
        {
            try
            {
                double b = double.Parse(txtBase.Text);
                double l = double.Parse(txtLado.Text);
                double perimetro = 2 * (b + l);
                txtPerimetro.Text = perimetro.ToString("F2");
            }
            catch
            {
                MessageBox.Show("Verifica que base y lado sean números válidos.");
            }
        }
    }
}
