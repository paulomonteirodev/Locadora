namespace Paulo.Infra.Identity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUser_Added_Properties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DataDeCadastro", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "DataDeAtualizacao", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "CPF", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CPF");
            DropColumn("dbo.AspNetUsers", "Deleted");
            DropColumn("dbo.AspNetUsers", "DataDeAtualizacao");
            DropColumn("dbo.AspNetUsers", "DataDeCadastro");
        }
    }
}
