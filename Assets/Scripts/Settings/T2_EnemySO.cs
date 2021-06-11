using System.IO;
using UnityEngine;

namespace Assets.Scripts.Settings
{
    [CreateAssetMenu(menuName = "Enemy Type2 SO")]
    public class T2_EnemySO : EnemySO
    {
        public T2_EnemySO()
        {
            type = EnemyTypes.t2;
        }

    }
}