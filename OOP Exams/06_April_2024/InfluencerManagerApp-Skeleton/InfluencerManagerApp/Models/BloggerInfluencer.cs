namespace InfluencerManagerApp.Models
{
    public class BloggerInfluencer : Influencer
    {
        private const double engagementRateValue = 2.0;
        private const double factor = 0.2;
        public BloggerInfluencer(string userName, int followers)
            : base(userName, followers, engagementRateValue)
        {
        }

        public override int CalculateCampaignPrice()
        {
            return (int)Math.Floor(Followers * EngagementRate * factor);
        }
    }
}
