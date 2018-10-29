using Prueba.Vistas;
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

namespace Prueba
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
			   		 
		private void Persona_Click(object sender, RoutedEventArgs e)
		{
			Persona per = new Persona();
			per.Show();
		}

		private void Recaudo_Click(object sender, RoutedEventArgs e)
		{
			Recaudo recaudo = new Recaudo();
			recaudo.Show();
		}

		private void Beneficiario_Click(object sender, RoutedEventArgs e)
		{
			Beneficiario bene = new Beneficiario();
			bene.Show();
		}

		private void Contrato_Click(object sender, RoutedEventArgs e)
		{
			Contrato contrato = new Contrato();
			contrato.Show();
		}

		private void Ciudad_Click(object sender, RoutedEventArgs e)
		{
			Ciudad ciudad = new Ciudad();
			ciudad.Show();
		}

		private void Departamento_Click(object sender, RoutedEventArgs e)
		{
			Departamento departamento = new Departamento();
			departamento.Show();
		}

		private void Parentesco_Click(object sender, RoutedEventArgs e)
		{
			Parentesco parentesco = new Parentesco();
			parentesco.Show();
		}


		private void Salir_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

	}
}
