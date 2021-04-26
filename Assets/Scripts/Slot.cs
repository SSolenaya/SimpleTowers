using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts {
    public class Slot : MonoBehaviour, IPointerClickHandler {
        public void OnPointerClick(PointerEventData eventData) {
            UIController.Inst.ShowWindow(SetTowersList(), this);
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
}