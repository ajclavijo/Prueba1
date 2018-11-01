using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Prueba.Models
{
	public class Contrato : INotifyObject
	{
		public Contrato()
		{
			oBeneficiario = new ObservableCollection<Beneficiario>();
			oRecaudo = new ObservableCollection<Recaudo>();
		}


		public override string ToString()
		{
			return  " " + ContratoID;
		}

		[Key]
		[Required]
		public int ContratoID { get { return contratoId; } set { if (contratoId != value) { contratoId = value; OnPropertyChanged(); } } }
		private int contratoId;


		//[ForeignKey("oPersona")]
		[Required]
		public int PersonaID { get { return personaId; } set { if (personaId != value) { personaId = value; OnPropertyChanged(); } } }
		private int personaId;
		public virtual Persona oPersona { get; set; }


		[Required]
		[Display(Name ="Fecha de Afiliacion")]
		private DateTime fechaAfi;
		public DateTime FechaAfi { get { return fechaAfi; } set { if (fechaAfi != value) { fechaAfi = value; OnPropertyChanged(); } } }


		//[ForeignKey("oCiudad")]
		[Required]
		public int CiudadID { get { return ciudadId; } set { if (ciudadId != value) { ciudadId = value; OnPropertyChanged(); } } }
		private int ciudadId;
		public virtual Ciudad oCiudad { get; set; }

		[Required]
		[Display(Name ="Forma de Pago")]
		public string FormaPago { get { return formaPago; } set { if (formaPago != value) { formaPago = value; OnPropertyChanged(); } } }
		private string formaPago;

		[Required]
		private decimal valor;
		public decimal Valor { get { return valor; } set { if (valor != value) { valor = value; OnPropertyChanged(); } } }

		[Required]
		public int Asesor { get { return asesor; } set { if (asesor != value) { asesor = value; OnPropertyChanged(); } } }
		private int asesor;

		[Required]
		[Display(Name ="Cantidad de Beneficiarios")]
		public int CantBen { get { return cantBen; } set { if (cantBen != value) { cantBen = value; OnPropertyChanged(); } } }
		private int cantBen;



		private ObservableCollection<Beneficiario> obeneficiario;
		public virtual ObservableCollection<Beneficiario> oBeneficiario { get { return obeneficiario; } set { obeneficiario = value; OnPropertyChanged(); } }


		private ObservableCollection<Recaudo> orecaudo;
		public virtual ObservableCollection<Recaudo> oRecaudo { get { return orecaudo; } set { orecaudo = value; OnPropertyChanged(); } }

	}
}
