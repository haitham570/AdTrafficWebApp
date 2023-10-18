using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using AdTrafficWebApp.BLL;

namespace AdTrafficWebApp.DAL
{
    public class CampaignDB
    {
        public static List<Campaign> GetCampaignsList()
        {
            List<Campaign> campaigns = new List<Campaign>();
            using(SqlConnection conn = UtilityDB.ConnectDB())
            {
                SqlCommand cmdList = new SqlCommand("Select * from Campaigns",conn);
                SqlDataReader reader = cmdList.ExecuteReader();
                while (reader.Read())
                {
                    Campaign campaign = new Campaign();
                    campaign.CampaignId = Convert.ToInt32(reader["CampaignId"]);
                    campaign.Title = reader["Title"].ToString();
                    campaign.Description = reader["Description"].ToString();
                    campaign.ImpressionCount = Convert.ToInt32(reader["ImpressionCount"]);
                    campaign.ImageUrl = reader["ImageUrl"].ToString();
                    campaign.DateTime = Convert.ToDateTime (reader["DateTime"]);

                    campaigns.Add(campaign);
                }
            }
            return campaigns;
        }

        public static void CreateCampaign(Campaign campaign)
        {
            using (SqlConnection conn = UtilityDB.ConnectDB())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Campaigns (Title, Description, ImageUrl,ImpressionCount) VALUES (@Title, @Description, @ImageUrl, 0)";
                cmd.Parameters.AddWithValue("@Title", campaign.Title);
                cmd.Parameters.AddWithValue("@Description", campaign.Description);
                cmd.Parameters.AddWithValue("@ImageUrl", campaign.ImageUrl);
                cmd.Parameters.AddWithValue("@DataTime", campaign.DateTime);

                 cmd.ExecuteNonQuery();

                
            }
        }

        private static string HandleImageUpload(HttpPostedFile imageFile)
        {
            try
            {
                // Check if an image file is uploaded
                if (imageFile != null && imageFile.ContentLength > 0)
                {
                    // Get the file name from the uploaded file
                    string fileName = Path.GetFileName(imageFile.FileName);

                    // Save the image file on the server's filesystem
                    string imagePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads"), fileName);
                    imageFile.SaveAs(imagePath);

                    // Return the image file name
                    return fileName;
                }
                return null; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("null error");
                return null;
            }
        }

    }
}