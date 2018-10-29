namespace Prueba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigrationInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beneficiario",
                c => new
                    {
                        BeneficiarioID = c.Int(nullable: false, identity: true),
                        PersonaID = c.Int(nullable: false),
                        ContratoID = c.Int(nullable: false),
                        FechaIngr = c.DateTime(nullable: false),
                        ParentescoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BeneficiarioID)
                .ForeignKey("dbo.Contratoto", t => t.ContratoID, cascadeDelete: true)
                .ForeignKey("dbo.Persona", t => t.PersonaID, cascadeDelete: true)
                .ForeignKey("dbo.Parentesco", t => t.ParentescoID, cascadeDelete: true)
                .Index(t => t.PersonaID)
                .Index(t => t.ContratoID)
                .Index(t => t.ParentescoID);
            
            CreateTable(
                "dbo.Contratoto",
                c => new
                    {
                        ContratoID = c.Int(nullable: false, identity: true),
                        PersonaID = c.Int(nullable: false),
                        FechaAfi = c.DateTime(nullable: false),
                        CiudadID = c.Int(nullable: false),
                        FormaPago = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Asesor = c.Int(nullable: false),
                        CantBen = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContratoID)
                .ForeignKey("dbo.Ciudad", t => t.CiudadID, cascadeDelete: true)
                .ForeignKey("dbo.Persona", t => t.PersonaID, cascadeDelete: true)
                .Index(t => t.PersonaID)
                .Index(t => t.CiudadID);
            
            CreateTable(
                "dbo.Ciudad",
                c => new
                    {
                        CiudadID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        DeparID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CiudadID)
                .ForeignKey("dbo.Departamento", t => t.DeparID, cascadeDelete: true)
                .Index(t => t.DeparID);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        PersonaID = c.Int(nullable: false, identity: true),
                        TipoDoc = c.String(),
                        Documento = c.Int(nullable: false),
                        Nombre = c.String(maxLength: 30),
                        Apellido = c.String(maxLength: 30),
                        Direccion = c.String(maxLength: 60),
                        FechaNac = c.DateTime(nullable: false),
                        Celular = c.String(maxLength: 15),
                        Fijo = c.String(maxLength: 15),
                        CiudadID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonaID)
                .ForeignKey("dbo.Ciudad", t => t.CiudadID, cascadeDelete: true)
                .Index(t => t.CiudadID);
            
            CreateTable(
                "dbo.Recaudo",
                c => new
                    {
                        RecaudoID = c.Int(nullable: false, identity: true),
                        ContratoID = c.Int(nullable: false),
                        FechaIngr = c.DateTime(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Detalle = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.RecaudoID)
                .ForeignKey("dbo.Contratoto", t => t.ContratoID, cascadeDelete: true)
                .Index(t => t.ContratoID);
            
            CreateTable(
                "dbo.Parentesco",
                c => new
                    {
                        ParentescoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.ParentescoID);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        DeparID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.DeparID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ciudad", "DeparID", "dbo.Departamento");
            DropForeignKey("dbo.Beneficiario", "ParentescoID", "dbo.Parentesco");
            DropForeignKey("dbo.Recaudo", "ContratoID", "dbo.Contratoto");
            DropForeignKey("dbo.Contratoto", "PersonaID", "dbo.Persona");
            DropForeignKey("dbo.Persona", "CiudadID", "dbo.Ciudad");
            DropForeignKey("dbo.Beneficiario", "PersonaID", "dbo.Persona");
            DropForeignKey("dbo.Contratoto", "CiudadID", "dbo.Ciudad");
            DropForeignKey("dbo.Beneficiario", "ContratoID", "dbo.Contratoto");
            DropIndex("dbo.Recaudo", new[] { "ContratoID" });
            DropIndex("dbo.Persona", new[] { "CiudadID" });
            DropIndex("dbo.Ciudad", new[] { "DeparID" });
            DropIndex("dbo.Contratoto", new[] { "CiudadID" });
            DropIndex("dbo.Contratoto", new[] { "PersonaID" });
            DropIndex("dbo.Beneficiario", new[] { "ParentescoID" });
            DropIndex("dbo.Beneficiario", new[] { "ContratoID" });
            DropIndex("dbo.Beneficiario", new[] { "PersonaID" });
            DropTable("dbo.Departamento");
            DropTable("dbo.Parentesco");
            DropTable("dbo.Recaudo");
            DropTable("dbo.Persona");
            DropTable("dbo.Ciudad");
            DropTable("dbo.Contratoto");
            DropTable("dbo.Beneficiario");
        }
    }
}
