using FluentMigrator;
using System;

namespace Database.Create.Sport
{
    [Migration(0)]
    public class League : Migration
    {
        public static string TableName = "League";
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
           
            Create.Table(TableName).InSchema("Sports")
                .WithColumn("Id").AsInt32().PrimaryKey().NotNullable().Identity().Indexed()
                .WithColumn("Name").AsString(Limits.StringMax).NotNullable()
                .WithColumn("Abbr").AsString(Limits.StringMax).NotNullable()
                .WithColumn("Sex").AsInt32().ForeignKey("Sex", "Id")
                .WithColumn("Sport").AsInt32().ForeignKey("Sport", "Id")
                .WithColumn("GeoLocation").AsInt32().ForeignKey("GeoLocation", "Id");
        }
    }
}
