using BattleScripts;
using UnityEngine;

namespace Battle
{
    internal class Enemy : IEnemy
    {
        private const float kMoney = 5f;
        private const float kPower = 4f;
        private const float MaxPlayerHealth = 20f;

        private string _name;

        private int _playerMoney;
        private int _playerHealth;
        private int _playerPower;

        public Enemy(string name) =>
            _name = name;
        
        public void Update(PlayerData dataPlayer)
        {
            switch (dataPlayer.DataType)
            {
                case DataType.Money:
                    _playerMoney = dataPlayer.Value; 
                    break;

                case DataType.Health: 
                    _playerHealth = dataPlayer.Value;
                    break;
                case DataType.Power: 
                    _playerPower = dataPlayer.Value;
                    break;
               
            }
            Debug.Log($"Notified {_name} change to {dataPlayer}");
        }

        public int CalcPower()
        {
            //int kHealth = CalcKHealth();
            //float moneyRatio = _playerMoney / kMoney;
            //float powerRatio = _playerPower / kPower;

            //return (int)(moneyRatio + kHealth + powerRatio);
            int enemyPower = 0;
            if (_playerHealth <= 0)
            {
                enemyPower = 0;
            }
            if (_playerHealth >= kPower)
            {
                enemyPower = (int)(_playerHealth / kPower);
            }
            return enemyPower;
        }

        private int CalcKHealth() =>
            _playerHealth > MaxPlayerHealth ? 100 : 5;
    }
}
    

