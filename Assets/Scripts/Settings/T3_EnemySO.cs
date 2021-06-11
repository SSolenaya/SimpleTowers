using System.IO;
using UnityEngine;

namespace Assets.Scripts.Settings
{
    [CreateAssetMenu(menuName = "Enemy Type3 SO")]
    public class T3_EnemySO : EnemySO
    {
        public T3_EnemySO()
        {
            type = EnemyTypes.t3;
        }
    }
}