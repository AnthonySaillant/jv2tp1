using UnityEngine;

public class AlienHealthPoints : MonoBehaviour
{
    [SerializeField] private int initialHealthPoints = 1;
    [SerializeField] private CollectiblePool collectiblePool;
    private PlayerHealth playerHealth;
    private int healthPoints;

    void Awake()
    {
        if (collectiblePool == null)
        {
            collectiblePool = FindAnyObjectByType<CollectiblePool>();
        }
    }

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

        if (Random.Range(0, 3) == 0) //Un tiers de chance
        {
            Debug.Log("collectible spawn");
            GameObject collectible = collectiblePool.GetCollectible();
            collectible.transform.position = transform.position;
            collectible.SetActive(true);
        }
    }
}
