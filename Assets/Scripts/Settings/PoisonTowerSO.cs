using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Poison Tower SO")]
    public abstract class PoisonTowerSO : TowersSO
    {
        public TowersTypes type = TowersTypes.poison;
    }
}