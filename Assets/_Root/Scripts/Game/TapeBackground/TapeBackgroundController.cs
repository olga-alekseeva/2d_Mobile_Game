using Tools;
using UnityEngine;

namespace Game.TapeBackground
{
    internal class TapeBackgroundController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath("Prefabs/Background");

        private readonly SubscriptionProperty<float> _diff;
        private readonly SubscriptionProperty<float> _leftMove;
        private readonly SubscriptionProperty<float> _rightMove;

        private TapeBackgroundView _view;

        public TapeBackgroundController(
            SubscriptionProperty<float> leftMove,
           SubscriptionProperty<float> rightMove)
        {
            _view = LoadView();
            _diff = new SubscriptionProperty<float>();

            _view.Init(_diff);

            _leftMove = leftMove;
            _rightMove = rightMove;

            _leftMove.SubscribeOnChange(MoveLeft);
            _rightMove.SubscribeOnChange(MoveRight);
        }

        protected override void OnDispose()
        {
            _leftMove.UnSubscribeOnChange(MoveLeft);
            _rightMove.UnSubscribeOnChange(MoveRight);
        }

        private TapeBackgroundView LoadView()
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_viewPath);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObject(objectView);

            return objectView.GetComponent<TapeBackgroundView>();
        }

        private void MoveLeft(float value) =>
            _diff.Value = -value;

        private void MoveRight(float value) =>
            _diff.Value = value;
    }
}