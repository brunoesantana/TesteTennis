using TesteTennis.Service.Interface;

namespace TesteTennis.Service
{
    public class NormalScore : IScore
    {
        public string Score { get; private set; }

        public bool Validate(int serverPoint, int receiverPoint)
        {
            var serverScore = GetScore(serverPoint);
            var receiverScore = GetScore(receiverPoint);

            Score = $"{serverScore}:{receiverScore}";

            return serverScore != "" && receiverScore != "";
        }

        private string GetScore(int point)
        {
            return point switch
            {
                0 => "Zero",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => "",
            };
        }
    }
}