using Econtact.econtactClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactForm1
{
    public partial class Econtact : Form
    {
        public Econtact()
        {
            InitializeComponent();
        }
        contactClass c = new contactClass();

        private void BtmAdd_Click(object sender, EventArgs e)
        {
            //Get the value from the input fields
            c.FirstName = txtBoxLastName.Text;
            c.LastName = txtBoxLastName.Text;
            c.ContactNo = txtboxContactID.Text;
            c.Address = txtBoxAddress.Text;
            c.Gender = cmbGender.Text;

            //Inserting Data into Database using the method we created in previous episode
            bool success = c.Insert(c);
            if (success == true)
            {
                //Successfully Inserted
                MessageBox.Show("New Contact Successfully Inserted");
                //Call the Clear Method Here
                Clear();
            }
            else
            {
                //Failed to add Contact
                MessageBox.Show("Failed to add New Contact. Try Again");
            }
            //Load data on data Gridveiw
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;


        }

        private void Econtact_Load(object sender, EventArgs e)
        {
            //Load data on data Gridveiw
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Method to Clear Fields
        public void Clear()
        {
            txtBoxLastName.Text = "";
            txtBoxLastName.Text = "";
            txtboxContactID.Text = "";
            txtBoxAddress.Text = "";
            cmbGender.Text = "";
            txtboxContactID.Text = "";
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            //Get theData From textboxes
            c.ContactID = int.Parse(txtBoxAddress.Text);
            c.FirstName = txtBoxAddress.Text;
            c.LastName = txtBoxLastName.Text;
            c.ContactNo = txtboxContactID.Text;
            c.Address = txtBoxAddress.Text;
            //Update data in Database
            bool success = c.Update(c);
            if (success == true)
            {
                //Updated Successfully
                MessageBox.Show("Contact has been successfully Updated.");
                //Load data on data Gridveiw
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
                //Call Clear Method
                Clear();

            }
            else
            {
                //Failed to Update
                MessageBox.Show("Failed to Update Contact. Try Again.");
            }

        }

        private void DgvContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get data from Data grid View and Load it to the textboxes respectively
            //identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            txtboxContactID.Text = dgvContactList.Rows[rowIndex].Cells[0].Value.ToString();
            txtBoxLastName.Text = dgvContactList.Rows[rowIndex].Cells[1].Value.ToString();
            txtBoxLastName.Text = dgvContactList.Rows[rowIndex].Cells[2].Value.ToString();
            txtBoxAddress.Text = dgvContactList.Rows[rowIndex].Cells[3].Value.ToString();
            txtboxContactID.Text = dgvContactList.Rows[rowIndex].Cells[4].Value.ToString();
            txtBoxLastName.Text = dgvContactList.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            //Call Clear Method Here
            Clear();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //Get Data from the Textboxes
            c.ContactID = Convert.ToInt32(txtboxContactID.Text);
            bool success = c.Delete(c);
            if (success == true)
            {
                //Successfully Deleted
                MessageBox.Show("Contact successfully deleted.");
                //Refresh Data GridView
                //Load data on data Gridveiw
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
                //Call the Clear Method here
                Clear();
            }
            else
            {
                //Failed to Delete
                MessageBox.Show("Failed to Delete Contact. Try Again.");
            }
        }
        static string myconstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private string myconnstr;

        private void TxtboxSearch_TextChanged(object sender, EventArgs e)
        {



        }
    }
}
