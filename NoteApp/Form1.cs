/*
 * An application used to store notes using Window Forms 
 * User can:
 *      - create a title and message for note, and save 
 *      - preview created notes 
 *      - delete created notes 
 *      - create new notes 
 */

using System;
using System.Data;
using System.Windows.Forms;

namespace NoteApp
{
    public partial class Form1 : Form
    {
        DataTable table;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            // a DataTable object 
            table = new DataTable();

            // add two columns to table  
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Messages", typeof(string));

            // connect table object to dataGrid
            dataMessage.DataSource = table;
        }

        // clear former note to create new note 
        private void button1_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtBoxMessage.Clear();

        }

        // save note title and message into dataMessage 
        private void btnSave_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtTitle.Text, txtBoxMessage.Text);

            txtTitle.Clear();
            txtBoxMessage.Clear();
        }

        // select created note to read 
        private void btnRead_Click(object sender, EventArgs e)
        {
            // find which row is selected 
            int index = dataMessage.CurrentCell.RowIndex;

            // if any row is selected 
            if (index > -1)
            {
                // display title
                txtTitle.Text = table.Rows[index].ItemArray[0].ToString();

                // display message 
                txtBoxMessage.Text = table.Rows[index].ItemArray[1].ToString();
            }
        }

        // delete a created note 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // if a row is selected 
            int index = dataMessage.CurrentCell.RowIndex;

            // delete row 
            table.Rows[index].Delete();

        }
    }
}
