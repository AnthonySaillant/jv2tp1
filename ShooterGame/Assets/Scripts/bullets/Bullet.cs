using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigidBody;

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
        gameObject.SetActive(false);
    }
}
