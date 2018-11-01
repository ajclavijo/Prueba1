using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Models
{
	public class Ciudad : INotifyObject
	{
		public Ciudad()
		{
			oPersona = new ObservableCollection<Persona>();
			oContrato = new ObservableCollection<Contrato>();
		}

		public override string ToString()
		{
			return Nombre + " " + CiudadID;
		}

		[Key]
		[Required]
		public int CiudadID { get { return CiudadId; } set { if (CiudadId != value) { CiudadId = value; OnPropertyChanged(); } } }
		private int CiudadId;

		[StringLength(60)]
		[Required]
		private string nombre;
		public string Nombre { get { return nombre; } set { if (nombre != value) { nombre = value; OnPropertyChanged(); } } }

		//[ForeignKey("oDepar")]
		[Required]
		[Display(Name ="Departemento")]
		private int DeparId;
		public int DeparID { get { return DeparId; } set { if (DeparId != value) { DeparId = value; OnPropertyChanged(); } } }

		private ObservableCollection<Persona> opersona;
		public virtual ObservableCollection<Persona> oPersona { get { return opersona; } set { opersona = value; OnPropertyChanged(); } }

		private ObservableCollection<Contrato> ocontrato;
		public virtual ObservableCollection<Contrato> oContrato { get { return ocontrato; } set { ocontrato = value; OnPropertyChanged(); } }

	}
}
