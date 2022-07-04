using System.Data;
using System.Data.SqlClient;

namespace Login_authenticator
{

    public partial class Authenticator : Form
    {
        string dbconnection = "Server=localhost;Database=users;Trusted_Connection=true"; // Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;
        public Authenticator()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(dbconnection);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM userdatabase", con); // Grabs the database of all usernames & passwords (SQL command)

            bool connectionlog = false;

            DataTable dtable = new DataTable();
            sda.Fill(dtable);

            foreach (DataRow row in dtable.Rows)
            {
                if (row["user"].ToString() == textBox1.Text && row["pass"].ToString() == textBox2.Text)
                {
                    connectionlog = true; // if the input matches the database information = allow connection otherwise connectionlog stays at false
                }
            }

            if(connectionlog == true)
            {
                MessageBox.Show("Authentication successful for user " + textBox1.Text);
            }
            else
            {
                MessageBox.Show("Authentication failed.");
            }

        }

       
    }
}