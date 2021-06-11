using System.IO;
using UnityEngine;

namespace Assets.Scripts.Settings {
    [CreateAssetMenu(menuName = "Enemy Type1 SO")]
    public class T1_EnemySO: EnemySO
    {
        public T1_EnemySO() {
            type = EnemyTypes.t1;
        }
       
    }
}