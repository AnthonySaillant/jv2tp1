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
            Debug.Log("spawn");
            SpawnAlien();
            timer = 0f;
        }
    }

    void SpawnAlien()
    {
        if (spawnPoints.Length == 0 || alienPool == null || alienQuantity >= alienMaxQuantity)
            return;

        int index = Random.Range(0, spawnPoints.Length);
        Transform chosenSpawner = spawnPoints[index];

        GameObject newAlien = alienPool.GetAlien();

        newAlien.transform.position = chosenSpawner.position;

        alienQuantity++;
    }

    public void AlienDeath()
    {
        alienQuantity--;
    }
}
