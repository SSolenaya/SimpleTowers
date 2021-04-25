using UnityEngine;

namespace Assets.Scripts {
    public class Bullet : MonoBehaviour {
        private float _speed;
        private float _damage;
        [SerializeField] private Enemy _enemyTarget;
        public float currentDis;
        public MeshRenderer meshRenderer;
        private Vector3 lastGoodPosition = new Vector3();


        public void Setup(float damage, Enemy enemy, Material material) {
            meshRenderer.material = material;
            _damage = damage;
            _enemyTarget = enemy;
            _speed = SOController.Inst.towersSettings.bulletSpeed;
        }

        public void Update() {
            if (_enemyTarget != null) {
                lastGoodPosition = _enemyTarget.transform.position;
                //
                //return;
            }


            transform.LookAt(lastGoodPosition);
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            currentDis = Vector3.Distance(transform.position, lastGoodPosition);

            if (currentDis < 0.05f) {
                if (_enemyTarget != null) {
                    _enemyTarget.TakeDamage(_damage);
                }
                
                Destroy(gameObject);
            }
        }
    }
}