using DataLayer.Entities;
using MyContacts.Core.Repository.Interfaces;
using MyContacts.Core.Repository.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Media.Effects;

namespace MyContacts
{
    public partial class FrmAddorEdite : Form
    {
        private IUser _user;
        public int UserId = 0;


        #region دیزاین
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
                               (
                                   int nLeftRect,     // x-coordinate of upper-left corner
                                   int nTopRect,      // y-coordinate of upper-left corner
                                   int nRightRect,    // x-coordinate of lower-right corner
                                   int nBottomRect,   // y-coordinate of lower-right corner
                                   int nWidthEllipse, // width of ellipse
                                   int nHeightEllipse // height of ellipse
                               );
        public FrmAddorEdite()
        {
            InitializeComponent();
            _user = new UserService();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        #endregion
        #region ValidateInpute
        bool ValidateInpute() 
        {
            if(txtUser.Text=="")
            {
              
             ErrorLable.Text = "لطفا نام را وارد نمایید.";
                btnAddEdite.Enabled = false;
                btnAddEdite.BackColor = Color.FromArgb(193, 18, 31);
               return false;
            }
            else if (txtّFamily.Text == "")
            {
                errorLablef.Text = "لطفا نام خانوادگی را وارد نمایید.";
                btnAddEdite.Enabled = false;
                btnAddEdite.BackColor = Color.FromArgb(193, 18, 31);
                return false;

            }
            else if (txtMobile.Text == "")
            {
                ErrorLable.Text = "لطفا شماره تماس را وارد نمایید.";
                btnAddEdite.Enabled = false;
                btnAddEdite.BackColor = Color.FromArgb(193, 18, 31);
                return false;
            }
            else if (numericAge.Value == 0)
            {
                ErrorLable.Text = "لطفا سن را وارد نمایید.";
                btnAddEdite.Enabled = false;
                btnAddEdite.BackColor = Color.FromArgb(193, 18, 31);
                return false;
            }




            return true; 
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void btnAddEdite_Click(object sender, EventArgs e)
        {
            try
            {
               if(ValidateInpute()) 
               {
                    if (btnAddEdite.Text == "ویرایش")
                    {
                        User user = _user.GetUserByUserId(UserId);
                        user.Name = txtUser.Text;
                        user.Family = txtّFamily.Text;
                        user.Mobile = txtMobile.Text;
                        user.Age = (Int32)(numericAge.Value);
                        user.Address = txtAddress.Text;
                       _user.UpdateUser( user);
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                         User user = new User();
                         user.Name =txtUser.Text;
                         user.Family=txtّFamily.Text;
                         user.Mobile= txtMobile.Text;
                         user.Age = (Int32)(numericAge.Value);
                         user.Address = txtAddress.Text;
                        _user.AddUSer(user);
                        DialogResult = DialogResult.OK;
                    }

               }
            }
            catch (Exception er)
            {
                MessageBox.Show ("ثبت مشترک با مشکل مواج شد",er.Message,MessageBoxButtons.OK,MessageBoxIcon.Error ) ;
            }


           
        }
        #region item changed Ac
        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if(btnAddEdite.Enabled == false)
            {
                btnAddEdite.Enabled=true;
                ErrorLable.Text = "";
                btnAddEdite.BackColor = Color.White;
            }
        }

        private void txtّFamily_TextChanged(object sender, EventArgs e)
        {
            if (btnAddEdite.Enabled == false)
            {
                btnAddEdite.Enabled = true;
                errorLablef.Text = "";
                btnAddEdite.BackColor = Color.White;
            }
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            if (btnAddEdite.Enabled == false)
            {
                btnAddEdite.Enabled = true;
                errorLablef.Text = "";
                btnAddEdite.BackColor = Color.White;
            }
        }

        private void numericAge_ValueChanged(object sender, EventArgs e)
        {
            if (btnAddEdite.Enabled == false)
            {
                btnAddEdite.Enabled = true;
                ErrorLable.Text = "";
                btnAddEdite.BackColor = Color.White;
            }
        }

        #endregion

        private void FrmAddorEdite_Load(object sender, EventArgs e)
        {
            if (btnAddEdite.Text == "ویرایش")
            {
                User user = _user.GetUserByUserId(UserId);
                txtUser.Text = user.Name;
                txtّFamily.Text = user.Family;
                txtMobile.Text = user.Mobile;
                txtAddress.Text = user.Address;
                numericAge.Value = (Int32)user.Age;
            }

        }
    }
}
