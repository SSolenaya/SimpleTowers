using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityTemplateProjects;

public class Slot : MonoBehaviour, IPointerClickHandler {

    [SerializeField] private BuildingModal _prefabBuildingModalWin;    //  prefab of modal window for menu of building towers
    private Transform _parentForBuildingModalWin;
    private BuildingModal _buildingModalWin;

    void OnEnable() {
        _parentForBuildingModalWin = UIController.Inst.parentForUI;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData) {
        // SoundController.inst.PlayClick();
        if (_buildingModalWin != null) return;
        _buildingModalWin = Instantiate(_prefabBuildingModalWin, _parentForBuildingModalWin); 
        _buildingModalWin.Setup(SetTowersList(), this);
    }

    private List<TowersTypes> SetTowersList() {
        List<TowersTypes> towersList = new List<TowersTypes>();
        towersList.Add(TowersTypes.arrows);

        towersList.Add(TowersTypes.fire);

        towersList.Add(TowersTypes.ice);

        towersList.Add(TowersTypes.poison);

        return towersList;

    }
}
