using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts {
    public class PriceItem : MonoBehaviour {
        public TMP_Text priceTMP;
        public Image image;
        public Button actionButton; //  for buy and for sell
        public Action actionOnButton;
        public int priceTower;

        private void Start() {
            actionButton.onClick.RemoveAllListeners();
            actionButton.onClick.AddListener(OnClick);
        }

        public void OnEnable() {
            PlayerDataController.Inst.actionCurrentCoins += CheckPrice;
        }

        public void OnDisable() {
            PlayerDataController.Inst.actionCurrentCoins -= CheckPrice;
        }

        private void CheckPrice(int coins) {
            actionButton.interactable = priceTower <= coins;
        }


        public void Setup(int price, TowersTypes towerType, Action action) {
            actionOnButton += action;
            CheckPrice(PlayerDataController.Inst.currentCoins);
            SetPrice(price);
            SetImage(towerType);
        }

        public void Setup(int price, Action action) {
            actionOnButton += action;
            SetPrice((int)(price * SOController.Inst.mainGameSettings.saleTowerFactor));
            SetSellImage();
        }

        private void OnClick() {
            //SoundController.inst.PlayClick();
            actionOnButton?.Invoke();
        }

        private void SetPrice(int price) {
            priceTMP.text = price.ToString();
        }

        private void SetSellImage() {
            Sprite spr = Resources.Load<Sprite>("Sprites/sellSprite");
            if (spr == null) {
                Debug.Log(" Sprite for priceItem is not exist by this path: " + "Sprites/sellSprite");
                return;
            }

            image.sprite = spr;
        }

        private void SetImage(TowersTypes towerType) {
            Sprite spr = Resources.Load<Sprite>("Sprites/" + towerType);
            if (spr == null) {
                Debug.Log(" Sprite for priceItem is not exist by this path: " + towerType);
                return;
            }

            image.sprite = spr;
        }

        private void OnDestroy() {
            actionOnButton = null;
        }
    }
}