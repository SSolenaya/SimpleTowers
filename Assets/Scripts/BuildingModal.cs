using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityTemplateProjects;
using Button = UnityEngine.UI.Button;


public class BuildingModal : MonoBehaviour {

    public TMP_Text titleText;
    public Transform parentForPriceItems;
    public List<PriceItem> priceItemsList = new List<PriceItem>();
    public Button closeBtn;
    public PriceItem priceItemPrefab;

    void Start() {
        closeBtn.onClick.RemoveAllListeners();
        closeBtn.onClick.AddListener(Destroy);
    }
    public void Setup (List<TowersTypes> towerTypes, Slot baseSlot) {
        

        foreach (var t in towerTypes) {
            var pI =Instantiate(priceItemPrefab, parentForPriceItems);
            var tData = SOController.Inst.GetTowerDataByType(t);

            pI.Setup(tData.buildPrice, t, () => {
                TowerController.Inst.BuildTowerOnCurrentSlot(tData, baseSlot);
                Destroy();
            });
            if (tData.buildPrice > PlayerDataController.Inst.currentCoins) {
                pI.actionButton.interactable = false;
            }

            priceItemsList.Add(pI);
        }
    }

    public void Setup(TowersTypes towerType) {
        var pI = Instantiate(priceItemPrefab, parentForPriceItems);
        var tData = SOController.Inst.GetTowerDataByType(towerType);
        pI.Setup(tData.buildPrice, () => PlayerDataController.Inst.AddFinance(tData.buildPrice));
    }

    void OnDisable() {
        Clear();
    }

    private void Clear() {
        priceItemsList.Clear();
    }

    private void Destroy() {
        Clear();
        if (gameObject != null) {
            Destroy(gameObject);
        }
    }

}
