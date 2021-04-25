using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStatusModal : MonoBehaviour {
    [SerializeField] private TMP_Text _gameStatusText;
    public Button mainButton;

    void Start() {
        mainButton.onClick.RemoveAllListeners();
        mainButton.onClick.AddListener(() => PlayerDataController.Inst.RestartGame());
    }

    public void SetText(string newText) {
        _gameStatusText.text = newText;
    }
}
