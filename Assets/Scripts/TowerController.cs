using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class TowerController : Singleton<TowerController> {
        [SerializeField] private Tower fireTowerPrefab;
        [SerializeField] private Tower iceTowerPrefab;
        [SerializeField] private Tower poisonTowerPrefab;
        [SerializeField] private Tower arrowTowerPrefab;

        [SerializeField] private readonly List<Tower> towersList = new List<Tower>();

        public void BuildTowerOnCurrentSlot(TowerData tData, Slot baseSlot) {
            PlayerDataController.Inst.SubtractFinance(tData.buildPrice);
            Tower tower = Instantiate(GetPrefabByTowerType(tData.towerType));
            tower.transform.localPosition = baseSlot.transform.localPosition;
            tower.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            towersList.Add(tower);
        }

        public void ClearEmptyEnemies() {
            StartCoroutine(IEnumClearEmptyEnemies());
        }

        public IEnumerator IEnumClearEmptyEnemies() {
            yield return new WaitForEndOfFrame();
            foreach (Tower t in towersList) {
                t.ClearEmptyEnemies();
            }
        }

        private Tower GetPrefabByTowerType(TowersTypes towerType) {
            switch (towerType) {
                case TowersTypes.fire:
                    return fireTowerPrefab;
                case TowersTypes.ice:
                    return iceTowerPrefab;
                case TowersTypes.poison:
                    return poisonTowerPrefab;
                case TowersTypes.arrows:
                default:
                    return arrowTowerPrefab;
            }
        }
    }
}