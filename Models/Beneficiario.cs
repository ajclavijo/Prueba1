using System;
using System.ComponentModel.DataAnnotations;

namespace Prueba.Models
{
	public class Beneficiario : INotifyObject
	{
		public override string ToString()
		{
			return " " + BeneficiarioID;
		}


		[Key]
		[Required]
		public int BeneficiarioID { get { return beneficiarioId; } set { if (beneficiarioId != value) { beneficiarioId = value; OnPropertyChanged(); } } }
		private int beneficiarioId;


		//[ForeignKey("oPersona")]}
		[Required]
		public int PersonaID { get { return personaId; } set { if (personaId != value) { personaId = value; OnPropertyChanged(); } } }
		private int personaId;
		public virtual Persona oPersona { get; set; }


		//[ForeignKey("oContrato")]
		[Required]
		public int ContratoID { get { return contratoId; } set { if (contratoId != value) { contratoId = value; OnPropertyChanged(); } } }
		private int contratoId;
		public virtual Contrato oContrato { get; set; }


		[Required]
		[Display(Name ="Fecha De Ingreso")]
		private DateTime fechaIngr;
		public DateTime FechaIngr { get { return fechaIngr; } set { if (fechaIngr != value) { fechaIngr = value; OnPropertyChanged(); } } }


		//[ForeignKey("oPearentesco")]
		[Required]
		public int ParentescoID { get { return parentescoId; } set { if (parentescoId != value) { parentescoId = value; OnPropertyChanged(); } } }
		private int parentescoId;
		public virtual Parentesco oParentesco { get; set; }

	}
}
