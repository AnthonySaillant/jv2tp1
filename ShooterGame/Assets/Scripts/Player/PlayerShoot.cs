using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 50f;
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private float timeBetweenShots = 0.4f;

    private float shotTimer = 0f;
    private InputAction shootAction;
    private GameObject gunEnd;


    void Start()
    {
        shootAction = InputSystem.actions.FindAction("shoot");
        gunEnd = GameObject.FindWithTag("GunEnd");
    }

    void Update()
    {
        shotTimer += Time.deltaTime;

        if (shootAction.IsPressed() && shotTimer >= timeBetweenShots)
        {
            Shoot();
            shotTimer = 0f;
        }
    }

    private void Shoot()
    {
        Vector3 direction = -gunEnd.transform.up; //le moin pour que sa pointe devant
        GameObject bullet = bulletPool.GetBullet();
        bullet.transform.position = gunEnd.transform.position;

        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.linearVelocity = direction * bulletSpeed;
    }
}
