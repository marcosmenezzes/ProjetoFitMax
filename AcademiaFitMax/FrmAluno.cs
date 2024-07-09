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
    public partial class FrmAluno : Form
    {
        public FrmAluno()
        {
            InitializeComponent();
        }

        private void FrmAluno_Load(object sender, EventArgs e)
        {
            //Preenchendo a interface com informações vindas de outro formulário
            lbNome.Text = FrmProfessor.Medidas.Nome;
            lbSexo.Text = FrmProfessor.Medidas.Sexo;
            lbIdade.Text = FrmProfessor.Medidas.Idade;
            lbAltura.Text = FrmProfessor.Medidas.Altura;
            lbPeso.Text = FrmProfessor.Medidas.Peso;
            lbAbdome.Text = FrmProfessor.Medidas.Abdome;

            // Entrada de dados
            double peso = double.Parse(lbPeso.Text); // Peso em kg
            double alturaCm = double.Parse(lbAltura.Text); // Altura em cm
            double alturaM = alturaCm / 100; // Convertendo altura para metros
            double imc = peso / (alturaM * alturaM);
            lbImc.Text = imc.ToString("N2");

            // Classificação do IMC
            if (imc < 18.5)
            {
                lbClassificacao.Text = "Abaixo do Peso";
            }
            else if (imc >= 18.5 && imc <= 24.9)
            {
                lbClassificacao.Text = "Peso Normal";
                picPNormal.Visible = true;
            }
            else if (imc >= 25 && imc <= 29.9)
            {
                lbClassificacao.Text = "Sobrepeso";
                picSobrepeso.Visible = true;
            }
            else
            {
                lbClassificacao.Text = "Obesidade";
                picObesidade.Visible = true;
            }

            //Cálculo de gordura corporal 
            int idade = int.Parse(lbIdade.Text);
            double gorduraCorporal = 0;

            if (lbSexo.Text == "Feminino")
            {
                // Calculando a gordura corporal para o gênero feminino
                gorduraCorporal = 1.2 * imc + 0.23 * idade - 5.4;
                lbGordura.Text = gorduraCorporal.ToString("N2") + "%";
            }
            else if (lbSexo.Text == "Masculino")
            {
                // Calculando a gordura corporal para o gênero masculino
                gorduraCorporal = 1.2 * imc + 0.23 * idade - 10.8 - 5.4;
                lbGordura.Text = gorduraCorporal.ToString("N2") + "%";
            }
              
            // Cálculo do peso ideal usando a fórmula de Lorentz
            double pesoIdeal;
            if (lbSexo.Text.ToLower() == "feminino")
            {
                pesoIdeal = (62.1 * alturaM) - 44.7;
            }
            else if (lbSexo.Text.ToLower() == "masculino")
            {
                pesoIdeal = (72.7 * alturaM) - 58;
            }
            else
            {
                lbPesoIdeal.Text = "Gênero não reconhecido";
                return;
            }

            lbPesoIdeal.Text = pesoIdeal.ToString("N2")+ "Kg";

            // Calcular a Taxa Metabólica Basal (TMB) usando a fórmula de Harris-Benedict
            double tmb;
            if (lbSexo.Text.ToLower() == "feminino")
            {
                tmb = 655 + (9.6 * peso) + (1.8 * alturaCm) - (4.7 * idade);
            }
            else if (lbSexo.Text.ToLower() == "masculino")
            {
                tmb = 66 + (13.7 * peso) + (5 * alturaCm) - (6.8 * idade);
            }
            else
            {
                lbCalorias.Text = "Gênero não reconhecido";
                return;
            }

            // Ajustar a TMB com base no nível de atividade física
            double nivelAtividade = FrmProfessor.Medidas.NivelAtividade; // Exemplo de nível de atividade moderada
            double caloriasDiarias = tmb * nivelAtividade;
            lbCalorias.Text = caloriasDiarias.ToString("N2")+ " cal recomendadas";
        }

        private void btnGambiarra_Click(object sender, EventArgs e)
        {
            //Como não possuo conhecimento em banco de dados ainda, para melhor explicação do app esse botão retorna ao frmProfessor para a demonstração de novos cálculos sem precisar passar pela tela de login
            FrmProfessor frProfessor = new FrmProfessor();
            frProfessor.Show();
            this.Hide();
        }
    }
}
