using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ISBNextractor
{
    public partial class EnterISBN : Form
    {
        string bookname;
        string isbn;

        public EnterISBN(string b)
        {
            bookname = b;
            InitializeComponent();
        }

        private void EnterISBN_Load(object sender, EventArgs e)
        {
            bookName.Text = bookname;
        }

        private void save_Click(object sender, EventArgs e)
        {
            isbn = textBox1.Text;
            this.Close();
        }
        public string Isbn
        {
            get
            {
                return isbn;
            }
            set
            {
                isbn = value;
            }
        }
    }
}
