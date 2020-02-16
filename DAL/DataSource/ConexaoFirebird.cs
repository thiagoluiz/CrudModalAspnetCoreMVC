using FirebirdSql.Data.FirebirdClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace DAL.DataSource
{
    public class ConexaoFirebird
    {
        private static readonly ConexaoFirebird instanciaFirebird = new ConexaoFirebird();

        private ConexaoFirebird() { }

        public static ConexaoFirebird getInstancia()
        {
            return instanciaFirebird;
        }

        public FbConnection getConexao()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            string conn = configuration.GetConnectionString("ConexaoFirebird");
            return new FbConnection(conn);
        }

    }
}
