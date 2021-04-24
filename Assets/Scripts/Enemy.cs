using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts {
    public class Enemy : MonoBehaviour {

        public int index = 0;

        public EnemyTypes enemyType;
        public EnemyData enemyData;


        [SerializeField] private PathPoint _currentPathPoint;
        [SerializeField] private Transform _selfLookTransform;

        private Vector3 _lookTargetPoint;
        private Vector3 _lookAngle;
        private float _distantToTarget;
        private float _lastDistantToTarget;

        public float distanceToCastle;

        void OnEnable() {
            enemyData = SOController.Inst.GetEnemyDataByType(enemyType);
        }
        void Start() {

            EnemyController.Inst.AddEnemy(this);    //  temp
            GetNextTarget(PathController.Inst.GetPathPointByIndex(0)); 

        }

        void LateUpdate() {
            if (_currentPathPoint == null) {

            }
            transform.Translate(Vector3.forward * enemyData.speed * Time.deltaTime);       //   move to target
            _distantToTarget = Vector3.Distance(transform.position, _lookTargetPoint);
            //Debug.Log(_distantToTarget);
            if (_distantToTarget < 0.005f || _distantToTarget > _lastDistantToTarget) //  if enemy close enough to current path point or moves away
            {
                GetNextTarget(PathController.Inst.GetNextPathPoint(_currentPathPoint.index));
                _lastDistantToTarget = float.MaxValue;
            }
            else
            {
                _lastDistantToTarget = _distantToTarget; //  saving last distance to target to estimate approaching to point
            }
        }

        public float GetDistanceToCastle() {
            var castlePathPoint = PathController.Inst.GetCastlePoint();
            var dist = Vector3.Distance(transform.position, castlePathPoint.transform.position);
            return dist;
        }

        public void TakeDamage(float damage) {
            enemyData.health -= damage;
            if (enemyData.health < 0) {
                Hiding();
                var rew = Random.Range(enemyData.minReward, enemyData.maxReward);
                PlayerDataController.Inst.RewardForEnemy(rew);
            }
        }

        private void GetNextTarget(PathPoint targetPathPoint) {
            _currentPathPoint = targetPathPoint;

            if (_currentPathPoint == null) {
                Hiding();
                return;
            }

            RotationToTarget(_currentPathPoint);      //   rotate to target
            
        }

        private void MoveToTarget() {
          
        }
       /* [ContextMenu("dfsdgs")]
        public void Test() {
            _selfLookTransform.LookAt(_lookTargetPoint);
        }*/

        private void RotationToTarget(PathPoint targetPathPoint) {

            _lookTargetPoint.x = targetPathPoint.transform.position.x + Random.Range(-0.005f, 0.005f);  //  get random point near target point to look at (each enemy looks at different point)
            _lookTargetPoint.y = transform.position.y;
            _lookTargetPoint.z = targetPathPoint.transform.position.z + Random.Range(-0.005f, 0.005f);

           /* _distantToTarget = Vector3.Distance(transform.position, _lookTargetPoint);
            _lastDistantToTarget = _distantToTarget;*/

           // _selfLookTransform.position = transform.position;   
            _selfLookTransform.LookAt(_lookTargetPoint);
            _lookAngle = _selfLookTransform.eulerAngles;

            transform.DORotate(_lookAngle, 0.3f).SetEase(Ease.Linear);
        }

        private void Hiding() {
            // hiding in the castle with giving damage
            //PoolManager.PutEnemyToPool(this);
            Destroy(gameObject);
        }

        public void Destroy() {
            if (gameObject != null) {
                Destroy(gameObject);
            }
        }
    }
}
