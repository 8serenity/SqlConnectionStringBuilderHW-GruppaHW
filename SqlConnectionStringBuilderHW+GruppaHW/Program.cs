using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlConnectionStringBuilderHW
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateTable();
        }

        static void CreateTable()
        {
            using (DbConnection connection = CreateConnection())
            {

                connection.Open();

                DbCommand command = connection.CreateCommand();

                command.CommandText = "create table Aasd (Id int not null primary key, Name varchar(255) not null)";

                command.ExecuteNonQuery();
            }
        }

        public static DbConnection CreateConnection()
        {
            DbProviderFactory providerFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["Automate"].ProviderName);

            DbConnection connection = providerFactory.CreateConnection();

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder["Data Source"] = @"DESKTOP-OP0BNT2\SQLEXPRESS";
            builder["Integrated Security"] = true;
            builder["Initial Catalog"] = "carrentaldb";
            builder["Trusted_Connection"] = true;

            connection.ConnectionString = builder.ConnectionString;

            return connection;
        }
    }
}
