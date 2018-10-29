using Prueba.Data;
using Prueba.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Prueba.ViewModel
{
	class PersonaVM : INotifyObject
	{
		public RelayCommand cmd_Insertar { get; set; }
		public RelayCommand cmd_Consultar { get; set; }
		public RelayCommand cmd_Eliminar { get; set; }
		public RelayCommand cmd_Modificar { get; set; }
		public Persona Persona { get { return persona; } set { persona = value; OnPropertyChanged(); } }
		private Persona persona;


		public ObservableCollection<Persona> Lista { get { return lista; } set { lista = value; OnPropertyChanged(); } }
		private ObservableCollection<Persona> lista = new ObservableCollection<Persona>();

		public ObservableCollection<Ciudad> ListaC { get { return listaC; } set { listaC = value; OnPropertyChanged(); } }
		private ObservableCollection<Ciudad> listaC = new ObservableCollection<Ciudad>();

		public PersonaVM()
		{
			this.cmd_Insertar = new RelayCommand(p => this.Insertar());
			this.cmd_Consultar = new RelayCommand(p => this.Consultar());
			this.cmd_Eliminar = new RelayCommand(p => this.Eliminar());
			this.cmd_Modificar = new RelayCommand(p => this.Modificar());
			this.Persona = new Persona();

			using (var dbc = new PruebaDbContext())
			{
				this.Lista = new ObservableCollection<Persona>(dbc.Personas);
				this.ListaC = new ObservableCollection<Ciudad>(dbc.Ciudades);
			}
			this.Persona.FechaNac = DateTime.Now.Date;
		}


		public void Insertar()
		{
			using (var dbc = new PruebaDbContext())
			{
				if (this.Persona.Nombre == null)
				{
					MessageBox.Show("No digito el nombre de la persona a insertar");
					return;
				}
				dbc.Personas.Add(this.Persona);
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
				this.Lista = new ObservableCollection<Persona>(dbc.Personas);
				this.ListaC = new ObservableCollection<Ciudad>(dbc.Ciudades);
			}
		}
		public void Eliminar()
		{
			if (this.Persona.Nombre == null)
			{
				MessageBox.Show("No Digito la Persona a Eliminar");
				return;
			}
			using (var dbc = new PruebaDbContext())
			{
				try
				{
					var elim = from p in dbc.Personas
							   where p.Nombre == this.Persona.Nombre
							   select p). Single();
					dbc.Personas.Remove(elim);
					dbc.SaveChanges();
					this.Lista = new ObservableCollection<Persona>(dbc.Personas);
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
			if (this.Persona.Nombre == null)
			{
				MessageBox.Show("No se digito el nombre de la perona a modificar");
				return;
			}
			using (var dbc = new PruebaDbContext())
			{
				var persona = dbc.Personas.Find(this.Persona.PersonaID);
				Persona.PersonaID = this.Persona.PersonaID;
				Persona.Nombre = this.Persona.Nombre;
				Persona.Apellido = this.Persona.Apellido;
				Persona.TipoDoc = this.Persona.TipoDoc;
				Persona.Documento = this.Persona.Documento;
				Persona.Direccion = this.Persona.Direccion;
				Persona.FechaNac = this.Persona.FechaNac;
				Persona.Celular = this.Persona.Celular;
				Persona.Fijo = this.Persona.Fijo;
				Persona.CiudadID = this.Persona.CiudadID;
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