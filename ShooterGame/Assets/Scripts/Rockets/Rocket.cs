using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody rigidBody;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float explosionLifetime = 0.5f;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        rigidBody.linearVelocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);

        Destroy(explosion, explosionLifetime);

        gameObject.SetActive(false);
    }
}
