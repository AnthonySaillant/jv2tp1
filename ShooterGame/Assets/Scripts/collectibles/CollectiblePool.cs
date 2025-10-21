using UnityEngine;
using System.Collections.Generic;

public class CollectiblePool : MonoBehaviour
{
    [SerializeField] private GameObject healthCollectiblePrefab;
    [SerializeField] private GameObject rocketCollectiblePrefab;
    [SerializeField] private GameObject multiShotCollectiblePrefab;

    [SerializeField] private int poolSize = 10;

    private List<GameObject> collectibles;

    void Start()
    {
        collectibles = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject collectible = CreateRandomCollectible();
            collectible.SetActive(false);
            collectibles.Add(collectible);
        }
    }

    public GameObject GetCollectible()
    {
        List<GameObject> inactiveCollectibles = new List<GameObject>();
        foreach (var c in collectibles)
        {
            if (!c.activeInHierarchy)
            {
                inactiveCollectibles.Add(c);
            }
        }

        if (inactiveCollectibles.Count > 0)
        {
            int randomIndex = Random.Range(0, inactiveCollectibles.Count);
            GameObject chosen = inactiveCollectibles[randomIndex];
            chosen.SetActive(true);
            return chosen;
        }

        GameObject newCollectible = CreateRandomCollectible();
        collectibles.Add(newCollectible);
        return newCollectible;
    }

    private GameObject CreateRandomCollectible()
    {
        int chances = Random.Range(0, 3);
        switch (chances)
        {
            case 0:
                return Instantiate(healthCollectiblePrefab);
            case 1:
                return Instantiate(rocketCollectiblePrefab);
            case 2:
                return Instantiate(multiShotCollectiblePrefab);
            default:
                return Instantiate(healthCollectiblePrefab); // doit avoir un default quand meme
        }
    }

}
