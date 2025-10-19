using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private float invincibilityDuration = 0.5f;


    private Coroutine invincibilityCoroutine;
    private Rigidbody playerRigidBody;
    private bool isGameOver = false;
    private bool isInvincible = false;


    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
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

        if (invincibilityCoroutine != null)
            StopCoroutine(invincibilityCoroutine);

        invincibilityCoroutine = StartCoroutine(InvincibilityCoroutine());

        if (health == 0)
        {
            GameOver();
        }
        Debug.Log(health);
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;

        yield return new WaitForSeconds(invincibilityDuration);

        isInvincible = false;
    }

    void GameOver()
    {
        isGameOver = !isGameOver;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public int GetHealth()
    {
        return health;
    }
}
