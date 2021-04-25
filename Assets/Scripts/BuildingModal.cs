using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityTemplateProjects;

namespace Assets.Scripts {
    public class BuildingModal : MonoBehaviour {
        public RectTransform buttonsPanelRT;
        public Transform parentForPriceItems;
        public List<PriceItem> priceItemsList = new List<PriceItem>();
        public Button closeBtn;
        public PriceItem priceItemPrefab;

        private void Start() {
            closeBtn.onClick.RemoveAllListeners();
            closeBtn.onClick.AddListener(Destroy);
        }

        public void Setup(List<TowersTypes> towerTypes, Slot baseSlot) {
            foreach (TowersTypes t in towerTypes) {
                PriceItem pI = Instantiate(priceItemPrefab, parentForPriceItems);
                TowerData tData = SOController.Inst.GetTowerDataByType(t);
                pI.priceTower = tData.buildPrice;
                pI.Setup(tData.buildPrice, t, () => {
                    TowerController.Inst.BuildTowerOnCurrentSlot(tData, baseSlot);
                    Destroy();
                });
          
                priceItemsList.Add(pI);
            }
        }

        public void Setup(Tower tower) {
            PriceItem pI = Instantiate(priceItemPrefab, parentForPriceItems);
            pI.Setup(tower.towerData.buildPrice, () => {
                PlayerDataController.Inst.AddFinance(tower.towerData.buildPrice);
                tower.DestroyTower();
                Destroy();
            });
        }

        private void OnDisable() {
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
}