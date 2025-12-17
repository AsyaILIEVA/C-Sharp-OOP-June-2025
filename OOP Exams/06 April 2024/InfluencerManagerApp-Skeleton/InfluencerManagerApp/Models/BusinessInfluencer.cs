namespace InfluencerManagerApp.Models
{
    public class BusinessInfluencer : Influencer
    {
        private const double engagementRateValue = 3.0;
        private const double factor = 0.15;
        public BusinessInfluencer(string userName, int followers) 
            : base(userName, followers, engagementRateValue)
        {
        }

        public override int CalculateCampaignPrice()
        {
            return (int)Math.Floor(Followers * EngagementRate * factor);
        }
    }
}
