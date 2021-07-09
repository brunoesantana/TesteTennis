using TesteTennis.CrossCutting;
using TesteTennis.Data;
using TesteTennis.Service;
using TesteTennis.Service.Interface;
using TestTennis.Service.Interface;

namespace TestTennis.Service
{
    public class GameService : IGameService
    {
        private readonly IScore _deuceScore;
        private readonly IScore _normalScore;
        private readonly IScore _winnerScore;

        private int _serverPoint;
        private int _receiverPoint;

        public Player Server { get; }
        public Player Receiver { get; }

        public GameService(string playerServerName, string playerReceiverName)
        {
            Server = new Player(playerServerName);
            Receiver = new Player(playerReceiverName);
            _deuceScore = new DeuceScore();
            _normalScore = new NormalScore();
            _winnerScore = new WinnerScore(playerServerName, playerReceiverName);
        }

        public string ShowScore()
        {
            if (_deuceScore.Validate(_serverPoint, _receiverPoint))
            {
                return _deuceScore.Score;
            }

            if (_normalScore.Validate(_serverPoint, _receiverPoint))
            {
                return _normalScore.Score;
            }

            return _winnerScore.Validate(_serverPoint, _receiverPoint) ? _winnerScore.Score : "";
        }

        public void ServerScoresPoint()
        {
            if (_serverPoint == ConstantUtil.THREE && _receiverPoint == ConstantUtil.FOUR)
                _receiverPoint--; //retira a vantagem do adversário
            else
                _serverPoint++;
        }

        public void ReceiverScoresPoint()
        {
            if (_serverPoint == ConstantUtil.FOUR && _receiverPoint == ConstantUtil.THREE)
                _serverPoint--; //retira a vantagem do adversário
            else
                _receiverPoint++;
        }
    }
}