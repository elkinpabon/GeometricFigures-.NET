using System;
using System.Drawing;
using System.Windows.Forms;

namespace FigurasGeometricas
{
    public partial class FrmTriangulo : Form
    {
        private TextBox txtBase, txtAltura, txtLado1, txtLado2, txtLado3, txtArea, txtPerimetro;
        private PictureBox picTriangulo;
        private Button btnCalcularArea, btnCalcularPerimetro;

        public FrmTriangulo()
        {
            this.Text = "Triángulo";
            this.Size = new Size(580, 470);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            this.Font = new Font("Poppins", 9, FontStyle.Regular);
            this.BackColor = Color.FromArgb(240, 244, 248); // azul claro suave

            InicializarControles();
        }

        private void EstilizarBoton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.FromArgb(33, 150, 243); // azul material
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

            Label lblLado1 = new Label() { Text = "Lado A:", Location = new Point(labelX, startY + spacingY * 2) };
            txtLado1 = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 2), Width = widthBox };

            Label lblLado2 = new Label() { Text = "Lado B:", Location = new Point(labelX, startY + spacingY * 3) };
            txtLado2 = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 3), Width = widthBox };

            Label lblLado3 = new Label() { Text = "Lado C:", Location = new Point(labelX, startY + spacingY * 4) };
            txtLado3 = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 4), Width = widthBox };

            btnCalcularArea = new Button() { Text = "Área", Location = new Point(textBoxX, startY + spacingY * 5) };
            btnCalcularArea.Click += btnCalcularArea_Click;
            EstilizarBoton(btnCalcularArea);

            btnCalcularPerimetro = new Button() { Text = "Perímetro", Location = new Point(textBoxX, startY + spacingY * 6) };
            btnCalcularPerimetro.Click += btnCalcularPerimetro_Click;
            EstilizarBoton(btnCalcularPerimetro);

            Label lblArea = new Label() { Text = "Área:", Location = new Point(labelX, startY + spacingY * 7) };
            txtArea = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 7), Width = widthBox, ReadOnly = true };

            Label lblPerimetro = new Label() { Text = "Perímetro:", Location = new Point(labelX, startY + spacingY * 8) };
            txtPerimetro = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 8), Width = widthBox, ReadOnly = true };

            foreach (var caja in new[] { txtBase, txtAltura, txtLado1, txtLado2, txtLado3, txtArea, txtPerimetro })
                EstilizarCaja(caja);

            picTriangulo = new PictureBox()
            {
                Location = new Point(340, 30),
                Size = new Size(200, 200),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };

            try
            {
                picTriangulo.Image = Image.FromFile("imagenes/triangulo.png");
            }
            catch
            {
                picTriangulo.BackColor = Color.LightGray;
            }

            this.Controls.AddRange(new Control[]
            {
                lblBase, txtBase, lblAltura, txtAltura,
                lblLado1, txtLado1, lblLado2, txtLado2,
                lblLado3, txtLado3, btnCalcularArea, btnCalcularPerimetro,
                lblArea, txtArea, lblPerimetro, txtPerimetro,
                picTriangulo
            });
        }

        private void btnCalcularArea_Click(object sender, EventArgs e)
        {
            try
            {
                double b = double.Parse(txtBase.Text);
                double h = double.Parse(txtAltura.Text);
                double area = (b * h) / 2;
                txtArea.Text = area.ToString("F2");
            }
            catch
            {
                MessageBox.Show("Verifica que base y altura sean numéricos válidos.");
            }
        }

        private void btnCalcularPerimetro_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(txtLado1.Text);
                double b = double.Parse(txtLado2.Text);
                double c = double.Parse(txtLado3.Text);
                double perimetro = a + b + c;
                txtPerimetro.Text = perimetro.ToString("F2");
            }
            catch
            {
                MessageBox.Show("Verifica que los lados sean numéricos válidos.");
            }
        }
    }
}
