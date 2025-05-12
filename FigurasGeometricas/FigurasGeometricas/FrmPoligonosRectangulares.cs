using System;
using System.Drawing;
using System.Windows.Forms;

namespace FigurasGeometricas
{
    public partial class FrmPoligonosRectangulares : Form
    {
        private TextBox txtNumLados, txtLongitudLado, txtApotema, txtArea, txtPerimetro;
        private PictureBox picPoligono;
        private Button btnCalcularArea, btnCalcularPerimetro;

        public FrmPoligonosRectangulares()
        {
            this.Text = "Polígonos Regulares";
            this.Size = new Size(570, 410);
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
            btn.BackColor = Color.FromArgb(0, 150, 136); // verde azulado
            btn.ForeColor = Color.White;
            btn.FlatAppearance.BorderSize = 0;
            btn.Height = 30;
            btn.Width = 160;
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
            int labelX = 30, textBoxX = 190, spacingY = 35, startY = 20, widthBox = 140;

            Label lblN = new Label() { Text = "Lados (n):", Location = new Point(labelX, startY) };
            txtNumLados = new TextBox() { Location = new Point(textBoxX, startY), Width = widthBox };

            Label lblL = new Label() { Text = "Longitud (l):", Location = new Point(labelX, startY + spacingY) };
            txtLongitudLado = new TextBox() { Location = new Point(textBoxX, startY + spacingY), Width = widthBox };

            Label lblA = new Label() { Text = "Apotema (a):", Location = new Point(labelX, startY + spacingY * 2) };
            txtApotema = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 2), Width = widthBox };

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

            foreach (var caja in new[] { txtNumLados, txtLongitudLado, txtApotema, txtArea, txtPerimetro })
                EstilizarCaja(caja);

            picPoligono = new PictureBox()
            {
                Location = new Point(360, 30),
                Size = new Size(180, 180),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };

            try
            {
                picPoligono.Image = Image.FromFile("imagenes/poligono.png");
            }
            catch
            {
                picPoligono.BackColor = Color.LightGray;
            }

            this.Controls.AddRange(new Control[]
            {
                lblN, txtNumLados,
                lblL, txtLongitudLado,
                lblA, txtApotema,
                btnCalcularArea, btnCalcularPerimetro,
                lblArea, txtArea,
                lblPerimetro, txtPerimetro,
                picPoligono
            });
        }

        private void btnCalcularArea_Click(object sender, EventArgs e)
        {
            try
            {
                int n = int.Parse(txtNumLados.Text);
                double l = double.Parse(txtLongitudLado.Text);
                double a = double.Parse(txtApotema.Text);

                double area = (n * l * a) / 2;
                txtArea.Text = area.ToString("F2");
            }
            catch
            {
                MessageBox.Show("Verifica que n, l y a sean valores numéricos válidos.");
            }
        }

        private void btnCalcularPerimetro_Click(object sender, EventArgs e)
        {
            try
            {
                int n = int.Parse(txtNumLados.Text);
                double l = double.Parse(txtLongitudLado.Text);

                double perimetro = n * l;
                txtPerimetro.Text = perimetro.ToString("F2");
            }
            catch
            {
                MessageBox.Show("Verifica que n y l sean valores numéricos válidos.");
            }
        }
    }
}
