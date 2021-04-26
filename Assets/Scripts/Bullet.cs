using UnityEngine;

namespace Assets.Scripts {
    public class Bullet : MonoBehaviour {
        private float _speed;
        private float _damage;
        [SerializeField] private Enemy _enemyTarget;
        public float currentDis;
        public MeshRenderer meshRenderer;
        public Vector3 lastGoodPosition;
        public int enemyIndex;

        public void Setup(float damage, Enemy enemy, Material material) {
            enemyIndex = enemy.index;
            meshRenderer.material = material;
            _damage = damage;
            _enemyTarget = enemy;
            _speed = SOController.Inst.towersSettings.bulletSpeed;
        }

        public void Resets() {
            _speed = 0;
            _damage = 0;
            _enemyTarget = null;
        }

        public void Update() {
            if (_enemyTarget != null && _enemyTarget.index == enemyIndex && _enemyTarget.onScene ) {
                lastGoodPosition = _enemyTarget.transform.position;
            }

            if (lastGoodPosition  == Vector3.zero) {
                PoolManager.PutBulletToPool(this);
            }

            transform.LookAt(lastGoodPosition);
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            currentDis = Vector3.Distance(transform.position, lastGoodPosition);

            if (currentDis < 0.05f ) {
                if (_enemyTarget != null && _enemyTarget.index == enemyIndex && _enemyTarget.onScene && _enemyTarget.transform.position != Vector3.zero) {
                    _enemyTarget.TakeDamage(_damage);
                }
                Resets();
                PoolManager.PutBulletToPool(this);
            }
        }
    }
}