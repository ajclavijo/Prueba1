using Prueba.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Data
{
	public class PruebaDbContext : DbContext
	{
		// El contexto se ha configurado para usar una cadena de conexión 'PruebaDbContext' del archivo 
		// de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
		// esta cadena de conexión tiene como destino la base de datos 'PruebaDb.Data.PruebaDbContext' de la instancia LocalDb. 
		// 
		// Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
		// modifique la cadena de conexión 'PruebaDbContext'  en el archivo de configuración de la aplicación.
		public PruebaDbContext()
			: base("name=PruebaDbContext")
		{
		}
		// Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
		// sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

		// public virtual DbSet<MyEntity> MyEntities { get; set; }
		public virtual DbSet<Persona> Personas { get; set; }
		public virtual DbSet<Ciudad> Ciudades { get; set; }
		public virtual DbSet<Departa> Departamentos { get; set; }
		public virtual DbSet<Contrato> Contratos { get; set; }
		public virtual DbSet<Beneficiario> Beneficiarios { get; set; }
		public virtual DbSet<Parentesco> Parentescos { get; set; }
		public virtual DbSet<Recaudo> Recaudos { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			// Aquí haremos nuestras configuraciones con Fluent API.

			// Especificar el nombre de una tabla.
			modelBuilder.Entity<Persona>().Map(m => m.ToTable("Persona"));
			modelBuilder.Entity<Ciudad>().Map(m => m.ToTable("Ciudad"));
			modelBuilder.Entity<Departa>().Map(m => m.ToTable("Departamento"));
			modelBuilder.Entity<Contrato>().Map(m => m.ToTable("Contratoto"));
			modelBuilder.Entity<Beneficiario>().Map(m => m.ToTable("Beneficiario"));
			modelBuilder.Entity<Parentesco>().Map(m => m.ToTable("Parentesco"));
			modelBuilder.Entity<Recaudo>().Map(m => m.ToTable("Recaudo"));

			/*
            // establecer una primary key.
            modelBuilder.Entity<Producto>().HasKey(c => c.Codigo);

            // Definir un campo como requerida.
            modelBuilder.Entity<Producto>().Property(c => c.Nombre).IsRequired();

            // Definir el nombre de un campo.
            modelBuilder.Entity<Producto>().Property(c => c.Nombre).HasColumnName("Nombre");

            // Definir el tipo de un campo.
            modelBuilder.Entity<Producto>().Property(c => c.Nombre).HasColumnType("varchar");

            // Definir el orden de un campo.
            modelBuilder.Entity<Producto>().Property(c => c.Nombre).HasColumnOrder(2);

            // Definir el máximo de caracteres permitidos para un campo.
            modelBuilder.Entity<Producto>().Property(c => c.Descripcion).HasMaxLength(100);

            // indicar que no se debe mapear una pripiedad a la base de datos.
            modelBuilder.Entity<Producto>().Ignore(c => c.CodigoIso);   */

			base.OnModelCreating(modelBuilder);
		}

	}
}

	