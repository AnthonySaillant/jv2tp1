using UnityEngine;
using System.Collections.Generic;

public class RocketPool : MonoBehaviour
{
    [SerializeField] private GameObject missileRedPrefab;
    [SerializeField] private int poolSize = 20;

    private List<GameObject> missiles;

    void Start()
    {
        missiles = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject missile = Instantiate(missileRedPrefab);
            missile.SetActive(false);
            missiles.Add(missile);
        }
    }

    public GameObject GetMissile()
    {
        foreach (var missile in missiles)
        {
            if (!missile.activeInHierarchy)
            {
                missile.SetActive(true);
                return missile;
            }
        }

        GameObject newMissile = Instantiate(missileRedPrefab);
        missiles.Add(newMissile);
        return newMissile;
    }
}
