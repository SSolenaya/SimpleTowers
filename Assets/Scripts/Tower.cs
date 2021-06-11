using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Settings;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour, IPointerClickHandler {
    /*<summary>
     Class for tower's prefab
     </summary>*/

    public TowersTypes towerType;
    public TowerData towerData;

    public Transform pointShot; //  shooter obj
    [SerializeField] public List<Enemy> _targetEnemyList = new List<Enemy>();
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _shootingTime;
    [SerializeField] private Material _materialTower;
    [SerializeField] private SphereCollider _shootingRange;

    private void OnEnable() {
        towerData = SOController.Inst.GetTowerDataByType(towerType);
        _shootingTime = towerData.shootInterval;
        _shootingRange.radius = towerData.range;
    }

    private void Update() {
        _shootingTime -= Time.deltaTime;
        _shootingTime = _shootingTime < 0 ? -1 : _shootingTime;
        if (_targetEnemyList.Count > 0 && _shootingTime < 0) {
            Shoot();
        }
    }

    public void Shoot() {
        Enemy target = ChooseNearestToCastleEnemy();
        Bullet bullet = PoolManager.GetBulletFromPull(_bulletPrefab);
        bullet.gameObject.SetActive(true);
        bullet.transform.SetParent(pointShot);
        bullet.transform.localPosition = Vector3.zero;
        bullet.Setup(towerData.damage, target, _materialTower, towerData.bulletSpeed);
        _shootingTime = towerData.shootInterval;
    }

    private Enemy ChooseNearestToCastleEnemy() { //  get nearest to castle enemy in castle list
        Enemy nearestEnemy = null;
        float distanceToCastle = float.MaxValue;

        foreach (Enemy e in _targetEnemyList) {
            if (e.distanceToCastle < distanceToCastle) {
                distanceToCastle = e.distanceToCastle;
                nearestEnemy = e;
            }
        }

        return nearestEnemy;
    }

    public void OnPointerClick(PointerEventData eventData) {
        // SoundController.inst.PlayClick();
        //Debug.Log("Click on tower");
        UIController.Inst.ShowWindow(this);
    }

    private void OnTriggerEnter(Collider enemyTarget) {
        Enemy enemy = enemyTarget.GetComponent<Enemy>();
        if (enemy != null) {
            AddEnemyToTower(enemy);
            enemy.SetTowerToFoeList(this);
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