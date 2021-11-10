namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_writer_adress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterAdress", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterAdress");
        }
    }
}
