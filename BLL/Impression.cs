using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdTrafficWebApp.BLL
{
    public class Impression
    {
        private int impressionId;
        private int campaignId;
        private int userId;
        private DateTime timeStamp;

        public int ImpressionId { get => impressionId; set => impressionId = value; }
        public int CampaignId { get => campaignId; set => campaignId = value; }
        public int UserId { get => userId; set => userId = value; }
        public DateTime TimeStamp { get => timeStamp; set => timeStamp = value; }

        public Impression()
        {
            impressionId = 0;
            campaignId = 0;
            userId = 0;
            timeStamp = DateTime.MinValue;
        }
    }
}