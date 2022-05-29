using Game;
using Game.Cars;
using Game.Cars.LowRiderClose;
using Game.Cars.RacingCar;
using Game.Transport;
using Tools;
using Features.Inventory;

namespace Profile
{
    internal class ProfilePlayer
    {
        public readonly SubscriptionProperty<GameState> CurrentState;
        public readonly TransportModel CurrentTransport;
        public readonly InventoryModel Inventory;


        public ProfilePlayer(float transportSpeed, TransportType transportType, GameState initialState)
        {
            CurrentState = new SubscriptionProperty<GameState>(initialState);
            CurrentTransport = new TransportModel(transportSpeed, transportType);
            Inventory = new InventoryModel();
        }

       
    }
}