using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public static class EnumExtensions
    {
        public static void AddDataFor<TEnum>(Migration migration, string schema) where TEnum : Enum /* TODO [jaz] Requires C# 7.3 */
        {
            var builder = migration.Insert
                .IntoTable(nameof(TEnum))
                .InSchema(schema);
                //.WithIdentityInsert();
            foreach (var item in Enum.GetNames(typeof(TEnum)))
            {
                var x = (TEnum)Enum.Parse(typeof(TEnum), item);
                builder = builder.Row(new { Id = (Convert.ChangeType(x, Enum.GetUnderlyingType(typeof(TEnum)))), Name = item }); 
                //, Description = x.GetDisplayDescription(), Order = x.GetDisplayOrder() });
            }
        }
    }
}
