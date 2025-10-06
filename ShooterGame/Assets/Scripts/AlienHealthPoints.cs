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

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("die");
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
