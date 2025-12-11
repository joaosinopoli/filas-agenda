namespace AgendaWinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.dtpNascimento = new System.Windows.Forms.DateTimePicker();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.chkPrincipal = new System.Windows.Forms.CheckBox();
            this.lstContatos = new System.Windows.Forms.ListBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(12, 12);
            this.txtNome.PlaceholderText = "Nome";
            this.txtNome.Size = new System.Drawing.Size(200, 23);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 41);
            this.txtEmail.PlaceholderText = "Email";
            this.txtEmail.Size = new System.Drawing.Size(200, 23);
            // 
            // dtpNascimento
            // 
            this.dtpNascimento.Location = new System.Drawing.Point(12, 70);
            this.dtpNascimento.Size = new System.Drawing.Size(200, 23);
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(12, 99);
            this.txtTipo.PlaceholderText = "Tipo de telefone";
            this.txtTipo.Size = new System.Drawing.Size(200, 23);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(12, 128);
            this.txtNumero.PlaceholderText = "Número";
            this.txtNumero.Size = new System.Drawing.Size(200, 23);
            // 
            // chkPrincipal
            // 
            this.chkPrincipal.Location = new System.Drawing.Point(12, 157);
            this.chkPrincipal.Text = "Principal";
            // 
            // lstContatos
            // 
            this.lstContatos.Location = new System.Drawing.Point(230, 12);
            this.lstContatos.Size = new System.Drawing.Size(300, 200);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(12, 190);
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(100, 190);
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(190, 190);
            this.btnRemover.Text = "Remover";
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(550, 250);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.dtpNascimento);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.chkPrincipal);
            this.Controls.Add(this.lstContatos);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnRemover);
            this.Name = "Form1";
            this.Text = "Agenda WinForms";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.DateTimePicker dtpNascimento;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.CheckBox chkPrincipal;
        private System.Windows.Forms.ListBox lstContatos;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnRemover;
    }
}