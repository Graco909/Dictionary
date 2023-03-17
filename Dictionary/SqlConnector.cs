using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class SqlConnector
    {
        private const string db = "Dictionary";

        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public List<EnglishWord> GetPerson_All_eng()
        {
            List<EnglishWord> output = new List<EnglishWord>();
            output.Add(new EnglishWord()
            {
                Id = 1,
                Word = "01",
                Description = "uno"
            });
            output.Add(new EnglishWord()
            {
                Id = 2,
                Word = "02",
                Description = "dos"
            });
            output.Add(new EnglishWord()
            {
                Id = 3,
                Word = "03",
                Description = "tres"
            });
            output.Add(new EnglishWord()
            {
                Id = 1,
                Word = "01",
                Description = "one"
            });
            output.Add(new EnglishWord()
            {
                Id = 2,
                Word = "02",
                Description = "two"
            });
            output.Add(new EnglishWord()
            {
                Id = 3,
                Word = "03",
                Description = "three"
            });

            //using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString(db)))
            //{
            //    output = connection.Query<PolishWord>("dbo.spPolishWords_GetAll").ToList();
            //}

            return output;
        }

        public List<PolishWord> GetPerson_All()
        {
            List<PolishWord> output=new List<PolishWord>();
            output.Add(new PolishWord()
            {
                Id = 1,
                Word = "01",
                Description = "jeden"
            }) ;
            output.Add(new PolishWord()
            {
                Id = 2,
                Word = "02",
                Description = "dwa"
            });
            output.Add(new PolishWord()
            {
                Id = 3,
                Word = "03",
                Description = "trzy"
            });

            //using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString(db)))
            //{
            //    output = connection.Query<PolishWord>("dbo.spPolishWords_GetAll").ToList();
            //}

            return output;
        }
    }
}
