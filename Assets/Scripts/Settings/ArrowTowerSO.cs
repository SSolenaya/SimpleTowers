using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Arrow Tower SO")]
    public abstract class ArrowTowerSO : TowersSO {

        public TowersTypes type = TowersTypes.arrows;
    }
}