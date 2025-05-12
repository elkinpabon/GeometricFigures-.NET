using System;
using System.Drawing;
using System.Windows.Forms;

namespace FigurasGeometricas
{
    public partial class FrmTrianguloHeron : Form
    {
        public FrmTrianguloHeron()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                double a = double.Parse(txtLadoA.Text);
                double b = double.Parse(txtLadoB.Text);
                double c = double.Parse(txtLadoC.Text);

                if (a + b > c && a + c > b && b + c > a)
                {
                    double s = (a + b + c) / 2;
                    double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

                    txtSemiperimetro.Text = s.ToString("F2");
                    txtArea.Text = area.ToString("F2");

                    DibujarTriangulo(a, b, c);
                }
                else
                {
                    MessageBox.Show("Los lados ingresados no forman un triángulo válido.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    picTriangulo.Image = null;
                }
            }
            catch
            {
                MessageBox.Show("Verifica que todos los lados sean números válidos.");
            }
        }

        private void DibujarTriangulo(double a, double b, double c)
        {
            int w = picTriangulo.Width;
            int h = picTriangulo.Height;

            Bitmap bmp = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            // Escala adecuada al tamaño disponible
            double escala = 160.0 / Math.Max(Math.Max(a, b), c);

            // Punto A en origen
            float ax = 0;
            float ay = 0;

            // Punto B a la derecha en eje X
            float bx = ax + (float)(c * escala);
            float by = ay;

            // Punto C calculado usando ángulo con teorema del coseno
            double cosA = (b * b + c * c - a * a) / (2 * b * c);
            double anguloC = Math.Acos((a * a + b * b - c * c) / (2 * a * b));

            float cx = ax + (float)(b * escala * Math.Cos(anguloC));
            float cy = ay - (float)(b * escala * Math.Sin(anguloC));

            // Puntos originales
            PointF A = new PointF(ax, ay);
            PointF B = new PointF(bx, by);
            PointF C = new PointF(cx, cy);

            // Calcular centroide
            float centroX = (A.X + B.X + C.X) / 3;
            float centroY = (A.Y + B.Y + C.Y) / 3;

            // Offset para centrar el gráfico
            float offsetX = w / 2 - centroX;
            float offsetY = h / 2 - centroY;

            // Trasladar puntos
            A = new PointF(A.X + offsetX, A.Y + offsetY);
            B = new PointF(B.X + offsetX, B.Y + offsetY);
            C = new PointF(C.X + offsetX, C.Y + offsetY);

            // Dibujar triángulo
            Pen lapiz = new Pen(Color.DarkBlue, 2);
            Brush relleno = Brushes.LightBlue;
            Font font = new Font("Segoe UI", 9);
            Brush texto = Brushes.Black;

            g.FillPolygon(relleno, new[] { A, B, C });
            g.DrawPolygon(lapiz, new[] { A, B, C });

            // Etiquetas de vértices
            g.DrawString("A", font, texto, A.X - 15, A.Y);
            g.DrawString("B", font, texto, B.X + 5, B.Y);
            g.DrawString("C", font, texto, C.X - 10, C.Y - 15);

            picTriangulo.Image = bmp;
        }

    }
}
