using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {

        public float speed;
        private float _damage;
        public Enemy enemyTarget;
        public float currentDis;

        public void Setup(float damage) {
            _damage = damage;
        }

        public void Update()
        {
            if (enemyTarget == null)
            {
                Destroy(gameObject);
                return;
            }


            transform.LookAt(enemyTarget.transform);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            currentDis = Vector3.Distance(transform.position, enemyTarget.transform.position);

            if (currentDis < 0.5f)
            {
               /// enemyTarget.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}
