using UnityEngine;

public class PlayerCollectCollectible : MonoBehaviour
{
    private Rigidbody rigidBody;
    private PlayerHealth playerHealth;
    [SerializeField] private PlayerShoot playerShoot;

    private AudioSource audioSource;
    [SerializeField] private AudioClip collectCollectible;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerHealth = GetComponentInParent<PlayerHealth>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("HealthCollectible"))
        {
            playerHealth.GainHealth();
            collision.gameObject.SetActive(false);
            audioSource.PlayOneShot(collectCollectible);
        }
        if (collision.gameObject.CompareTag("RocketCollectible"))
        {
            playerShoot.AddRockets();
            collision.gameObject.SetActive(false);
            audioSource.PlayOneShot(collectCollectible);
        }
        if (collision.gameObject.CompareTag("MultiShotCollectible"))
        {
            playerShoot.ActivateMultishooting();
            collision.gameObject.SetActive(false);
            audioSource.PlayOneShot(collectCollectible);
        }
    }
}
