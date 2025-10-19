using UnityEngine;
using System.Collections.Generic;

public class AlienPool : MonoBehaviour
{
    [SerializeField] private GameObject alienPrefab;
    [SerializeField] private int poolSize = 20;

    private List<GameObject> aliens;

    void Start()
    {
        aliens = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject alien = Instantiate(alienPrefab);
            alien.SetActive(false);
            aliens.Add(alien);
        }
    }

    public GameObject GetAlien()
    {
        foreach (var alien in aliens)
        {
            if (!alien.activeInHierarchy)
            {
                alien.SetActive(true);
                return alien;
            }
        }

        GameObject newAlien = Instantiate(alienPrefab);
        aliens.Add(newAlien);
        return newAlien;
    }
}
