using System;
using System.Drawing;
using System.Windows.Forms;

namespace FigurasGeometricas
{
    public partial class FrmTrapecio : Form
    {
        private TextBox txtBaseMayor, txtBaseMenor, txtAltura, txtLado1, txtLado2, txtArea, txtPerimetro;
        private PictureBox picTrapecio;
        private Button btnCalcularArea, btnCalcularPerimetro;

        public FrmTrapecio()
        {
            this.Text = "Trapecio";
            this.Size = new Size(580, 430);
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
            btn.BackColor = Color.FromArgb(255, 152, 0); // naranja ámbar
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
            int labelX = 30, textBoxX = 180, spacingY = 35, startY = 20, widthBox = 140;

            Label lblBaseMayor = new Label() { Text = "Base Mayor (B):", Location = new Point(labelX, startY) };
            txtBaseMayor = new TextBox() { Location = new Point(textBoxX, startY), Width = widthBox };

            Label lblBaseMenor = new Label() { Text = "Base Menor (b):", Location = new Point(labelX, startY + spacingY) };
            txtBaseMenor = new TextBox() { Location = new Point(textBoxX, startY + spacingY), Width = widthBox };

            Label lblAltura = new Label() { Text = "Altura (h):", Location = new Point(labelX, startY + spacingY * 2) };
            txtAltura = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 2), Width = widthBox };

            Label lblLado1 = new Label() { Text = "Lado 1:", Location = new Point(labelX, startY + spacingY * 3) };
            txtLado1 = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 3), Width = widthBox };

            Label lblLado2 = new Label() { Text = "Lado 2:", Location = new Point(labelX, startY + spacingY * 4) };
            txtLado2 = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 4), Width = widthBox };

            btnCalcularArea = new Button() { Text = "Calcular Área", Location = new Point(textBoxX, startY + spacingY * 5) };
            btnCalcularArea.Click += btnCalcularArea_Click;
            EstilizarBoton(btnCalcularArea);

            btnCalcularPerimetro = new Button() { Text = "Calcular Perímetro", Location = new Point(textBoxX, startY + spacingY * 6) };
            btnCalcularPerimetro.Click += btnCalcularPerimetro_Click;
            EstilizarBoton(btnCalcularPerimetro);

            Label lblArea = new Label() { Text = "Área:", Location = new Point(labelX, startY + spacingY * 7) };
            txtArea = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 7), Width = widthBox, ReadOnly = true };

            Label lblPerimetro = new Label() { Text = "Perímetro:", Location = new Point(labelX, startY + spacingY * 8) };
            txtPerimetro = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 8), Width = widthBox, ReadOnly = true };

            foreach (var caja in new[] { txtBaseMayor, txtBaseMenor, txtAltura, txtLado1, txtLado2, txtArea, txtPerimetro })
                EstilizarCaja(caja);

            picTrapecio = new PictureBox()
            {
                Location = new Point(360, 30),
                Size = new Size(180, 180),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };

            try
            {
                picTrapecio.Image = Image.FromFile("imagenes/trapecio.png");
            }
            catch
            {
                picTrapecio.BackColor = Color.LightGray;
            }

            this.Controls.AddRange(new Control[]
            {
                lblBaseMayor, txtBaseMayor,
                lblBaseMenor, txtBaseMenor,
                lblAltura, txtAltura,
                lblLado1, txtLado1,
                lblLado2, txtLado2,
                btnCalcularArea, btnCalcularPerimetro,
                lblArea, txtArea,
                lblPerimetro, txtPerimetro,
                picTrapecio
            });
        }

        private void btnCalcularArea_Click(object sender, EventArgs e)
        {
            try
            {
                double B = double.Parse(txtBaseMayor.Text);
                double b = double.Parse(txtBaseMenor.Text);
                double h = double.Parse(txtAltura.Text);
                double area = ((B + b) * h) / 2;
                txtArea.Text = area.ToString("F2");
            }
            catch
            {
                MessageBox.Show("Verifica que las bases y la altura sean numéricos válidos.");
            }
        }

        private void btnCalcularPerimetro_Click(object sender, EventArgs e)
        {
            try
            {
                double B = double.Parse(txtBaseMayor.Text);
                double b = double.Parse(txtBaseMenor.Text);
                double l1 = double.Parse(txtLado1.Text);
                double l2 = double.Parse(txtLado2.Text);
                double perimetro = B + b + l1 + l2;
                txtPerimetro.Text = perimetro.ToString("F2");
            }
            catch
            {
                MessageBox.Show("Verifica que todos los lados sean numéricos válidos.");
            }
        }
    }
}
