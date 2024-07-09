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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Length == 0 || txtSenha.Text.Length == 0 || rbAluno.Checked == false && rbProfessor.Checked == false)
            {
                MessageBox.Show("PREENCHA TODOS OS CAMPOS", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (rbAluno.Checked == true)
                {
                   //Como não há um banco de dados, não temos como manter as informações da ficha do aluno. Mas as mesmas foram inseridas pelo FRMProfessor.
                }
                else if (rbProfessor.Checked == true)
                {
                    FrmProfessor frProfessor = new FrmProfessor();
                    frProfessor.Show();
                    this.Hide();
                }
            }
        }
    }
}
