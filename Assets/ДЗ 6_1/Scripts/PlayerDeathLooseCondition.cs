using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegates.Events
{
    public class PlayerDeathLooseCondition : ILostCondition
    {
        public event Action LoseAchieved;

        private Player _player;

        public PlayerDeathLooseCondition(Player player)
        {
            _player = player;
        }

        public void CheckLoseCondition()
        {
            if(_player.Health.Current <= 0)
                LoseAchieved?.Invoke();
        }
    }
}
