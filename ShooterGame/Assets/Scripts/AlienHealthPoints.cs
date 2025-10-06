using UnityEngine;

public class AlienHealthPoints : MonoBehaviour
{
    [SerializeField] private int initialHealthPoints = 1;
    private int healthPoints;
    private bool isDead = false;

    void Start()
    {
        healthPoints = initialHealthPoints;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthPoints = 0;
            if (!isDead)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        isDead = true;
        gameObject.SetActive(false);
    }
}
