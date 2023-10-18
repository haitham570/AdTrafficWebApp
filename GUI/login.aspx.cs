using AdTrafficWebApp.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdTrafficWebApp.Validation;
using System.Windows.Forms;
using AdTrafficWebApp.DAL;

namespace AdTrafficWebApp.GUI
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Server.Transfer("Registeration.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            string input = string.Empty;
            input = txtUserId.Text;
            if (!Validator.IsValid(input))
            {
                MessageBox.Show("User Id must be 4 digit number", "Invalid ID");
                txtUserId.Text = "";
                txtUserId.Focus();
                return;
            }
            int userId = Convert.ToInt32(txtUserId.Text.Trim());
            string password = txtPassword.Text.Trim();  
            if (txtPassword.Text.Length>0 && txtUserId.Text.Length>0)
            {
                if (user.login(userId, password))
                {
                    // Store user information in session for future use
                    Session["UserId"] = userId;

                    // Redirect to dashboard
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    // Display error message (for simplicity, you can enhance this)
                    MessageBox.Show("Invalid User id or password", "Invalid Credentials");
                    txtUserId.Text = "";
                    txtUserId.Focus();
                    txtPassword.Text = "";
                    return;
                }
            }
        }
    }
}