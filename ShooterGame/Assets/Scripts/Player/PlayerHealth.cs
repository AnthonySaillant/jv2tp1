using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private float invincibilityDuration = 0.5f;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float stompThreshold = 0.5f;

    private AudioSource audioSource;
    [SerializeField] private AudioClip[] spaceMarineDeathClips;
    [SerializeField] private AudioClip spaceMarineHurtClip;

    private Coroutine invincibilityCoroutine;
    private Rigidbody playerRigidBody;
    private bool isInvincible = false;


    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        gameManager.UpdateHpUi(health);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            Transform alienTransform = collision.transform;

            bool isAbove = transform.position.y > alienTransform.position.y + stompThreshold;

            if (isAbove)
            {
                return;
            }
            LoseHealth();
        }
    }

    void LoseHealth()
    {
        if (isInvincible) return;


        health -= 1;
        audioSource.PlayOneShot(spaceMarineHurtClip);
        gameManager.UpdateHpUi(health);

        if (invincibilityCoroutine != null)
            StopCoroutine(invincibilityCoroutine);

        invincibilityCoroutine = StartCoroutine(InvincibilityCoroutine());

        if (health == 0)
        {
            int index = Random.Range(0, spaceMarineDeathClips.Length);
            audioSource.PlayOneShot(spaceMarineDeathClips[index]);
            GameOver();
        }
    }

    public void GainHealth()
    {
        health += 1;

        gameManager.UpdateHpUi(health);
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;

        yield return new WaitForSeconds(invincibilityDuration);

        isInvincible = false;
    }

    void GameOver()
    {
        gameManager.UpdateGameOverUi();
    }
}
