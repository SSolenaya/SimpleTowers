using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Settings;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Poison Tower SO")]
    public class PoisonTowerSO : TowersSO
    {
        public PoisonTowerSO() {
            type = TowersTypes.poison;
        }

    }
}