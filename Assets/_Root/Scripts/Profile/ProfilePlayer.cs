using Tools;
using Game.Cars.RacingCar;
using Game.Cars;




namespace Profile
{
    internal class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public readonly CarModel CurrentCar;
        public readonly CarState carState;


        public ProfilePlayer(float speedCar, GameState initialState, CarState carState) : this(speedCar)
        {
            CurrentState.Value = initialState;
            this.carState = carState;
        }

        public ProfilePlayer(float speedCar)
        {
            CurrentState = new SubscriptionProperty<GameState>();
           //CurrentCar = new CarModel(speedCar);
        }
        //private void ChooseCar(fload speedCar)
        //{
        //    switch (carState)
        //    {
        //        case CarState.LowRiderClose:
        //            CurrentCar  = new LowRiderModel

        //    }
        //}
    }
}