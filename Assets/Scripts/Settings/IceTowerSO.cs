using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Settings;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Ice Tower SO")]
    public class IceTowerSO : TowersSO
    {
        public IceTowerSO()
        {
            type = TowersTypes.ice;
        }
      
    }
}