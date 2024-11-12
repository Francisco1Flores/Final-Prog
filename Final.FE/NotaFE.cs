using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final.FE
{
    public class NotaFE : Panel
    {
        private frmPrincipal frmVentanaPrincipal;

        private const int Ancho = 160;
        private const int Alto = 152;

        public Label lblTitulo { get; set; }
        public Label lblTexto { get; set; }
        public Label lblFechaHora { get; set; }

        public NotaFE(string Titulo, string Texto, string fechaHora, frmPrincipal frmPadre)
        {
            this.frmVentanaPrincipal = frmPadre;

            EventHandler NotaClick = new EventHandler(this.AbrirNotaClick);

            this.Click += NotaClick;

            this.Height = Ancho;
            this.Width = Alto;
            this.Margin = new Padding(20);

            this.Cursor = Cursors.Hand;

            this.lblTitulo = new Label();
            this.lblTexto = new Label();
            this.lblFechaHora = new Label();

            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblTexto);
            this.Controls.Add(this.lblFechaHora);

            //lblTitulo
            this.lblTitulo.Text = Titulo;
            this.lblTitulo.Width = Ancho;
            this.lblTitulo.Height = 20;
            this.lblTitulo.Top = 0;
            this.lblTitulo.Left = 0;
            this.lblTitulo.Visible = true;
            this.lblTitulo.Enabled = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Khaki;
            this.lblTitulo.Click += NotaClick;

            //lblTexto
            this.lblTexto.Text = Texto;
            this.lblTexto.Width = Ancho;
            this.lblTexto.Height = 104;
            this.lblTexto.Top = 0 + this.lblTitulo.Height + 11;
            this.lblTexto.Left = 0;
            this.lblTexto.Visible = true;
            this.lblTexto.Enabled = true;
            this.lblTexto.BackColor = System.Drawing.Color.Khaki;
            this.lblTexto.Click += NotaClick;

            //lblFechaHora            
            this.lblFechaHora.Text = fechaHora;
            this.lblFechaHora.Width = Ancho;
            this.lblFechaHora.Height = 17;
            this.lblFechaHora.Top = 0 + this.lblTitulo.Height + 11 + this.lblTexto.Height;
            this.lblFechaHora.Visible = true;
            this.lblFechaHora.Enabled = true;
            this.lblFechaHora.BackColor = System.Drawing.Color.Khaki;
            this.lblFechaHora.Click += NotaClick;

            this.Visible = true;
            this.Enabled = true;
        }

        public NotaFE(BA.Nota nota, frmPrincipal frmPrincipal) : this(nota.Titulo, nota.Texto, nota.FechaHora, frmPrincipal)
        { }

        public void Actualizar(string Titulo, string Texto)
        {
            this.lblTitulo.Text = Titulo;
            this.lblTexto.Text = Texto;
            this.lblFechaHora.Text = "Mod " + DateTime.Now.ToString();
        }

        public void AbrirNotaClick(object sender, EventArgs e)
        {
            frmVentanaPrincipal.AbrirNotaSeleccionada(this);
        }
    }
}
