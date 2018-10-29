using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Prueba.Models
{

	public class Departa : INotifyObject

	{
		public Departa()
		{
			oCiudad = new ObservableCollection<Ciudad>();
		}
		public override string ToString()
		{
			return Nombre + " " + DeparID;
		}

		[Key]
		[Required]
		[Display(Name = "Departemento")]
		public int DeparID { get { return DeparId; } set { if (DeparId != value) { DeparId = value; OnPropertyChanged(); } } }
		private int DeparId;

		[StringLength(60)]
		[Required]
		private string nombre;
		public string Nombre { get { return nombre; } set { if (nombre != value) { nombre = value; OnPropertyChanged(); } } }

		private ObservableCollection<Ciudad> ociudad;
		public virtual ObservableCollection<Ciudad> oCiudad { get { return oCiudad; } set { oCiudad = value; OnPropertyChanged(); } }
	}
}