using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
//using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityTemplateProjects;
using Image = UnityEngine.UI.Image;

public class PriceItem : MonoBehaviour {

    public TMP_Text priceTMP;
    public Image image;
    public Button actionButton; //  for buy and for sell
    public Action actionOnButton;


    void Start() {
        actionButton.onClick.RemoveAllListeners();
        actionButton.onClick.AddListener(OnClick);
    }

    public void Setup(int price, TowersTypes towerType, Action action) {
        actionOnButton += action;
        SetPrice(price);
        SetImage(towerType);
    }

    public void Setup(int price, Action action)
    {
        actionOnButton += action;
        SetPrice(price);
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
        if (spr == null)
        {
            Debug.Log(" Sprite for priceItem is not exist by this path: " + "Sprites/sellSprite");
            return;
        }

        image.sprite = spr;
    }

    private void SetImage(TowersTypes towerType) {

        Sprite spr = Resources.Load<Sprite>("Sprites/" + towerType.ToString());
        if (spr == null) {
            Debug.Log(" Sprite for priceItem is not exist by this path: " + towerType.ToString());
            return;
        }

        image.sprite = spr;
    }

    void OnDestroy() {
        actionOnButton = null;
    }
}
