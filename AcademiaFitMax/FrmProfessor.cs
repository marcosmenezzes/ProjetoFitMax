using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademiaFitMax
{
    public partial class FrmProfessor : Form
    {
        double nivelAtividade = 0;

        public FrmProfessor()
        {
            InitializeComponent();
            LimitarTextBoxesParaNumeros();
        }

        //Dados das Medidas para serem passados a outro formulário
        public static class Medidas
        {
            public static string Nome = "";
            public static string Idade = "";
            public static string Sexo = "";
            public static string Altura = "";
            public static string Peso = "";
            public static string Abdome = "";
            public static double NivelAtividade = 0;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            LimitarTextBoxesParaNumeros();

            //Verificar se há campos vazios no formulário
            if (txtNome.Text.Length == 0 || txtIdade.Text.Length == 0 || txtAltura.Text.Length == 0 || txtPeso.Text.Length == 0 || txtAbdome.Text.Length == 0 || rbFeminino.Checked == false && rbMasculino.Checked == false)
            {
                MessageBox.Show("PREENCHA TODOS OS CAMPOS", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Preenchendo os dados 
                Medidas.Nome = txtNome.Text;
                Medidas.Idade = txtIdade.Text;
                Medidas.Altura = txtAltura.Text;
                Medidas.Peso = txtPeso.Text;
                Medidas.Abdome = txtAbdome.Text;

                //Condição para verificar se o sexo do aluno cadastrado é fem ou masc
                if (rbFeminino.Checked == true)
                {
                    Medidas.Sexo = "Feminino";
                }
                else if (rbMasculino.Checked == true)
                {
                    Medidas.Sexo = "Masculino";
                }

                //Acrescentar valor de acordo com o nivel de atividade
                if (cbNivelAtividade.Text == "Sedentário")
                {
                    nivelAtividade = 1.2;
                }
                else
                {
                    if (cbNivelAtividade.Text == "Levemente Ativo")
                    {
                        nivelAtividade = 1.375;
                    }
                    else
                    {
                        if (cbNivelAtividade.Text == "Moderadamente Ativo")
                        {
                            nivelAtividade = 1.55;
                        }
                        else
                        {
                            if (cbNivelAtividade.Text == "Muito Ativo")
                            {
                                nivelAtividade = 1.725;
                            }
                            else
                            {
                                nivelAtividade = 1.9;
                            }
                        }
                    }
                }

                //Adiciona a informação a ser passada para o outro formulário
                Medidas.NivelAtividade = nivelAtividade;

                //Como não há um banco de dados, não temos como manter as informações da ficha do aluno entrando pelo login do mesmo
                //Para mostrarmos a ideia, vinculamos este formulário para já mostrar como seria a página do aluno.
                FrmAluno frAluno = new FrmAluno();
                frAluno.Show();
                this.Hide();
            }

        }

        private void FrmProfessor_Load(object sender, EventArgs e)
        {
            cbNivelAtividade.Items.Add("Sedentário");
            cbNivelAtividade.Items.Add("Levemente Ativo");
            cbNivelAtividade.Items.Add("Moderadamente Ativo");
            cbNivelAtividade.Items.Add("Muito Ativo");
            cbNivelAtividade.Items.Add("Extremamente Ativo");

        }

        //Método para as txt aceitarem apenas números
        public void LimitarTextBoxesParaNumeros()
        {
            txtAltura.KeyPress += textBox_KeyPress;
            txtPeso.KeyPress += textBox_KeyPress;
            txtIdade.KeyPress += textBox_KeyPress;
            txtAbdome.KeyPress += textBox_KeyPress;
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica se a tecla pressionada não é um número ou uma tecla de controle
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                // Cancela o evento de pressionar tecla
                e.Handled = true;
            }

            //Permitir somente a vírgula
            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(","))
            {
                //Cancelar a entrada se já jouver uma vírgula na txt
                e.Handled = true;
            }
        }
    }
}
