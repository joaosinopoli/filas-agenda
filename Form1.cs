using System;
using System.Windows.Forms;
using AgendaWinForms.Models;

namespace AgendaWinForms
{
    public partial class Form1 : Form
    {
        private Contatos agenda = new Contatos();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text;
                string email = txtEmail.Text;
                DateTime dt = dtpNascimento.Value;

                Contato novo = new Contato(nome, email, new Data(dt.Day, dt.Month, dt.Year));

                string tipo = txtTipo.Text;
                string numero = txtNumero.Text;
                bool principal = chkPrincipal.Checked;
                if (!string.IsNullOrWhiteSpace(numero))
                    novo.adicionarTelefone(new Telefone(tipo, numero, principal));

                if (agenda.adicionar(novo))
                {
                    MessageBox.Show("Contato adicionado!");
                    AtualizarLista();
                }
                else
                {
                    MessageBox.Show("Já existe contato com esse email.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            Contato c = agenda.pesquisar(new Contato("", email, new Data(1, 1, 1900)));
            if (c != null)
                MessageBox.Show(c.ToString());
            else
                MessageBox.Show("Contato não encontrado.");
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            if (agenda.remover(new Contato("", email, new Data(1, 1, 1900))))
            {
                MessageBox.Show("Contato removido.");
                AtualizarLista();
            }
            else
            {
                MessageBox.Show("Contato não encontrado.");
            }
        }

        private void AtualizarLista()
        {
            lstContatos.Items.Clear();
            foreach (var c in agenda.Agenda)
            {
                lstContatos.Items.Add($"{c.Nome} - {c.Email} - {c.getTelefonePrincipal()}");
            }
        }
    }
}