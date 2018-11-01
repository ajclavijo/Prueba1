using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Models
{
	public class Parentesco: INotifyObject
	{
		public Parentesco()
		{
			oBeneficiario = new ObservableCollection<Beneficiario>();
			
		}
		public override string ToString()
		{
			return Nombre + " " + ParentescoID;
		}

		[Key]
		[Required]
		public int ParentescoID { get { return parentescoId;  } set { if (parentescoId != value) { parentescoId = value; OnPropertyChanged(); } } }
		private int parentescoId;


		[StringLength(15)]
		[Required]
		public string Nombre { get { return nombre; } set { if (nombre != value) { nombre = value; OnPropertyChanged(); } } }
		private string nombre;


		private ObservableCollection<Beneficiario> obeneficiario;
		public virtual ObservableCollection<Beneficiario> oBeneficiario { get { return obeneficiario; } set { obeneficiario = value; OnPropertyChanged(); } }
	}
}
