using AdTrafficWebApp.BLL;
using AdTrafficWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using AdTrafficWebApp.Validation;

namespace AdTrafficWebApp.GUI
{
    public partial class Registeration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            User newUser = new User();
            string userId = txtUserId.Text.Trim();
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();
            string role = ddlRole.SelectedValue;

            

            // Validate inputs (you can add more validation logic as needed)
            if (string.IsNullOrEmpty(userId)|| string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                // Display error message
                MessageBox.Show( "All fields are required.","Warning");
                return;
            }
            if (!Validator.IsValid(userId)) 
            {
                MessageBox.Show("User ID must be 4-digit number", "Invalid ID");
                txtUserId.Text = "";
                txtUserId.Focus();
                return;
            }

            if (newUser.IsDuplicateUserID(Convert.ToInt32(userId)))
            {
                MessageBox.Show("User ID exists", "Invalid");
                txtUserId.Text = "";
                txtUserId.Focus();
                return;
            }

            // Create a new User object
            newUser.UserId = Convert.ToInt32(userId); newUser.Password=password; newUser.Email = email; newUser.RoleName = role;newUser.UserName= userName;

            // Call your DAL method to register the user using the newUser object


            newUser.Register(newUser);
            MessageBox.Show("Registeration successful", "Ok");
            Response.Redirect("Login.aspx");

        }
    }
}