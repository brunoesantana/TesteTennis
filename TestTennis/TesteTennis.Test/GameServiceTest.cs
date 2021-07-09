using NUnit.Framework;
using TesteTennis.CrossCutting;
using TestTennis.Service;
using TestTennis.Service.Interface;

namespace TesteTennis.Test
{
    public class GameServiceTest
    {
        private IGameService _gameService;

        [SetUp]
        public void Setup()
        {
            _gameService = new GameService(ConstantUtil.PLAYER_SERVER, ConstantUtil.PLAYER_RECEIVER);
        }

        [Test]
        public void Two_players_join_game()
        {
            Assert.AreEqual(_gameService.Server.Name, "Roger Federer");
            Assert.AreEqual(_gameService.Receiver.Name, "Guga");
        }

        [Test]
        public void Score_zero_zero()
        {
            var result = _gameService.ShowScore();

            Assert.AreEqual(result, "Zero:Zero");
        }

        [Test]
        public void Score_fifteen_fifteen()
        {
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();

            var result = _gameService.ShowScore();

            Assert.AreEqual(result, "Fifteen:Fifteen");
        }

        [Test]
        public void Score_thirty_thirty()
        {
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();

            var result = _gameService.ShowScore();

            Assert.AreEqual(result, "Thirty:Thirty");
        }

        [Test]
        public void Player_server_scores_point_fifteen_zero()
        {
            _gameService.ServerScoresPoint();

            var result = _gameService.ShowScore();

            Assert.AreEqual(result, "Fifteen:Zero");
        }

        [Test]
        public void Player_server_scores_two_points_thirty_zero()
        {
            _gameService.ServerScoresPoint();
            _gameService.ServerScoresPoint();

            var result = _gameService.ShowScore();

            Assert.AreEqual(result, "Thirty:Zero");
        }

        [Test]
        public void Player_server_scores_three_points_forty_zero()
        {
            _gameService.ServerScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ServerScoresPoint();

            var result = _gameService.ShowScore();

            Assert.AreEqual(result, "Forty:Zero");
        }

        [Test]
        public void Player_receiver_scores_point_forty_fifteen()
        {
            _gameService.ServerScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();

            var result = _gameService.ShowScore();

            Assert.AreEqual(result, "Forty:Fifteen");
        }

        [Test]
        public void Player_server_scores_four_points_and_win()
        {
            _gameService.ServerScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();

            var result = _gameService.ShowScore();

            Assert.AreEqual(result, "Winner: Roger Federer");
        }

        [Test]
        public void Player_receiver_win()
        {
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();
            _gameService.ReceiverScoresPoint();
            _gameService.ReceiverScoresPoint();

            var result = _gameService.ShowScore();

            Assert.AreEqual(result, "Winner: Guga");
        }

        [Test]
        public void Player_server_get_advantage()
        {
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();

            var deuceResult = _gameService.ShowScore();
            Assert.AreEqual(deuceResult, "Deuce");

            _gameService.ServerScoresPoint();
            var result = _gameService.ShowScore();
            Assert.AreEqual(result, "Advantage server");
        }

        [Test]
        public void Player_server_wins_after_advantage()
        {
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();

            var deuceResult = _gameService.ShowScore();
            Assert.AreEqual(deuceResult, "Deuce");

            _gameService.ServerScoresPoint();
            var advantageResult = _gameService.ShowScore();
            Assert.AreEqual(advantageResult, "Advantage server");

            _gameService.ServerScoresPoint();
            var result = _gameService.ShowScore();
            Assert.AreEqual(result, "Winner: Roger Federer");
        }

        [Test]
        public void Player_receiver_get_advantage()
        {
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();

            var deuceResult = _gameService.ShowScore();
            Assert.AreEqual(deuceResult, "Deuce");

            _gameService.ReceiverScoresPoint();
            var result = _gameService.ShowScore();
            Assert.AreEqual(result, "Advantage receiver");
        }

        [Test]
        public void Player_receiver_wins_after_advantage()
        {
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();

            var deuceResult = _gameService.ShowScore();
            Assert.AreEqual(deuceResult, "Deuce");

            _gameService.ReceiverScoresPoint();
            var advantageResult = _gameService.ShowScore();
            Assert.AreEqual(advantageResult, "Advantage receiver");

            _gameService.ReceiverScoresPoint();
            var finalResult = _gameService.ShowScore();
            Assert.AreEqual(finalResult, "Winner: Guga");
        }

        [Test]
        public void Deuce_result()
        {
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();

            var result = _gameService.ShowScore();
            Assert.AreEqual(result, "Deuce");
        }

        [Test]
        public void Deuce_after_server_get_advantange()
        {
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();

            var deuceResult = _gameService.ShowScore();
            Assert.AreEqual(deuceResult, "Deuce");

            _gameService.ServerScoresPoint();
            var advantageResult = _gameService.ShowScore();
            Assert.AreEqual(advantageResult, "Advantage server");

            _gameService.ReceiverScoresPoint();
            var finalResult = _gameService.ShowScore();
            Assert.AreEqual(finalResult, "Deuce");
        }

        [Test]
        public void Deuce_after_receiver_get_advantange()
        {
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();
            _gameService.ReceiverScoresPoint();
            _gameService.ServerScoresPoint();

            var deuceResult = _gameService.ShowScore();
            Assert.AreEqual(deuceResult, "Deuce");

            _gameService.ReceiverScoresPoint();
            var advantageResult = _gameService.ShowScore();
            Assert.AreEqual(advantageResult, "Advantage receiver");

            _gameService.ServerScoresPoint();
            var finalResult = _gameService.ShowScore();
            Assert.AreEqual(finalResult, "Deuce");
        }
    }
}