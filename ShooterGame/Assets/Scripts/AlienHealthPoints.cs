using UnityEngine;

public class AlienHealthPoints : MonoBehaviour
{
    [SerializeField] private int initialHealthPoints = 1;
    [SerializeField] private AudioClip deathSound;

    private CollectiblePool collectiblePool;
    [SerializeField] private int chosenChances;
    private int healthPoints;

    private AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
    }

  
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collision");
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
        if (Random.Range(0, chosenChances--) == 0)
        {
            Debug.Log("collectible spawn");
            GameObject collectible = collectiblePool.GetCollectible();
            collectible.transform.position = transform.position;
            collectible.SetActive(true);
        }
    }
}
