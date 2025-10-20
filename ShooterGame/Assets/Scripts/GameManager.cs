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
    [SerializeField] private TMP_Text MultiShotTimerText;
    [SerializeField] private RawImage hearthLogo;
    [SerializeField] private RawImage MissileLogo;
    [SerializeField] private RawImage MultiShotLogo;


    void Start()
    {
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {

    }

    public void UpdateHpUi(int hp)
    {
        hpText.text = hp.ToString();
    }

    public void UpdateGameOverUi()
    {
        gameOverText.gameObject.SetActive(true);
        hpText.gameObject.SetActive(false);
        MissileText.gameObject.SetActive(false);
        MultiShotTimerText.gameObject.SetActive(false);

        hearthLogo.gameObject.SetActive(false);
        MissileLogo.gameObject.SetActive(false);
        MultiShotLogo.gameObject.SetActive(false);

        Time.timeScale = 0f;
    }
}
