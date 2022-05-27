using Game.Cars;
using Game.Cars.LowRiderClose;
using Game.Cars.RacingCar;
using Tools;

namespace Profile
{
    internal class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public CarModel currentCar;
        public readonly CarState carState;

        public ProfilePlayer(float speedCar, GameState initialState, CarState carState) : this(speedCar)
        {
            CurrentState.Value = initialState;
            this.carState = carState;

            ChooseCar(speedCar);
        }

        private void ChooseCar(float speedCar)
        {
            switch (carState)
            {
                case CarState.LowRiderClose:
                    currentCar = new LowRiderCloseModel(speedCar);
                    break;

                case CarState.RacingCar:
                    currentCar = new RacingCarModel(speedCar);
                    break;

                default:
                    currentCar = null;
                    break;
            }
        }

        public ProfilePlayer(float speedCar)
        {
            CurrentState = new SubscriptionProperty<GameState>();
        }
    }
}