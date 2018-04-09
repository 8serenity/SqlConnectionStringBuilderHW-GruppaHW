using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruppaHW
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

                command.CommandText = "create table Gruppa (Id int not null primary key, Name varchar(255) not null)";


                command.ExecuteNonQuery();


            }
        }

        public static DbConnection CreateConnection()
        {
            DbProviderFactory providerFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["Automate"].ProviderName);

            DbConnection connection = providerFactory.CreateConnection();

            string connectionFromAppConfig = ConfigurationManager.ConnectionStrings["Automate"].ConnectionString;

            connection.ConnectionString = connectionFromAppConfig;

            return connection;
        }
    }
}
