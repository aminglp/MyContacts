using MyContacts.Core.Repository.Interfaces;
using MyContacts.Core.Repository.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer.Entities;


namespace MyContacts
{
    public partial class Form1 : Form
    {
        private IUser _user;
        int Id;
        int userId;
        int filter;

        public Form1()
        {
            InitializeComponent();
            _user = new UserService();
        }




        public void BindContacts()
        {
            dgContaxts.AutoGenerateColumns = false;
            dgContaxts.DataSource = null;
            dgContaxts.DataSource = _user.GetAllUser();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            BindContacts();
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            BindContacts();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            FrmAddorEdite frmAddorEdite = new FrmAddorEdite();
            frmAddorEdite.ShowDialog();
            if(frmAddorEdite.DialogResult == DialogResult.OK )
            {
                BindContacts();
            }
        }

        private void dgContaxts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            Id = int.Parse(dgContaxts.Rows[dgContaxts.CurrentRow.Index].Cells["Column5"].Value.ToString());
        }
        
        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmAddorEdite frmAddorEdite = new FrmAddorEdite();
            frmAddorEdite.UserId=Id;
            frmAddorEdite.btnAddEdite.Text = "ویرایش";
            frmAddorEdite.ShowDialog();
            if (frmAddorEdite.DialogResult == DialogResult.OK)
            {
                BindContacts();
            }

        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userId = (Int32)(dgContaxts.CurrentRow.Cells[0].Value); 
            if(MessageBox.Show("از حذف مشترک مورد نظر مطمئن هستید؟", "", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes )
            {
                _user.Delete(userId);
                BindContacts();

            }
           
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            List<User> users = new List<User>();
            users.AddRange(_user.GetAllUser());
            dgContaxts.DataSource = users.Where(p=>p.Name.Contains(txtSearch.Text) || p.Family.Contains(txtSearch.Text)).ToList();
        }



        private void btnFilter_Click_1(object sender, EventArgs e)
        {
            if (filter == 0)
            {
                btnFilter.Text = "نزولی";
                List<User> users = new List<User>();
                users.AddRange(_user.GetAllUser());
                dgContaxts.DataSource=users.OrderByDescending(p=>p.Name).ToList();  
                filter = 1;
            }
            else
            {
                btnFilter.Text = "صعودی";
                List<User> users = new List<User>();
                users.AddRange(_user.GetAllUser());
                dgContaxts.DataSource = users.OrderBy(p => p.Name).ToList();
                filter = 0;
            }




        }
    }
}
