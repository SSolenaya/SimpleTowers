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
    private List<Enemy> _targetEnemyList = new List<Enemy>();
    [SerializeField] private Bullet _bulletPrefab;

    void OnEnable()
    {
        _parentForBuildingModalWin = UIController.Inst.parentForUI;
    }
    public void Setup() {
        towerData = SOController.Inst.GetTowerDataByType(towerType);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // SoundController.inst.PlayClick();
        Debug.Log("Click on tower");
        if (_buildingModalWin != null) return;
        _buildingModalWin = Instantiate(_prefabBuildingModalWin, _parentForBuildingModalWin);
        _buildingModalWin.Setup(towerType);
    }
}
