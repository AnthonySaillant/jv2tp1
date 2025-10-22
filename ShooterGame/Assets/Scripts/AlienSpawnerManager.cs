using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    [SerializeField] private AlienPool alienPool;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate = 3f;
    [SerializeField] private int alienMaxQuantity = 30;
    [SerializeField] private GameManager gameManager;

    private int activeSpawners ;
    private int alienQuantity = 0;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnAlien();
            timer = 0f;
        }
        var activeSpawners = System.Array.FindAll(spawnPoints, spawner => spawner != null && spawner.gameObject.activeInHierarchy);
        if (activeSpawners.Length == 0)
        {
            gameManager.UpdateVictoryUi();
        }
    }

    void SpawnAlien()
    {
        if (spawnPoints.Length == 0 || alienPool == null || alienQuantity >= alienMaxQuantity)
            return;

        var activeSpawners = System.Array.FindAll(spawnPoints, spawner => spawner != null && spawner.gameObject.activeInHierarchy);

        if (activeSpawners.Length == 0)
        {
            return;
        }

        int index = Random.Range(0, activeSpawners.Length);
        Transform chosenSpawner = activeSpawners[index];

        GameObject newAlien = alienPool.GetAlien();

        newAlien.transform.position = chosenSpawner.position;
        alienQuantity++;
    }

    public void AlienDeath()
    {
        alienQuantity--;
    }
}
