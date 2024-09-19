using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ScreenSound.Banco
{
    internal class Connection
    {
        private string connectionString = $@"Data Source=DESKTOP-U6VMJ2C\SQLSERVER2022;Initial Catalog=Alura_Aula_Csharp;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public SqlConnection obterConexao()
        {
            return new SqlConnection(connectionString);
        }

       
    }
}
