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

        public List<translation_class> Get_Translation_List()
        {
            List<translation_class> output = new List<translation_class>();

            output.Add(new translation_class()
            {
                Id = 1,
                Eng_Word_Id = 4,
                Pl_Word_Id = 3
            });
            output.Add(new translation_class()
            {
                Id = 1,
                Eng_Word_Id = 4,
                Pl_Word_Id = 2
            });
            output.Add(new translation_class()
            {
                Id = 1,
                Eng_Word_Id = 4,
                Pl_Word_Id = 1
            });
            output.Add(new translation_class()
            {
                Id = 1,
                Eng_Word_Id = 2,
                Pl_Word_Id = 5
            });
            output.Add(new translation_class()
            {
                Id = 1,
                Eng_Word_Id = 1,
                Pl_Word_Id = 3
            });

            return output;
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
                Id = 4,
                Word = "01",
                Description = "one"
            });
            output.Add(new Word_class()
            {
                Id = 5,
                Word = "02",
                Description = "two"
            });
            output.Add(new Word_class()
            {
                Id = 6,
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
            output.Add(new Word_class()
            {
                Id = 4,
                Word = "04",
                Description = "cztery"
            });
            output.Add(new Word_class()
            {
                Id = 5,
                Word = "05",
                Description = "pięć"
            });

            //using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(CnnString(db)))
            //{
            //    output = connection.Query<Word>("dbo.spWords_GetAll").ToList();
            //}

            return output;
        }
    }
}
