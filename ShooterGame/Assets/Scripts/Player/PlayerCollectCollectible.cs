using UnityEngine;

public class PlayerCollectCollectible : MonoBehaviour
{
    private Rigidbody rigidBody;
    private PlayerHealth playerHealth;
    [SerializeField] private PlayerShoot playerShoot;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerHealth = GetComponentInParent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("HealthCollectible"))
        {
            playerHealth.GainHealth();
            Debug.Log("ramasse le healthBonus");
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("RocketCollectible"))
        {
            playerShoot.AddRockets();
            Debug.Log("ramasse le RocketCollectible");
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("MultiShotCollectible"))
        {
            playerShoot.ActivateMultishooting();
            Debug.Log("ramasse le MultiShotCollectible");
            collision.gameObject.SetActive(false);
        }
    }
}
