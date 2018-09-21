namespace Paulo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Filme",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        GeneroId = c.Int(nullable: false),
                        LocacaoId = c.Int(),
                        DataDeCadastro = c.DateTime(nullable: false),
                        DataDeAtualizacao = c.DateTime(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genero", t => t.GeneroId)
                .ForeignKey("dbo.Locacao", t => t.LocacaoId)
                .Index(t => t.GeneroId)
                .Index(t => t.LocacaoId);
            
            CreateTable(
                "dbo.Genero",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        DataDeCadastro = c.DateTime(nullable: false),
                        DataDeAtualizacao = c.DateTime(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataDaLocacao = c.DateTime(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                        DataDeCadastro = c.DateTime(nullable: false),
                        DataDeAtualizacao = c.DateTime(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Filme", "LocacaoId", "dbo.Locacao");
            DropForeignKey("dbo.Locacao", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Filme", "GeneroId", "dbo.Genero");
            DropIndex("dbo.Locacao", new[] { "UsuarioId" });
            DropIndex("dbo.Filme", new[] { "LocacaoId" });
            DropIndex("dbo.Filme", new[] { "GeneroId" });
            DropTable("dbo.Locacao");
            DropTable("dbo.Genero");
            DropTable("dbo.Filme");
        }
    }
}
