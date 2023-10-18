using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdTrafficWebApp.DAL;

namespace AdTrafficWebApp.BLL
{
    public class Campaign
    {
        private int campaignId;
        private string title;
        private string description;
        private int impressionCount;
        private string imageUrl;
        private DateTime dateTime;

        public int CampaignId { get => campaignId; set => campaignId = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public int ImpressionCount { get => impressionCount; set => impressionCount = value; }
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }

        public Campaign()
        {
            campaignId = 0;
            title = string.Empty;
            description = string.Empty;
            impressionCount = 0;
            imageUrl = string.Empty;
            dateTime = DateTime.MinValue;
            
        }

        public List<Campaign> ListCampaigns() => CampaignDB.GetCampaignsList();

    }
}