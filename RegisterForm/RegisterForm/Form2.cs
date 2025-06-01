using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            //hiding the password
            textBox2.UseSystemPasswordChar = true; 
            textBox3.UseSystemPasswordChar = true;

            //show hide password
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //email validation
            string email = textBox1.Text;
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email is Empty", "Email Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (isValidEmail(email))
            {
                MessageBox.Show("Valid Email Address", "Email Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid Email Address", "Email Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //password validation
            string password = textBox2.Text;
            string confirmpassword = textBox3.Text;
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password is Empty", "Password Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (password == confirmpassword)
            {
                MessageBox.Show("Passwords are match", "Password Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Password are not match", "Password Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DateTime birthdate = dateTimePicker1.Value;
            DateTime currentdate = DateTime.Now;

            int age = currentdate.Year - birthdate.Year;

            string birthString = birthdate.ToString("yyyy-MM-dd");
            string ageString = age.ToString();

            String selectedGenderVal = GetValueGender(); 

            String selectedCourse = comboBox1.Text;

            MessageBox.Show($"Email is {email} \n" +
                $"Gender is {selectedGenderVal} \n" +
                $"Date of Birth is {birthString} \n" +
                $"Age is {ageString} \n" +
                $"Selected course is {selectedCourse}", "",
                MessageBoxButtons.OK,MessageBoxIcon.None);
        }
        private bool isValidEmail(string email)
        {
            try
            {
                var mailaddress = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private string GetValueGender()
        {
            if (radioButton1.Checked)
            {
                return radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                return radioButton2.Text;
            }
            else return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            radioButton1.Checked = false;
            radioButton2.Checked = false;

            comboBox1.SelectedIndex = -1;

            dateTimePicker1.Value = DateTime.Now;

            checkBox1.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool show = checkBox1.Checked;
            textBox2.UseSystemPasswordChar = !show;
            textBox3.UseSystemPasswordChar = !show;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
