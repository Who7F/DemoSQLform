
using System.Data.SqlClient;


namespace DemoSQLform
{
    public class Source
    {
        public List<Person> GetPeople()
        {
            string dbSource = "";
            string dbName = "";

            string connstr = "Data Source = " + dbSource + "; Initial Catalog = " + dbName + "; Integrated Security = true";
            SqlConnection conn = new SqlConnection(connstr);
            string query = "SELECT * FROM tbCustomer";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            
            List<Person> list = new List<Person>();
            while (reader.Read())
            {
                Person e = new Person();
                e.custormerName = (string)reader[0];
                list.Add(e);
            }
            conn.Close();
            return list;
        }

    }
}
