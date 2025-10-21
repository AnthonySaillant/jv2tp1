using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour
{
    private float rotationSpeed = 90f;
    private float lifetime = 15f;  

    private Coroutine lifetimeCoroutine;

    private void OnEnable()
    {
        lifetimeCoroutine = StartCoroutine(DisableAfterTime());
    }

    private void Update()
    {
        // Rotation autour de l'axe Y Chat GPT pour l'equation de rotation
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }

    private IEnumerator DisableAfterTime()
    {
        yield return new WaitForSeconds(lifetime);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if (lifetimeCoroutine != null)
        {
            StopCoroutine(lifetimeCoroutine);
            lifetimeCoroutine = null;
        }
    }
}
