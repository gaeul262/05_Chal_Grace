using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Challenge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtStudentNo.Text) ||
                    string.IsNullOrWhiteSpace(txtLastName.Text) ||
                    string.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    MessageBox.Show("Please fill in the required fields.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fileName = txtStudentNo.Text + ".txt";
                string filePath = Path.Combine(docPath, fileName);

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Student No.: " + txtStudentNo.Text);
                    writer.WriteLine($"Full Name: {txtLastName.Text}, {txtFirstName.Text} {txtMI.Text}");
                    writer.WriteLine("Program: " + cbProgram.Text);
                    writer.WriteLine("Age: " + numAge.Text);
                    writer.WriteLine("Gender: " + cbGender.Text);
                    writer.WriteLine("Birthday: " + dtBirthday.Value);
                    writer.WriteLine("Contact No.: " + txtContact.Text);

                    writer.Flush();
                }

                MessageBox.Show($"File '{fileName}' created successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbProgram_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] programs = { "Bachelor of Science in Information Technology", "Bachelor of Science in Hospitality Management",
                "Bachelor of Science in Tourism Management", "Bachelor of Multimedia Arts" };
            cbProgram.Items.AddRange(programs);

            string[] Gender = {"Male", "Female"};
            cbGender.Items.AddRange(Gender);
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            FrmStudentRecord studrec = new FrmStudentRecord();
            studrec.ShowDialog();
        }
    }
}
// Michael G