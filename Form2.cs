using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            DisplayStudent();
        }


        SqlConnection Con = new SqlConnection(connectionString: @"Data Source=KAWODYA\SQLEXPRESS;Initial Catalog=SMS;Integrated Security=True;Encrypt=False");

        private void DisplayStudent()
        {
            Con.Open();
            string Query = "select * from STD ";    
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        int SId = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to add student details?", "Add Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(comboBox2.Text) || string.IsNullOrWhiteSpace(comboBox3.Text) || string.IsNullOrWhiteSpace(comboBox4.Text))
                {
                    MessageBox.Show(" Missing Information");
                }
                else
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("insert into STD(Student_Name,Gender,Telephone,Teacher_Name,Subject,Session) VALUES(@SN,@G,@TP,@TN,@SUB,@SE)", Con))
                        {
                            cmd.Parameters.AddWithValue("@SN", textBox1.Text);
                            cmd.Parameters.AddWithValue("@G", comboBox1.Text);
                            cmd.Parameters.AddWithValue("@TP", textBox2.Text);
                            cmd.Parameters.AddWithValue("@TN", comboBox2.Text);
                            cmd.Parameters.AddWithValue("@SUB", comboBox3.Text);
                            cmd.Parameters.AddWithValue("@SE", comboBox4.Text);


                            Con.Open();
                            cmd.ExecuteNonQuery();
                            Con.Close();

                        }
                        MessageBox.Show("Record Entered Successfully");
                        DisplayStudent();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }


            
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to update student details?", "Update Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(comboBox2.Text) || string.IsNullOrWhiteSpace(comboBox3.Text) || string.IsNullOrWhiteSpace(comboBox4.Text))
                {
                    MessageBox.Show(" Missing Information");
                }
                else
                {
                    try
                    {

                        using (SqlCommand cmd = new SqlCommand("UPDATE STD SET Student_Name=@SN,Gender=@G,Telephone=@TP,Teacher_Name=@TN,Subject=@SUB,Session=@SE WHERE Student_Id=@key", Con))
                        {
                            cmd.Parameters.AddWithValue("@SN", textBox1.Text);
                            cmd.Parameters.AddWithValue("@G", comboBox1.Text);
                            cmd.Parameters.AddWithValue("@TP", textBox2.Text);
                            cmd.Parameters.AddWithValue("@TN", comboBox2.Text);
                            cmd.Parameters.AddWithValue("@SUB", comboBox3.Text);
                            cmd.Parameters.AddWithValue("@SE", comboBox4.Text);
                            cmd.Parameters.AddWithValue("@key", SId);


                            Con.Open();
                            cmd.ExecuteNonQuery();
                            Con.Close();


                        }
                        MessageBox.Show("Record Update Successfully");
                        DisplayStudent();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete student details?", "Delete Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (SId == 0)
                {
                    MessageBox.Show("Please select a record to delete");
                }
                else
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM STD WHERE Student_ID=@key", Con))
                        {
                            cmd.Parameters.AddWithValue("@key", SId);

                            Con.Open();
                            cmd.ExecuteNonQuery();
                            Con.Close();
                        }

                        MessageBox.Show("Record Deleted Successfully");
                        DisplayStudent();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to clear student details?", "Clear Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClearFields();
            }
            
        }
        private void ClearFields()
        {
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            textBox2.Clear();
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
        }

    private void button5_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you want to exit login page", "Exit Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                Form1 obj = new Form1();
                obj.Show();
                this.Hide();
            }
            
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet2.STD' table. You can move, or remove it, as needed.
            this.sTDTableAdapter1.Fill(this.dataSet2.STD);
            // TODO: This line of code loads data into the 'dataSet1.STD' table. You can move, or remove it, as needed.
            //this.sTDTableAdapter.Fill(this.dataSet1.STD);

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index != -1)
            {
                SId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                comboBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                comboBox4.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
        }

        

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            PaperSize paperSize = new PaperSize("Custom", 1003, 493);
            e.PageSettings.PaperSize = paperSize;
            e.PageSettings.Landscape = true;
            Rectangle rect = new Rectangle(0, 0, paperSize.Width, paperSize.Height);
            e.Graphics.DrawImage(bmp, rect);

        }

        Bitmap bmp;
        
        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to print student details?", "Print Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Graphics g = this.CreateGraphics();
                bmp = new Bitmap(1003, 493, g);
                Graphics mg = Graphics.FromImage(bmp);
                mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, new Size(1003, 493));

                printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                printPreviewDialog1.Document = printDocument1;

                printPreviewDialog1.Document.DefaultPageSettings.Landscape = true;
                printPreviewDialog1.ShowDialog();
            }

            

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you want to exit", "Exit Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
