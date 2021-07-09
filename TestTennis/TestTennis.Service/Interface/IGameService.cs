using TesteTennis.Data;

namespace TestTennis.Service.Interface
{
    public interface IGameService
    {
        Player Server { get; }
        Player Receiver { get; }

        string ShowScore();

        void ServerScoresPoint();

        void ReceiverScoresPoint();
    }
}