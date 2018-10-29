using Prueba.Data;
using Prueba.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Prueba.ViewModel
{
	class CiudadVM : INotifyObject
	{
		public RelayCommand cmd_Insertar { get; set; }
		public RelayCommand cmd_Consultar { get; set; }
		public RelayCommand cmd_Eliminar { get; set; }
		public RelayCommand cmd_Modificar { get; set; }

		public Ciudad Ciudad { get { return ciudad; } set { ciudad = value; OnPropertyChanged(); } }
		private Ciudad ciudad;


		public ObservableCollection<Departa> ListaD { get { return listaD; } set { listaD = value; OnPropertyChanged(); } }
		private ObservableCollection<Departa> listaD = new ObservableCollection<Departa>();

		public CiudadVM()
		{
			this.cmd_Insertar = new RelayCommand(p => this.Insertar());
			this.cmd_Eliminar = new RelayCommand(p => this.Eliminar());
			this.cmd_Modificar = new RelayCommand(p => this.Modificar());
			this.cmd_Consultar = new RelayCommand(p => this.Consultar());

			this.Ciudad = new Ciudad();

			using (var dbc = new PruebaDbContext())
			{
				this.ListaD = new ObservableCollection<Departa>(dbc.Departamentos);
			}
		}


		public void Insertar()
		{
			using (var dbc = new PruebaDbContext())
			{
				if (this.Ciudad.Nombre == null)
				{
					MessageBox.Show("No digitó el nombre de la ciudad a insertar");
					return;
				}
				dbc.Ciudades.Add(this.Ciudad);
				try
				{
					dbc.SaveChanges();
					this.Consultar();
				}
				catch (Exception er)
				{
					MessageBox.Show("Error " + er.Message);
					if (er.InnerException != null)
						MessageBox.Show("Error " + er.InnerException.Message);
				}
			}
		}

		public void Consultar()
		{
			using (var dbc = new PruebaDbContext())
			{
				this.Lista = new ObservableCollection<Ciudad>(dbc.Ciudades);
				this.ListaD = new ObservableCollection<Departa>(dbc.Departamentos);
			}
		}

		public void Eliminar()
		{
			if (this.Ciudad.Nombre == null)
			{
				MessageBox.Show("No Digito la Ciudad a Eliminar");
				return;
			}
			using (var dbc = new PruebaDbContext())
			{
				try
				{
					var elim = from p in dbc.Ciudades
							   where p.Nombre == this.Ciudad.Nombre
							   select p). Single();
					dbc.Ciudades.Remove(elim);
					dbc.SaveChanges();
				}
				catch (Exception er)
				{
					MessageBox.Show("Error " + er.Message);
					if (er.InnerException != null)
						MessageBox.Show("Error " + er.InnerException.Message);
				}
			}
		}
		public void Modificar()
		{
			if (this.Ciudad.Nombre == null)
			{
				MessageBox.Show("No se digito el nombre de la Ciudad a modificar");
				return;
			}
			using (var dbc = new PruebaDbContext())
			{
				var ciudad = dbc.Ciudades.Find(this.Ciudad.CiudadID);
				Ciudad.CiudadID = this.Ciudad.CiudadID;
				Ciudad.Nombre = this.Ciudad.Nombre;
				Ciudad.DeparID = this.Ciudad.DeparID;
				try
				{
					dbc.SaveChanges();
					this.Consultar();
				}
				catch (Exception er)
				{
					MessageBox.Show("Error " + er.Message);
					if (er.InnerException != null)
						MessageBox.Show("Error " + er.InnerException.Message);
				}
			}
		}
	}
}


	



