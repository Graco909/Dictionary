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

        public List<Word_class> GetPerson_All_eng()
        {
            List<Word_class> output = new List<Word_class>();
            output.Add(new Word_class()
            {
                Id = 1,
                Word = "01",
                Description = "uno"
            });
            output.Add(new Word_class()
            {
                Id = 2,
                Word = "02",
                Description = "dos"
            });
            output.Add(new Word_class()
            {
                Id = 3,
                Word = "03",
                Description = "tres"
            });
            output.Add(new Word_class()
            {
                Id = 1,
                Word = "01",
                Description = "one"
            });
            output.Add(new Word_class()
            {
                Id = 2,
                Word = "02",
                Description = "two"
            });
            output.Add(new Word_class()
            {
                Id = 3,
                Word = "03",
                Description = "threeeeeeeeee eeeeeeeeeeee eeeeeeeeeeeeeeeeee Eeeeeeeeeeeeeeeeeeeee eeeeeeeeeeeee eeeeeeeeeeeeeeeeeeeeeeee eeeeeeeeee"
            });

            //using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString(db)))
            //{
            //    output = connection.Query<Word>("dbo.spWords_GetAll").ToList();
            //}

            return output;
        }

        public List<Word_class> GetPerson_All()
        {
            List<Word_class> output=new List<Word_class>();
            output.Add(new Word_class()
            {
                Id = 1,
                Word = "01",
                Description = "jeden"
            }) ;
            output.Add(new Word_class()
            {
                Id = 2,
                Word = "02",
                Description = "dwa"
            });
            output.Add(new Word_class()
            {
                Id = 3,
                Word = "03",
                Description = "trzy"
            });

            //using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString(db)))
            //{
            //    output = connection.Query<Word>("dbo.spWords_GetAll").ToList();
            //}

            return output;
        }
    }
}
