using System;
using System.ComponentModel.DataAnnotations;

namespace Prueba.Models
{
	public class Recaudo : INotifyObject
	{
		public override string ToString()
		{
			return  " " + RecaudoID;
		}

		[Key]
		[Required]
		public int RecaudoID { get { return recaudoId; } set { if (recaudoId != value) { recaudoId = value; OnPropertyChanged(); } } }
		private int recaudoId;

		[Required]
		[Display(Name = "Fecha")]
		private DateTime fecha;
		public DateTime Fecha { get { return fecha; } set { if (fecha != value) { fecha = value; OnPropertyChanged(); } } }
		
		
		//[ForeignKey("oContrato")]
		[Required]
		public int ContratoID { get { return contratoId; } set { if (contratoId != value) { contratoId = value; OnPropertyChanged(); } } }
		private int contratoId;
		public virtual Contrato oContrato { get; set; }


		[Required]
		[Display(Name ="Fecha De pago")]
		private DateTime fechaPago;
		public DateTime FechaPago { get { return fechaPago; } set { if (fechaPago != value) { fechaPago = value; OnPropertyChanged(); } } }


		[Required]
		private decimal valor;
		public decimal Valor { get { return valor; } set { if (valor != value) { valor = value; OnPropertyChanged(); } } }


		[StringLength(200)]
		public string Detalle { get { return detalle; } set { if (detalle != value) { detalle= value; OnPropertyChanged(); } } }
		private string detalle;



	}
}
