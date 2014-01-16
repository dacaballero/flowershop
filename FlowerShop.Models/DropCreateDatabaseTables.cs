using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FlowerShop.Models
{
    public class DropCreateDatabaseTables : IDatabaseInitializer<FlowerShopContext>
    {
        #region  IDatabaseInitializer<MenuComboContext> Members

        public void InitializeDatabase(FlowerShopContext context)
        {
            bool dbExists;
            using (new TransactionScope(TransactionScopeOption.Suppress))
            {
                dbExists = context.Database.Exists();
            }
            if (dbExists)
            {
                if (true)
                {
                    // remove all tables
                    const string dropQuery =
                        "IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{0}') DROP TABLE {0}";


                    context.Database.ExecuteSqlCommand(string.Format(dropQuery, "Orders"));
                    context.Database.ExecuteSqlCommand(string.Format(dropQuery, "Customers"));
                    context.Database.ExecuteSqlCommand(string.Format(dropQuery, "Drivers"));
                    context.Database.ExecuteSqlCommand(string.Format(dropQuery, "OrderStatuses"));
                    context.Database.ExecuteSqlCommand(string.Format(dropQuery, "Businesses"));
                    context.Database.ExecuteSqlCommand(string.Format(dropQuery, "Users"));
                    context.Database.ExecuteSqlCommand(string.Format(dropQuery, "UserRoles"));

                    // create all tables
                    var dbCreationScript = ((IObjectContextAdapter)
                                            context).ObjectContext.CreateDatabaseScript();
                    context.Database.ExecuteSqlCommand(dbCreationScript);

                    Seed(context);
                    context.SaveChanges();
                }
            }
            else
            {
                throw new ApplicationException("No database instance");
            }
        }

        #endregion

        #region  Methods

        protected virtual void Seed(FlowerShopContext context)
        {
            //context.SaveChanges();
        }

        #endregion
    }
}
