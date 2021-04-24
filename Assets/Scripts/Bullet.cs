using System.ComponentModel;
using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {

        private float _speed = 1f;
        private float _damage;
        [SerializeField] private Enemy _enemyTarget;
        public float currentDis;

        public void Setup(float damage, Enemy enemy) {
            _damage = damage;
            _enemyTarget = enemy;
        }

        public void Update()
        {
            if (_enemyTarget == null)
            {
                Destroy(gameObject);
                return;
            }


            transform.LookAt(_enemyTarget.transform);
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            currentDis = Vector3.Distance(transform.position, _enemyTarget.transform.position);

            if (currentDis < 0.1f)
            {
                _enemyTarget.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}
