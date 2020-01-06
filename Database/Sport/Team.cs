//using EasyMigrator;
//using FluentMigrator;
//using System;

//namespace Database.Create.Sport
//{
//    [Name("MyTableData")]
//    class Poco
//    {
//        [Pk(Clustered = false)] Guid Uuid;
//        [AutoInc(int.MinValue, 1)] int Sequence;
//        bool Accepted = true;
//        [NotNull, Index] string Name;
//        [Fixed(8), Ansi, NotNull, Clustered(Name = "idx_code")] string Code;
//        [Length(500)] string Title;
//        [Long] string ShortDesc;
//        [Max] string Desc;
//        [DbType(DbType.Currency)] decimal? Rate;
//        [Default("GETUTCDATE()")] DateTime CreatedOn;
//        [Fk("OtherTable")] int OtherTableId;
//        [Fk(typeof(Reference))] int? RefId;

//        CompositeIndex<Poco> index1 = new CompositeIndex<Poco>(x => x.Name, x => x.Code);

//        [Unique(Name = "IX_Custom_Name")]
//        CompositeIndex<Poco> index2 = new CompositeIndex<Poco>(
//            new Descending<Poco>(x => x.Sequence),
//            new Ascending<Poco>(x => x.Code));
//    }


//    //[Migration(0)]
//    //public class Team : Migration
//    //{
//    //    public override void Down()
//    //    {
//    //        throw new NotImplementedException();
//    //    }

//    //    public override void Up()
//    //    {
//    //        throw new NotImplementedException();
//    //    }
//    //}
//}
