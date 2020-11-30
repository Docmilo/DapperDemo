using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBApp
{
    public partial class Form1 : Form
    {
        //Dapper tutorial - https://dapper-tutorial.net/dapper 

        List<Person> people = new List<Person>();
        public Form1()
        {
            InitializeComponent();
            //Wire the listbox data source to the people list
            UpdateBinding();
        }

        private void UpdateBinding()
        {
            lstBoxPeople.DataSource = people;
            lstBoxPeople.DisplayMember = "FullInfo";
        }

    
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Call to the DB and search for the last name
            DataAccess dbAccess = new DataAccess();

            people = dbAccess.GetPeople(txtLastName.Text);
            //Reset our data bindings 
            UpdateBinding();

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DataAccess dbAccess = new DataAccess();
            dbAccess.InsertPerson(txtFirstName.Text, txtLName.Text, txtEmail.Text, txtPhone.Text);
            txtFirstName.Text = "";
            txtLName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }
    }
}