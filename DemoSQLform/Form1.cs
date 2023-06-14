using System.Data.SqlClient;

namespace DemoSQLform
{
    public partial class Form1 : Form
    {
        List<Person> people = new List<Person>();

        public Form1()
        {
            InitializeComponent();
            getBinding();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void getBinding()
        {
            listBox1.DataSource = people;
            listBox1.DisplayMember = "custormerName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Source db = new Source();
            people = db.GetPeople();

            getBinding();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string dbSource = "DESKTOP-KEAGKMO\\SQLEXPRESS";
            string dbName = "TeaShop";

            string connstr = "Data Source = " + dbSource + "; Initial Catalog = " + dbName + "; Integrated Security = true";
            SqlConnection conn = new SqlConnection(connstr);

            conn.Open();

            string query = "SELECT * FROM tbCustomer";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string output = reader.GetString(0);

                MessageBox.Show(output);
            }
            conn.Close();
        }
    }
}