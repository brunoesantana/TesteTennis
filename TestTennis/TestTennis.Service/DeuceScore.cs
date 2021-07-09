using TesteTennis.CrossCutting;
using TesteTennis.Service.Interface;

namespace TesteTennis.Service
{
    public class DeuceScore : IScore
    {
        public string Score { get; private set; }

        public DeuceScore()
        {
            Score = "";
        }

        public bool Validate(int serverPoint, int receiverPoint)
        {
            if (serverPoint == receiverPoint && serverPoint == ConstantUtil.THREE)
            {
                Score = ConstantUtil.DEUCE;
                return true;
            }

            if (serverPoint == ConstantUtil.FOUR && receiverPoint == ConstantUtil.THREE)
            {
                Score = ConstantUtil.ADVANTAGE_SERVER;
                return true;
            }

            if (serverPoint == ConstantUtil.THREE && receiverPoint == ConstantUtil.FOUR)
            {
                Score = ConstantUtil.ADVANTAGE_RECEIVER;
                return true;
            }

            return false;
        }
    }
}