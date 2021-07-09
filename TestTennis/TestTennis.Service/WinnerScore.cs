using TesteTennis.CrossCutting;
using TesteTennis.Service.Interface;

namespace TestTennis.Service
{
    public class WinnerScore : IScore
    {
        private readonly string _playerServerName;
        private readonly string _playerReceiverName;

        public string Score { get; private set; }

        public WinnerScore(string serverName, string receiverName)
        {
            _playerServerName = serverName;
            _playerReceiverName = receiverName;
        }

        public bool Validate(int serverPoint, int receiverPoint)
        {
            if (serverPoint == ConstantUtil.FIVE || serverPoint == ConstantUtil.FOUR)
            {
                Score = $"{ConstantUtil.WINNER}: {_playerServerName}";
                return true;
            }

            if (receiverPoint == ConstantUtil.FIVE || receiverPoint == ConstantUtil.FOUR)
            {
                Score = $"{ConstantUtil.WINNER}: {_playerReceiverName}";
                return true;
            }

            return false;
        }
    }
}