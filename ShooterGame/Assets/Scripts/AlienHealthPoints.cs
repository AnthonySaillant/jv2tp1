using UnityEngine;

public class AlienHealthPoints : MonoBehaviour
{
    [SerializeField] private int initialHealthPoints = 1;
    private PlayerHealth playerHealth;
    private int healthPoints;

    void Start()
    {
        healthPoints = initialHealthPoints;
        playerHealth = FindFirstObjectByType<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("die");
            healthPoints = 0;
            Die();
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("die");
            healthPoints = 0;
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        healthPoints = initialHealthPoints;
        playerHealth.LoseHealth();
    }
}
