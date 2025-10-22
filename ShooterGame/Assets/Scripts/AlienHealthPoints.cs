using UnityEngine;

public class AlienHealthPoints : MonoBehaviour
{
    [SerializeField] private int initialHealthPoints = 1;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip spawnCollectible;

    private CollectiblePool collectiblePool;
    [SerializeField] private int chosenChances;
    private int healthPoints;
    private AlienSpawner spawnerManager;

    private AudioSource audioSource;

    void Awake()
    {
        if (collectiblePool == null)
        {
            collectiblePool = FindAnyObjectByType<CollectiblePool>();
        }

        GameObject alienManager = GameObject.Find("AlienManager");
        if (alienManager != null)
        {
            spawnerManager = alienManager.GetComponent<AlienSpawner>();
        }
    }

    void Start()
    {
        healthPoints = initialHealthPoints;
        audioSource = GetComponent<AudioSource>();
    }

  
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthPoints = 0;
            Die();
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            healthPoints--;
            if(healthPoints < 0)
            {
                Die();
            }
        }
        if (collision.gameObject.CompareTag("Explosion"))
        {
            healthPoints -= 5;
            if (healthPoints < 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        gameObject.SetActive(false);
        healthPoints = initialHealthPoints;
        spawnerManager.AlienDeath();
        if (Random.Range(0, chosenChances--) == 0)
        {
            GameObject collectible = collectiblePool.GetCollectible();
            collectible.transform.position = transform.position;
            collectible.SetActive(true);
            AudioSource.PlayClipAtPoint(spawnCollectible, transform.position);
        }
    }
}
