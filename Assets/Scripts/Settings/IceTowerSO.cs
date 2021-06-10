using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Ice Tower SO")]
    public abstract class IceTowerSO : TowersSO
    {
        public TowersTypes type = TowersTypes.ice;
    }
}