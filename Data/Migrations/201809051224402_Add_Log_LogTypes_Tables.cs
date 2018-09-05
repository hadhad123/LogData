namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Log_LogTypes_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        LogID = c.Int(nullable: false, identity: true),
                        LogMessage = c.String(nullable: false),
                        LogTypeID = c.Int(nullable: false),
                        CreationDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LogID)
                .ForeignKey("dbo.LogTypes", t => t.LogTypeID)
                .Index(t => t.LogTypeID);
            
            CreateTable(
                "dbo.LogTypes",
                c => new
                    {
                        LogTypeID = c.Int(nullable: false, identity: true),
                        LogName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LogTypeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logs", "LogTypeID", "dbo.LogTypes");
            DropIndex("dbo.Logs", new[] { "LogTypeID" });
            DropTable("dbo.LogTypes");
            DropTable("dbo.Logs");
        }
    }
}
