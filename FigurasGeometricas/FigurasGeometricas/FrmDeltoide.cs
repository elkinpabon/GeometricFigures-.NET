using System;
using System.Drawing;
using System.Windows.Forms;

namespace FigurasGeometricas
{
    public partial class FrmDeltoide : Form
    {
        private TextBox txtDiagonalMayor, txtDiagonalMenor, txtLadoCorto, txtLadoLargo, txtArea, txtPerimetro;
        private PictureBox picDeltoide;
        private Button btnCalcularArea, btnCalcularPerimetro;

        public FrmDeltoide()
        {
            this.Text = "Deltoide (Cometa)";
            this.Size = new Size(570, 420);
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
            btn.BackColor = Color.FromArgb(63, 81, 181); // azul índigo
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

            Label lblD = new Label() { Text = "Diagonal mayor (D):", Location = new Point(labelX, startY) };
            txtDiagonalMayor = new TextBox() { Location = new Point(textBoxX, startY), Width = widthBox };

            Label lbld = new Label() { Text = "Diagonal menor (d):", Location = new Point(labelX, startY + spacingY) };
            txtDiagonalMenor = new TextBox() { Location = new Point(textBoxX, startY + spacingY), Width = widthBox };

            Label lblL1 = new Label() { Text = "Lado corto (L1):", Location = new Point(labelX, startY + spacingY * 2) };
            txtLadoCorto = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 2), Width = widthBox };

            Label lblL2 = new Label() { Text = "Lado largo (L2):", Location = new Point(labelX, startY + spacingY * 3) };
            txtLadoLargo = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 3), Width = widthBox };

            btnCalcularArea = new Button() { Text = "Calcular Área", Location = new Point(textBoxX, startY + spacingY * 4) };
            btnCalcularArea.Click += btnCalcularArea_Click;
            EstilizarBoton(btnCalcularArea);

            btnCalcularPerimetro = new Button() { Text = "Calcular Perímetro", Location = new Point(textBoxX, startY + spacingY * 5) };
            btnCalcularPerimetro.Click += btnCalcularPerimetro_Click;
            EstilizarBoton(btnCalcularPerimetro);

            Label lblArea = new Label() { Text = "Área:", Location = new Point(labelX, startY + spacingY * 6) };
            txtArea = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 6), Width = widthBox, ReadOnly = true };

            Label lblPerimetro = new Label() { Text = "Perímetro:", Location = new Point(labelX, startY + spacingY * 7) };
            txtPerimetro = new TextBox() { Location = new Point(textBoxX, startY + spacingY * 7), Width = widthBox, ReadOnly = true };

            foreach (var caja in new[] { txtDiagonalMayor, txtDiagonalMenor, txtLadoCorto, txtLadoLargo, txtArea, txtPerimetro })
                EstilizarCaja(caja);

            picDeltoide = new PictureBox()
            {
                Location = new Point(360, 30),
                Size = new Size(180, 180),
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };

            try
            {
                picDeltoide.Image = Image.FromFile("imagenes/deltoide.png");
            }
            catch
            {
                picDeltoide.BackColor = Color.LightGray;
            }

            this.Controls.AddRange(new Control[]
            {
                lblD, txtDiagonalMayor,
                lbld, txtDiagonalMenor,
                lblL1, txtLadoCorto,
                lblL2, txtLadoLargo,
                btnCalcularArea, btnCalcularPerimetro,
                lblArea, txtArea,
                lblPerimetro, txtPerimetro,
                picDeltoide
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
                MessageBox.Show("Verifica que las diagonales sean números válidos.");
            }
        }

        private void btnCalcularPerimetro_Click(object sender, EventArgs e)
        {
            try
            {
                double L1 = double.Parse(txtLadoCorto.Text);
                double L2 = double.Parse(txtLadoLargo.Text);
                double perimetro = 2 * (L1 + L2);
                txtPerimetro.Text = perimetro.ToString("F2");
            }
            catch
            {
                MessageBox.Show("Verifica que los lados sean números válidos.");
            }
        }
    }
}
