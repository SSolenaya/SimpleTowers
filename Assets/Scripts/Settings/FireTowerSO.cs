using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Fire Tower SO")]
    public abstract class FireTowerSO : TowersSO
    {
        public TowersTypes type = TowersTypes.fire;
    }
}