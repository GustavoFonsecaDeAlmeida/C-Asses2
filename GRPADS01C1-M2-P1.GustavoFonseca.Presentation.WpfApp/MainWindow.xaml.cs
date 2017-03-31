using GRPADS01C1_M2_P1.GustavoFonseca.Domain.Entities;
using GRPADS01C1_M2_P1.GustavoFonseca.Infra.Data.Repositories;
using GRPADS01C1_M2_P1.GustavoFonseca.Infra.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GRPADS01C1_M2_P1.GustavoFonseca.Presentation.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly IAlunoRepository _alunoRepository = new AlunoRepository();

        public MainWindow()
        {
            InitializeComponent();
            erroimage.Visibility = Visibility.Hidden;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            var aluno = _alunoRepository.ObterPorMatricula(txtMatricula.Text);
            if (aluno != null)
            {
                preencherTextBlocks(aluno);
                mensagem(aluno.Ativo);
            }
            else
            {
                mensagem();
            }

            tbkMensagem.Visibility = Visibility.Visible;
            



        }


        private void txtMatricula_GotFocus(object sender, RoutedEventArgs e)
        {
            txtMatricula.Text = "";
            tbkMensagem.Visibility = Visibility.Hidden;
            erroimage.Visibility = Visibility.Hidden;
            limparTextBlocks();
        }

        private void preencherTextBlocks(Aluno aluno)
        {
            tbkNome.Text = aluno.Nome;
            tbkMatricula.Text = aluno.Matricula;
            tbkNascimento.Text = String.Format("{0:dd/MM/yyyy}", aluno.Nascimento);
            tbkCPF.Text = aluno.CPF;
        }

        private void limparTextBlocks()
        {
            tbkNome.Text = "";
            tbkMatricula.Text = "";
            tbkNascimento.Text = "";
            tbkCPF.Text = "";
        }

        private void mensagem(bool status)
        {
            if (status)
            {
                tbkMensagem.Text = "Aluno liberado";
                tbkMensagem.Background = Brushes.Green;
            }
            else
            {
                tbkMensagem.Text = "Aluno suspenso";
                tbkMensagem.Background = Brushes.Red;
                erroimage.Visibility = Visibility.Visible;
            }
           
        }

        private void mensagem()
        {
            tbkMensagem.Text = "Aluno não cadastrado!";
            tbkMensagem.Background = Brushes.Blue;
            erroimage.Visibility = Visibility.Visible;
        }
    }
}

