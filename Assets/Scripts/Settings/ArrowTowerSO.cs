using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Settings;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Arrow Tower SO")]
    public class ArrowTowerSO : TowersSO {

        public ArrowTowerSO()
        {
            type = TowersTypes.arrows;
        }
    }

}