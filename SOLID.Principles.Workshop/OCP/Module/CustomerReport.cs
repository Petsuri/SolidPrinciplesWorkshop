using System;
using OCP.ExternalModule;

namespace OCP.Module
{
    public class CustomerReport
    {
        public static void Main()
        {
            var connection = new AdoNetConnection();
            var db = new LoggingDatabase(new Database(connection), null, null);

            var numberOfCustomers =
                db.Query<int>("SELECT COUNT(ID) FROM Customers WHERE RegisteredTimestamp BETWEEN @Start AND @End",
                    new {Start = new DateTime(2020, 1, 1), End = new DateTime(2020, 1, 31)});

        }
    }
}
