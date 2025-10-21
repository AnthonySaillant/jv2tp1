using UnityEngine;

public class SpawnerHealth : MonoBehaviour
{
    [SerializeField] private int initialHealthPoints = 1;
    private int healthPoints;
    void Start()
    {
        healthPoints = initialHealthPoints;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Spawner loses health");
            healthPoints--;
            if(healthPoints <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
