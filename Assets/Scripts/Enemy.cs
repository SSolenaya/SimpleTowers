using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts {
    public class Enemy : MonoBehaviour {
        public int index = 0;

        public EnemyTypes enemyType;
        public EnemyData enemyData;


        [SerializeField] private PathPoint _currentPathPoint;
        [SerializeField] private Transform _selfLookTransform;

        [SerializeField] private float _currentHP;
        private Vector3 _lookTargetPoint;
        private Vector3 _lookAngle;
        private float _distantToTarget;
        private float _lastDistantToTarget;
        private readonly List<Tower> _foeTowersList = new List<Tower>();

        public float distanceToCastle;

        [SerializeField] private GameObject _view1;
        [SerializeField] private GameObject _view2;
        [SerializeField] private GameObject _view3;

        public bool onScene;

        public void Setup() {
            Array values = Enum.GetValues(typeof(EnemyTypes));
            enemyType = (EnemyTypes) values.GetValue(Random.Range(0, values.Length));
            ChooseView(enemyType);
            enemyData = SOController.Inst.GetEnemyDataByType(enemyType);
            _currentHP = enemyData.health;
            GetNextTarget(PathController.Inst.GetPathPointByIndex(1));
            gameObject.SetActive(true);
        }

        private void ChooseView(EnemyTypes type) {
            _view1.SetActive(false);
            _view2.SetActive(false);
            _view3.SetActive(false);
            switch (type) {
                case EnemyTypes.t1:
                    _view1.SetActive(true);
                    break;
                case EnemyTypes.t2:
                    _view2.SetActive(true);
                    break;
                case EnemyTypes.t3:
                    _view3.SetActive(true);
                    break;
            }
        }

        public void SetTowerToFoeList(Tower foeTower) {
            _foeTowersList.Add(foeTower);
        }

        private void Update() {
            transform.Translate(Vector3.forward * enemyData.speed * Time.deltaTime); //   move to target
            _distantToTarget = Vector3.Distance(transform.position, _lookTargetPoint);
            if (_distantToTarget < 0.005f || _distantToTarget > _lastDistantToTarget) { //  if enemy close enough to current path point or moves away
                GetNextTarget(PathController.Inst.GetNextPathPoint(_currentPathPoint.index));
                _lastDistantToTarget = float.MaxValue;
            } else {
                _lastDistantToTarget = _distantToTarget; //  saving last distance to target to estimate approaching to point
            }
        }



        public void TakeDamage(float damage) {
            _currentHP -= damage;
            if (_currentHP < 0) {
                int rew = Random.Range(enemyData.minReward, enemyData.maxReward);
                PlayerDataController.Inst.RewardForEnemy(rew);
                Hiding();
           
            }
        }

        private void GetNextTarget(PathPoint targetPathPoint) {
            _currentPathPoint = targetPathPoint;

            if (_currentPathPoint == null) {
                Hiding();
                return;
            }

            distanceToCastle = targetPathPoint.distanceForCastle;
            RotationToTarget(_currentPathPoint); //   rotate to target
        }

        private void RotationToTarget(PathPoint targetPathPoint) {
            _lookTargetPoint.x = targetPathPoint.transform.position.x + Random.Range(-0.005f, 0.005f); //  get random point near target point to look at (each enemy looks at different point)
            _lookTargetPoint.y = transform.position.y;
            _lookTargetPoint.z = targetPathPoint.transform.position.z + Random.Range(-0.005f, 0.005f);

            _selfLookTransform.LookAt(_lookTargetPoint);
            _lookAngle = _selfLookTransform.eulerAngles;

            transform.DORotate(_lookAngle, 0.3f).SetEase(Ease.Linear);
        }

        private void Reset() {
            enemyData = null;
            _currentHP = 0;
            _currentPathPoint = null;

        }

        private void Hiding() {
            onScene = false;
            // hiding in the castle with giving damage
            ClearingTowers();
            EnemyController.Inst.RemoveEnemy(this);
            Reset();
           
            PoolManager.PutEnemyToPool(this);
            TowerController.Inst.ClearEmptyEnemies();
        }

        private void ClearingTowers() {
            foreach (Tower tow in _foeTowersList) {
                tow.RemoveEnemyFromTower(this);
            }

            _foeTowersList.Clear();
        }
    }
}

/* public float GetDistanceToCastle() {
     PathPoint castlePathPoint = PathController.Inst.GetCastlePoint();
     float dist = Vector3.Distance(transform.position, castlePathPoint.transform.position);
     return dist;
 }*/
