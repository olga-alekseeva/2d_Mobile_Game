using Game.Cars.RacingCar;
using Game.Cars.LowRiderClose;
using Game.InputLogic;
using Game.TapeBackground;
using Profile;
using Tools;

namespace Game
{
    internal class GameController : BaseController
    {
        public GameController(ProfilePlayer profilePlayer)
        {
            var leftMoveDiff = new SubscriptionProperty<float>();
            var rightMoveDiff = new SubscriptionProperty<float>();

            var tapeBackgroundController = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
            AddController(tapeBackgroundController);

            var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.currentCar);
            AddController(inputGameController);

            var racingCarController = new RacingCarController();
            AddController(racingCarController);

            //var lowRiderClosedController = new LowRiderClosedController();
            //AddController(lowRiderClosedController);

        }
    }
}
