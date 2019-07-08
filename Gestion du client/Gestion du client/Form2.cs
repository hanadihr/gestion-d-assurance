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
    public partial class Form2 : Form
    {
        public Form2()
        {

            InitializeComponent();
            textBox2.Enabled = false;// 5 successif
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        //recherche
        private void button1_Click(object sender, EventArgs e)
        {
           
            textBox2.Enabled = false;  
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            comboBox1.Text = "";      //liste deroulante
            comboBox1.Enabled = false;
            button2.Visible = false;
            button2.Enabled = false;
            button1.Enabled = true;
           
            Connection(textBox1.Text.ToString());

        }
        private void Connection(string Cin)
        {
            string query = "select * from Client where Cin="+ Cin +";";
            Console.WriteLine(query);
            string SqlConnectionString = "datasource=localhost;username=root;passwrod=;database=csharp;";
            MySqlConnection dataConnection = new MySqlConnection(SqlConnectionString);
            MySqlCommand CommandData = new MySqlCommand(query, dataConnection);
            CommandData.CommandTimeout = 60;
            try
            {
                dataConnection.Open();
                MySqlDataReader dataReader = CommandData.ExecuteReader(); //execution du requete
                if (dataReader.HasRows)
                {
                    label3.Show();
                    label3.Text = "Client Existe!";
                    label3.BackColor = Color.Green;
                    dataReader.Read();
                    textBox2.Text = dataReader.GetString(2);
                    textBox3.Text = dataReader.GetString(3);
                    textBox4.Text = dataReader.GetString(4);
                    textBox5.Text = dataReader.GetString(5);
                    textBox6.Text = dataReader.GetString(6);
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    textBox6.Enabled = false;
                    comboBox1.Items.Clear();
                    comboBox1.Refresh();
                    comboBox1.Items.Add("Contrat spécifique à durée limitée");
                    button2.Visible = false;
                    button2.Enabled = false;

                    string querya = "select * from contrat where Cin=" + Cin + ";";
                    Console.WriteLine(querya);
                    string SqlConnectionString1 = "datasource=localhost;username=root;passwrod=;database=csharp;";

                    MySqlConnection dataConnection3 = new MySqlConnection(SqlConnectionString1);
                    MySqlCommand CommandData3 = new MySqlCommand(querya, dataConnection3);
                    CommandData3.CommandTimeout = 60;
                    dataConnection3.Open();
                    MySqlDataReader dataReader3 = CommandData3.ExecuteReader();
                    if (dataReader3.HasRows)
                    {

                        var sin = "";


                        var contrat = "";

                        dataReader.Read();
                        sin=dataReader.GetString(2);
                        contrat=dataReader.GetString(3);


                        if ((sin == Cin) && (contrat == "Contrat maintenance annuelle"))
                        {
                            button2.Visible = true;
                            button2.Enabled = true;

                       

                            comboBox1.Items.Clear();
                            comboBox1.Refresh();
                            comboBox1.Items.Add("Contrat spécifique à durée limitée");

                        }





                    }

                    else
                    {
                        label3.Show();
                        label3.Text = "Client N'Existe pas!";
                        label3.BackColor = Color.Red;
                        button2.Visible = true;
                        button2.Enabled = true;

                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();

                        comboBox1.Items.Clear();
                        comboBox1.Refresh();
                        comboBox1.Items.Add("Contrat spécifique à durée limitée");




                    }


                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur de Connection a la base de donnés ", e.Message);

            }


    
//-------------------
             dataConnection.Close();
            textBox7.Clear();
            string queryc = "select * from contrat where Cin=" + Cin + ";";
            Console.WriteLine(queryc);
            MySqlConnection dataConnection2 = new MySqlConnection(SqlConnectionString);
            MySqlCommand CommandData2 = new MySqlCommand(queryc, dataConnection2);
            CommandData2.CommandTimeout = 60;
                try
            {
                dataConnection2.Open();
                MySqlDataReader dataReader2 = CommandData2.ExecuteReader();
                if (dataReader2.HasRows)
                {
                 
                    while (dataReader2.Read())
                    {
                        
                        textBox7.Text += "Cin : " + dataReader2.GetString(1) + "\t TypeContrat:  " + dataReader2.GetString(2); ;
                        textBox7.AppendText(Environment.NewLine);
                    }
                }
            }
            catch(Exception afficha)
            {
                MessageBox.Show("2"+afficha.Message.ToString());
            }



        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true; // cin true seulement pour les entiers
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {// visualisation les texts box lors le cliq sur ajouter contrat
            comboBox1.Text = "";
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            comboBox1.Enabled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Valider_Click(object sender, EventArgs e)
        {
           if(textBox1.Text!=""&&textBox2.Text!=""&&textBox3.Text!=""&&textBox4.Text!="" && textBox5.Text != "" && textBox6.Text != ""&& comboBox1.Text != "")
            {

            if (label3.Text == "Client Existe!")
            {
                string query = "INSERT INTO contrat VALUES (default,"+int.Parse(textBox1.Text) +",'"+comboBox1.Text+"'); ";
                Console.WriteLine(query);
                string SqlConnectionString = "datasource=localhost;username=root;passwrod=;database=csharp;";
                MySqlConnection dataConnection = new MySqlConnection(SqlConnectionString);
                MySqlCommand CommandData = new MySqlCommand(query, dataConnection);
                CommandData.CommandTimeout = 60;
                try
                {
                    dataConnection.Open();
                    MySqlDataReader dataReader = CommandData.ExecuteReader();
                }
                catch(Exception a)
                {
                    MessageBox.Show(a.Message);
                }

            }
            else if(label3.Text == "Client N'Existe pas!")
            {// ajout table client
                    string query = "INSERT INTO client VALUES (default," + int.Parse(textBox1.Text) + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," + int.Parse(textBox5.Text) + ",'" + textBox6.Text + "'); ";
                    Console.WriteLine(query);
                    string SqlConnectionString = "datasource=localhost;username=root;passwrod=;database=csharp;";
                    MySqlConnection dataConnection = new MySqlConnection(SqlConnectionString);
                    MySqlCommand CommandData = new MySqlCommand(query, dataConnection);
                    CommandData.CommandTimeout = 60;
                    try
                    {
                        dataConnection.Open();
                        MySqlDataReader dataReader = CommandData.ExecuteReader();
                    
                    }
                    catch (Exception a)
                    {
                        MessageBox.Show(a.Message);
                    }
                    dataConnection.Close();
                    //ajout table contrat
                    string queryc = "INSERT INTO contrat VALUES (default,"+int.Parse(textBox1.Text)+",'"+comboBox1.Text+"')";
                    Console.WriteLine(query);
                    MySqlConnection dataConnection1 = new MySqlConnection(SqlConnectionString);
                    MySqlCommand CommandData1 = new MySqlCommand(queryc, dataConnection1);
                    CommandData1.CommandTimeout = 60;
                    try
                    {
                        dataConnection1.Open();
                        MySqlDataReader dataReader1 = CommandData1.ExecuteReader();
                        MessageBox.Show("Contrat et Client Bien Ajouter ! ");
                    }
                    catch (Exception a)
                    {
                        MessageBox.Show(a.Message);
                    }
                }

            }
            else
            {
                MessageBox.Show("Les champs ne doit pas étre vide !","Error");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {   if(comboBox1.Text!="")
            {
                printDialog1.Document = printDocument1;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {

                    printDocument1.Print();

                }
            }else
            {
                MessageBox.Show("choisir un type de contrat", "Error");

            }
       
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var fnt = new Font("Times new Roman", 14, FontStyle.Bold);
            int x = 100, y = 100;
            int dy = (int)fnt.GetHeight(e.Graphics) * 1; //change this factor to control line spacing


            e.Graphics.DrawString("\n Contrat de " + comboBox1.Text+Environment.NewLine,fnt,Brushes.Black, new PointF(x, y)); y += dy;
            e.Graphics.DrawString("\n Nom : " + textBox2.Text+Environment.NewLine, fnt, Brushes.Black, new PointF(x, y)); y += dy;
            e.Graphics.DrawString("\n Prénom  : " + textBox3.Text+Environment.NewLine, fnt, Brushes.Black, new PointF(x, y)); y += dy;
            e.Graphics.DrawString("\n Cin  : " + textBox1.Text+Environment.NewLine, fnt, Brushes.Black, new PointF(x, y)); y += dy;
            e.Graphics.DrawString("\n Adrésse : " + textBox4.Text+Environment.NewLine, fnt, Brushes.Black, new PointF(x, y)); y += dy;
            e.Graphics.DrawString("\n Téléphone : " + textBox5.Text+Environment.NewLine, fnt, Brushes.Black, new PointF(x, y)); y += dy;
            e.Graphics.DrawString("\n Email : " + textBox6.Text+Environment.NewLine, fnt, Brushes.Black, new PointF(x, y)); y += dy;
            e.Graphics.DrawString("\n Signature Responsable  \t \t \t Signature Client   " + Environment.NewLine, fnt, Brushes.Black, new PointF(x, y)); y += dy;


        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
