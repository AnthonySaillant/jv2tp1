using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text MissileText;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private PlayerHealth playerHealth;

    void Start()
    {
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);
        hpText.text = "allo";
        UpdateHpUi();
    }

    void Update()
    {
        if (playerHealth != null)
        {
            UpdateHpUi();

            if (playerHealth.IsGameOver() && gameOverText != null)
            {
                gameOverText.gameObject.SetActive(true);
            }
        }
    }

    private void UpdateHpUi()
    {
        if (hpText != null)
            hpText.text = playerHealth.GetHealth().ToString();
    }
}
