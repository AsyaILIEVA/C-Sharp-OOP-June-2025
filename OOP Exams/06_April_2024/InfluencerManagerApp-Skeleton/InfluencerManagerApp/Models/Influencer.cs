using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;


namespace InfluencerManagerApp.Models
{
    public abstract class Influencer : IInfluencer
    {
        private string userName;
        private int followers;
        private double engagementRate;
        private double income;
        private readonly List<string> participations;

        protected Influencer(string userName, int followers, double engagementRate)
        {
            Username = userName;
            Followers = followers;
            EngagementRate = engagementRate;

            Income = 0;
            participations = new List<string>();
        }
        public string Username

        {
            get => userName;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.UsernameIsRequired);
                }

                userName = value;
            }
        }
        

        public int Followers
        {             
          get => followers; 
            
          private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.FollowersCountNegative);
                }

                followers = value;
            } 
        }

        public double EngagementRate
        {
            get => engagementRate;

            private set
            {
                engagementRate = value;
            }
        }

        public double Income
        {
            get => income;
            private set
            {
                income = value;
            }
        }

        public IReadOnlyCollection<string> Participations => participations.AsReadOnly();

        public abstract int CalculateCampaignPrice();        

        public void EarnFee(double amount) => income += amount;

        public void EndParticipation(string brand) => participations.Remove(brand);


        public void EnrollCampaign(string brand) => participations.Add(brand);
        

        public override string ToString()
        {
            return $"{Username} - Followers: {Followers}, Total Income: {Income}";
        }
    }
}
