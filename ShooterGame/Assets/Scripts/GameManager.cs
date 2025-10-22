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
    [SerializeField] private TMP_Text victoryText;
    [SerializeField] private TMP_Text MultiShotTimerText;
    [SerializeField] private RawImage hearthLogo;
    [SerializeField] private RawImage MissileLogo;
    [SerializeField] private RawImage MultiShotLogo;

    private AudioSource audioSource;
    [SerializeField] private AudioClip[] backgroundMusicClips;
    [SerializeField] private AudioClip VictoryMusicClip;

    void Start()
    {
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);
        if (victoryText != null)
            victoryText.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        if (backgroundMusicClips != null && backgroundMusicClips.Length > 0)
        {
            AudioClip randomClip = backgroundMusicClips[Random.Range(0, backgroundMusicClips.Length)];
            audioSource.clip = randomClip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    void Update()
    {

    }

    public void UpdateHpUi(int hp)
    {
        hpText.text = hp.ToString();
    }

    public void UpdateMultiShotTimerUi(float multiShotTimer)
    {
        MultiShotTimerText.text = multiShotTimer.ToString("F1");
    }

    public void UpdateRocketUi(int numberOfRockets)
    {
        MissileText.text = numberOfRockets.ToString();
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

    public void UpdateVictoryUi()
    {
        victoryText.gameObject.SetActive(true);
        hpText.gameObject.SetActive(false);
        MissileText.gameObject.SetActive(false);
        MultiShotTimerText.gameObject.SetActive(false);

        hearthLogo.gameObject.SetActive(false);
        MissileLogo.gameObject.SetActive(false);
        MultiShotLogo.gameObject.SetActive(false);

        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        if (VictoryMusicClip != null)
        {
            AudioSource.PlayClipAtPoint(VictoryMusicClip, transform.position);
        }

        // Enfin, on gèle le jeu
        Time.timeScale = 0f;
    }
}
