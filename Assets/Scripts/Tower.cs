using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityTemplateProjects;

public class Tower : MonoBehaviour, IPointerClickHandler {
    /*<summary>
     Class for tower's prefab
     </summary>*/

    public TowersTypes towerType;
    public TowerData towerData;

    public Transform pointShot; //  shooter obj
    public List<Enemy> _targetEnemyList = new List<Enemy>();
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _shootingTime;
    public Material materialTower;

    private void OnEnable() {
        towerData = SOController.Inst.GetTowerDataByType(towerType);
        _shootingTime = towerData.shootInterval;
    }

    private void Update() {
        _shootingTime -= Time.deltaTime;
        _shootingTime = _shootingTime < 0 ? -1 : _shootingTime;
        if (_targetEnemyList.Count > 0 && _shootingTime <= 0) {
            Shoot();
        }
    }

    public void Shoot() {
        Enemy target = ChooseNearestToCastleEnemy();
        Bullet bullet = Instantiate(_bulletPrefab);
        bullet.transform.SetParent(pointShot);
        bullet.transform.localPosition = Vector3.zero;
        bullet.Setup(towerData.damage, target, materialTower);
        _shootingTime = towerData.shootInterval;
    }

    private Enemy ChooseNearestToCastleEnemy() { //salt 
        Enemy nearestEnemy = null;
        float distanceToCastle = float.MaxValue;

        foreach (Enemy e in _targetEnemyList) {
            if (e.distanceToCastle < distanceToCastle) {
                distanceToCastle = e.distanceToCastle;
                nearestEnemy = e;
            }
        }

        return nearestEnemy;

        /* Enemy nearestEnemy = null;
         float distanceToCastle = float.MaxValue;

         foreach (Enemy e in _targetEnemyList) {
             if (e.GetDistanceToCastle() < distanceToCastle) {
                 distanceToCastle = e.GetDistanceToCastle();
                 nearestEnemy = e;
             }
         }

         return nearestEnemy;*/
    }

    public void OnPointerClick(PointerEventData eventData) {
        // SoundController.inst.PlayClick();
        Debug.Log("Click on tower");
        UIController.Inst.ShowWindow(this);
    }

    private void OnTriggerEnter(Collider enemyTarget) {
        Enemy enemy = enemyTarget.GetComponent<Enemy>();
        if (enemy != null) {
            AddEnemyToTower(enemy);
        }
    }

    private void OnTriggerExit(Collider enemyTarget) {
        Enemy enemy = enemyTarget.GetComponent<Enemy>();
        if (enemy != null) {
            RemoveEnemyFromTower(enemy);
        }
    }

    public void RemoveEnemyFromTower(Enemy enemy) {
        for (int i = 0; i < _targetEnemyList.Count; i++) {
            if (_targetEnemyList[i].index == enemy.index) {
                _targetEnemyList.RemoveAt(i);
            }
        }
    }

    public void ClearEmptyEnemies() {
        while (true) {
            bool flag = true;
            for (int i = 0; i < _targetEnemyList.Count; i++) {
                if (_targetEnemyList[i] == null) {
                    _targetEnemyList.RemoveAt(i);
                    flag = false;
                    break;
                }
            }

            if (flag) break;
        }
    }

    public void AddEnemyToTower(Enemy enemy) {
        bool flag = true;
        foreach (Enemy e in _targetEnemyList) {
            if (enemy.index == e.index) {
                flag = false;
                break;
            }
        }

        if (flag) {
            _targetEnemyList.Add(enemy);
        }
    }

    public void DestroyTower() {
        if (gameObject != null) {
            Destroy(gameObject);
        }
    }
}