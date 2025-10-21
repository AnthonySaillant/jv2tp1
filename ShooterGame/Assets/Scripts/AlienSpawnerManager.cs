using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    [SerializeField] private AlienPool alienPool;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate = 3f;
    [SerializeField] private int alienMaxQuantity = 30;

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
    }

    void SpawnAlien()
    {
        if (spawnPoints.Length == 0 || alienPool == null || alienQuantity >= alienMaxQuantity)
            return;

        // Filter only active spawners
        var activeSpawners = System.Array.FindAll(spawnPoints, spawner => spawner != null && spawner.gameObject.activeInHierarchy);

        if (activeSpawners.Length == 0)
        {
            Debug.LogWarning("No active spawners available!");
            return;
        }

        // Pick a random active spawner
        int index = Random.Range(0, activeSpawners.Length);
        Transform chosenSpawner = activeSpawners[index];

        GameObject newAlien = alienPool.GetAlien();

        if (newAlien == null)
        {
            Debug.LogWarning("AlienPool returned null — possibly empty pool.");
            return;
        }

        newAlien.transform.position = chosenSpawner.position;
        alienQuantity++;

        Debug.Log($"Alien spawned at: {chosenSpawner.name}");
    }

    public void AlienDeath()
    {
        alienQuantity = Mathf.Max(0, alienQuantity - 1);
    }
}
