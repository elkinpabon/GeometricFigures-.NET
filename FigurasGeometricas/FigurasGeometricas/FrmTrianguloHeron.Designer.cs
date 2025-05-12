namespace FigurasGeometricas
{
    partial class FrmTrianguloHeron
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFormula;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Label lblS;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.TextBox txtLadoA;
        private System.Windows.Forms.TextBox txtLadoB;
        private System.Windows.Forms.TextBox txtLadoC;
        private System.Windows.Forms.TextBox txtSemiperimetro;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.PictureBox picTriangulo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFormula = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblC = new System.Windows.Forms.Label();
            this.lblS = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.txtLadoA = new System.Windows.Forms.TextBox();
            this.txtLadoB = new System.Windows.Forms.TextBox();
            this.txtLadoC = new System.Windows.Forms.TextBox();
            this.txtSemiperimetro = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.picTriangulo = new System.Windows.Forms.PictureBox();

            ((System.ComponentModel.ISupportInitialize)(this.picTriangulo)).BeginInit();
            this.SuspendLayout();

            this.ClientSize = new System.Drawing.Size(620, 400);
            this.Font = new System.Drawing.Font("Poppins", 9F);
            this.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Área de Triángulo con Fórmula de Herón";

            this.lblTitulo.Text = "Fórmula de Herón";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(30, 10);
            this.lblTitulo.AutoSize = true;

            this.lblFormula.Text = "A = √[s(s - a)(s - b)(s - c)],  donde  s = (a + b + c) / 2";
            this.lblFormula.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblFormula.Location = new System.Drawing.Point(30, 35);
            this.lblFormula.AutoSize = true;

            this.lblA.Text = "Lado A:";
            this.lblA.Location = new System.Drawing.Point(30, 80);
            this.lblA.AutoSize = true;
            this.txtLadoA.Location = new System.Drawing.Point(180, 80);
            this.txtLadoA.Width = 140;

            this.lblB.Text = "Lado B:";
            this.lblB.Location = new System.Drawing.Point(30, 115);
            this.lblB.AutoSize = true;
            this.txtLadoB.Location = new System.Drawing.Point(180, 115);
            this.txtLadoB.Width = 140;

            this.lblC.Text = "Lado C:";
            this.lblC.Location = new System.Drawing.Point(30, 150);
            this.lblC.AutoSize = true;
            this.txtLadoC.Location = new System.Drawing.Point(180, 150);
            this.txtLadoC.Width = 140;

            this.btnCalcular.Text = "Calcular Área";
            this.btnCalcular.Location = new System.Drawing.Point(180, 185);
            this.btnCalcular.Size = new System.Drawing.Size(140, 30);
            this.btnCalcular.BackColor = System.Drawing.Color.FromArgb(255, 87, 34);
            this.btnCalcular.ForeColor = System.Drawing.Color.White;
            this.btnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcular.FlatAppearance.BorderSize = 0;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);

            this.lblS.Text = "Semiperímetro (s):";
            this.lblS.Location = new System.Drawing.Point(30, 230);
            this.lblS.AutoSize = true;
            this.txtSemiperimetro.Location = new System.Drawing.Point(180, 230);
            this.txtSemiperimetro.Width = 140;
            this.txtSemiperimetro.ReadOnly = true;

            this.lblArea.Text = "Área:";
            this.lblArea.Location = new System.Drawing.Point(30, 270);
            this.lblArea.AutoSize = true;
            this.txtArea.Location = new System.Drawing.Point(180, 270);
            this.txtArea.Width = 140;
            this.txtArea.ReadOnly = true;

            this.picTriangulo.Location = new System.Drawing.Point(360, 40);
            this.picTriangulo.Size = new System.Drawing.Size(230, 230);
            this.picTriangulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTriangulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTriangulo.BackColor = System.Drawing.Color.White;

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblFormula);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.txtLadoA);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.txtLadoB);
            this.Controls.Add(this.lblC);
            this.Controls.Add(this.txtLadoC);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.lblS);
            this.Controls.Add(this.txtSemiperimetro);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.picTriangulo);

            ((System.ComponentModel.ISupportInitialize)(this.picTriangulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
