using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Prueba.Models
{
	public class Persona : INotifyObject
	{
		public Persona()
		{
			oBeneficiario = new ObservableCollection<Beneficiario>();
			oContrato = new ObservableCollection<Contrato>();
		}

		public override string ToString()
		{
			return Nombre + " " + PersonaID;
		}

		[Key]
		[Required]
		public int PersonaID { get { return personaId; } set { if (personaId != value) { personaId = value; OnPropertyChanged(); } } }
		private int personaId;

		[Required]
		[Display(Name ="Tipo de Documento")]
		public string TipoDoc { get { return tipodoc; } set { if (tipodoc != value) { tipodoc = value; OnPropertyChanged(); } } }
		private string tipodoc;

		[Required]
		public int Documento { get { return documento; } set { if (documento != value) { documento = value; OnPropertyChanged(); } } }
		private int documento;


		[StringLength(30)]
		[Required]
		public string Nombre { get { return nombre; } set { if (nombre != value) { nombre = value; OnPropertyChanged(); } } }
		private string nombre;

		[StringLength(30)]
		[Required]
		public string Apellido { get { return apellido; } set { if (apellido != value) { apellido = value; OnPropertyChanged(); } } }
		private string apellido;

		[StringLength(60)]
		public string Direccion { get { return direccion; } set { if (direccion != value) { direccion = value; OnPropertyChanged(); } } }
		private string direccion;

		[Required]
		private DateTime fechaNac;
		public DateTime FechaNac { get { return fechaNac; } set { if (fechaNac != value) { fechaNac = value; OnPropertyChanged(); } } }

		[StringLength(15)]
		[Required]
		public string Celular { get { return celular; } set { if (celular != value) { celular = value; OnPropertyChanged(); } } }
		private string celular;

		[StringLength(15)]
		public string Fijo { get { return fijo; } set { if (fijo != value) { fijo = value; OnPropertyChanged(); } } }
		private string fijo;

		//[ForeignKey("oCiudad")]
		[Required]
		public int CiudadID { get { return CiudadId; } set { if (CiudadId != value) { CiudadId = value; OnPropertyChanged(); } } }
		private int CiudadId;

		public virtual Ciudad oCiudad { get; set; }


		private ObservableCollection<Contrato> ocontrato;
		public virtual ObservableCollection<Contrato> oContrato { get { return oContrato; } set { oContrato = value; OnPropertyChanged(); } }


		private ObservableCollection<Beneficiario> obeneficiario;
		public virtual ObservableCollection<Beneficiario> oBeneficiario { get { return oBeneficiario; } set { oBeneficiario = value; OnPropertyChanged(); } }
	}
}
