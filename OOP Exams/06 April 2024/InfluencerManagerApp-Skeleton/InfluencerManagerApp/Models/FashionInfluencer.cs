namespace InfluencerManagerApp.Models
{
    public class FashionInfluencer : Influencer
    {
        private const double engagementRateValue = 4.0;
        private const double factor = 0.1;
        public FashionInfluencer(string userName, int followers)
            : base(userName, followers, engagementRateValue)
        {
        }

        public override int CalculateCampaignPrice()
        {
            return (int)Math.Floor(Followers * EngagementRate * factor);
        }
    }
}
