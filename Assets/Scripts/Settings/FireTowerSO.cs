using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Settings;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Fire Tower SO")]
    public class FireTowerSO : TowersSO
    {
        public FireTowerSO()
        {
            type = TowersTypes.fire;
        }
    }
}