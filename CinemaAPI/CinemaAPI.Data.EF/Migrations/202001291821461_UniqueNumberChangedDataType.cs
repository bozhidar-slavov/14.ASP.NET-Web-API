namespace CinemaAPI.Data.EF
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueNumberChangedDataType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "UniqueNumberGuid", c => c.String(nullable: false));
            DropColumn("dbo.Reservations", "UniqueNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "UniqueNumber", c => c.Guid(nullable: false));
            DropColumn("dbo.Reservations", "UniqueNumberGuid");
        }
    }
}
