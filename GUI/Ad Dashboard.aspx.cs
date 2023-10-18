using AdTrafficWebApp.BLL;
using AdTrafficWebApp.DAL;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;
using System.Web.UI.HtmlControls;

namespace AdTrafficWebApp.GUI
{
    public partial class Ad_Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateCampaignList();
            }
        }

        private void PopulateCampaignList()
        {
            // Retrieve the list of campaigns from the database (CampaignDB.GetCampaigns())
            // For example:
            List<Campaign> campaigns = CampaignDB.GetCampaignsList();

            // Reference the <ul> element in your HTML
            var campaignList = FindControl("campaignList") as HtmlGenericControl;

            // Add campaigns as list items under the "Campaigns" heading
            foreach (var campaign in campaigns)
            {
                var anchor = new HtmlGenericControl("a");
                anchor.Attributes["href"] = "#";
                anchor.Attributes["class"] = "campaign-list";
                anchor.InnerText = campaign.Title;
                var listItem = new HtmlGenericControl("li");
                listItem.Controls.Add(anchor);
                campaignList.Controls.Add(listItem);
            }
        }


        protected void btnCreateCampaign_Click(object sender, EventArgs e)
        {
            if (fileCampaignImage.HasFile)
            {
                try
                {
                    string fileName=Path.GetFileName(fileCampaignImage.FileName);
                    string imagePath = Server.MapPath("~/Uploads/"  +  fileName);

                    fileCampaignImage.SaveAs(imagePath);

                    Campaign campaign = new Campaign();
                    campaign.Title = txtCampaignTitle.Text.Trim();
                    campaign.Description = txtCampaignDescription.Text.Trim();
                    campaign.ImageUrl = imagePath;
                    campaign.DateTime = DateTime.Now;

                    CampaignDB.CreateCampaign(campaign);

                    MessageBox.Show("Campaign created successfully");

                    PopulateCampaignList();

                    txtCampaignTitle.Text = "";
                    txtCampaignDescription.Text = "";
                    



                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}