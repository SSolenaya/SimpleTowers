using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityTemplateProjects;

public class Tower : MonoBehaviour, IPointerClickHandler
{
    /*<summary>
     Class for tower's prefab
     </summary>*/

    [SerializeField] private BuildingModal _prefabBuildingModalWin;    //  prefab of modal window for menu of building towers
    private Transform _parentForBuildingModalWin;
    private BuildingModal _buildingModalWin;

    public TowersTypes towerType;
    public TowerData towerData;

    public Transform pointShot; //  shooter obj
    public List<Enemy> _targetEnemyList = new List<Enemy>();
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _shootingTime = 0;

    void OnEnable()
    {
        towerData = SOController.Inst.GetTowerDataByType(towerType);
        _shootingTime = towerData.shootInterval;
        _parentForBuildingModalWin = UIController.Inst.parentForUI;
    }

    void Update() {
        _shootingTime -= Time.deltaTime;
        _shootingTime = _shootingTime < 0 ? -1 : _shootingTime;
        if (_targetEnemyList.Count > 0 && _shootingTime <= 0) {
            Shoot();
        }
    }

    public void Shoot() {
        var target = ChooseNearestToCastleEnemy();
       // var bullet = PoolManager.GetBulletFromPull(_bulletPrefab);
        var bullet = Instantiate(_bulletPrefab);
        bullet.transform.SetParent(pointShot);
        bullet.transform.localPosition = Vector3.zero;
        bullet.Setup(towerData.damage, target);
        _shootingTime = towerData.shootInterval;
    }

    private Enemy ChooseNearestToCastleEnemy() {
        Enemy nearestEnemy = null;
        float distanceToCastle = float.MaxValue;

        foreach (var e in _targetEnemyList) {
            if (e.GetDistanceToCastle() < distanceToCastle) {
                distanceToCastle = e.GetDistanceToCastle();
                nearestEnemy = e;
            }
        }
        return nearestEnemy;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // SoundController.inst.PlayClick();
        Debug.Log("Click on tower");
        if (_buildingModalWin != null) return;
        _buildingModalWin = Instantiate(_prefabBuildingModalWin, _parentForBuildingModalWin);
        _buildingModalWin.Setup(this);
    }

    void OnTriggerEnter(Collider enemyTarget) {

        var enemy = enemyTarget.GetComponent<Enemy>();
        if (enemy != null) {
            AddEnemyToTower(enemy);
        }
        
    }

    void OnTriggerExit (Collider enemyTarget)
    {

        var enemy = enemyTarget.GetComponent<Enemy>();
        if (enemy != null)
        {
            RemoveEnemyFromTower(enemy);
        }

    }

    public void RemoveEnemyFromTower(Enemy enemy)
    {

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
                if (_targetEnemyList[i] == null)
                {
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
        foreach (var e in _targetEnemyList) {
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
