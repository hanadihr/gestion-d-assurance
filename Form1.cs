using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Gestion_du_client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == ""))
            {
                button1.Enabled = false;
            }
            else
                button1.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == ""))
            {
                button1.Enabled = false;
            }
            else
                button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Connection(textBox1.Text,textBox2.Text);
            
        }
        private void Connection (string idtf ,string pwd)
        {
           
            string query = "select * from personnel where Identifiant='"+idtf+"' and Password='"+pwd+"';";
            Console.WriteLine(query); //execution de requete
            string SqlConnectionString = "datasource=localhost;username=root;passwrod=;database=csharp;";
            MySqlConnection dataConnection = new MySqlConnection(SqlConnectionString);
            MySqlCommand CommandData = new MySqlCommand(query,dataConnection);
            CommandData.CommandTimeout = 60;
            try
            {
                dataConnection.Open();
                MySqlDataReader dataReader = CommandData.ExecuteReader();
                if (dataReader.HasRows)
                {
                    var id="";
                    var pas="";

                         dataReader.Read();
                          id = dataReader.GetString(1);
                        pas = dataReader.GetString(2);
                    
                  
                    if ((id==idtf)&&(pwd==pas))
                    {
                        MessageBox.Show("Vous Avez Connecter avec Succés!");
                        //redirection vers next page
                        this.Hide();
                        Form2 f2 = new Form2();
                        f2.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Votre mot de passe ou identifiant est erroné !");
                    }
                }
                else
                {
                    MessageBox.Show("Votre mot de passe ou identifiant est erroné !");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Erreur de Connection a la base de donnés ",e.Message);

            }



        }
    }
}
