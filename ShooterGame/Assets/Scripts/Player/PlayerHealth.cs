using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private float invincibilityDuration = 0.5f;
    [SerializeField] private GameManager gameManager;


    private Coroutine invincibilityCoroutine;
    private Rigidbody playerRigidBody;
    private bool isInvincible = false;


    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        gameManager.UpdateHpUi(health);

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            LoseHealth();
        }
    }

    void LoseHealth()
    {
        if (isInvincible) return;

        health -= 1;

        gameManager.UpdateHpUi(health);

        if (invincibilityCoroutine != null)
            StopCoroutine(invincibilityCoroutine);

        invincibilityCoroutine = StartCoroutine(InvincibilityCoroutine());

        if (health == 0)
        {
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
