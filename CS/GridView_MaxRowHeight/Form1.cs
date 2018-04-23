using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace GridView_MaxRowHeight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Users myUsers = new Users();
        private void Form1_Load(object sender, EventArgs e)
        {
            myUsers.Add(new User("Antuan", "Lorem ipsum"));
            myUsers.Add(new User("Bill", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit,"));
            myUsers.Add(new User("Charli", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat"));
            myUsers.Add(new User("Denn", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat"));
            myUsers.Add(new User("Eva", "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat"));
            customGridControl1.DataSource = myUsers;
            gridColumn1.FieldName = "Name";
            gridColumn2.FieldName = "Coment";

        }
    }
    public class User
    {
        string name, coment;
        public User(string name, string coment)
        {
            this.name = name;
            this.coment = coment;
        }
        public string Name { set { name = value; } get { return name; } }
        public string Coment { set { coment = value; } get { return coment; } }
    }
    public class Users : ArrayList
    {
        public override object this[int index] { get { return (User)base[index]; } set { base[index] = value; } }
    }
}