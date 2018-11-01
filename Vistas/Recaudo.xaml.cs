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
using System.Windows.Shapes;

namespace Prueba.Vistas
{
	/// <summary>
	/// Lógica de interacción para Recaudo.xaml
	/// </summary>
	public partial class Recaudo : Window
	{
		public Recaudo()
		{
			InitializeComponent();
		}

		private void Salir_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
