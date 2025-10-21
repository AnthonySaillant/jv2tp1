using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 50f;
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private float timeBetweenShots = 0.4f;
    [SerializeField] private float multiShootDuration = 10f;
    [SerializeField] private GameManager gameManager;

    private float shotTimer = 0f;
    private float multiShotTimer = 0f;
    private bool isMultiShooting = false;
    private float offsetAngle = 3f;

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
            if (isMultiShooting)
                ShootMultiShot();
            else
                Shoot();

            shotTimer = 0f;
        }

        if (isMultiShooting)
        {
            multiShotTimer -= Time.deltaTime;
            if (multiShotTimer <= 0f)
            {
                isMultiShooting = false;
                multiShotTimer = 0f;
            }
            gameManager.UpdateMultiShotTimerUi(multiShotTimer);
        }
    }

    private void Shoot()
    {
        Vector3 direction = -gunEnd.transform.up; // le "-" pour que ça pointe vers l'avant

        GameObject bullet = bulletPool.GetBullet();
        bullet.transform.position = gunEnd.transform.position;

        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.linearVelocity = direction * bulletSpeed;
    }

    private void ShootMultiShot()
    {
        Shoot();
        ShootRight();
        ShootLeft();
    }

    private void ShootRight()
    {
        Debug.Log("shooting right");
        Vector3 direction = -gunEnd.transform.up;

        GameObject bulletRight = bulletPool.GetBullet();
        bulletRight.transform.position = gunEnd.transform.position + gunEnd.transform.right * offsetAngle;

        Rigidbody rigidBody = bulletRight.GetComponent<Rigidbody>();
        rigidBody.linearVelocity = direction * bulletSpeed;
    }

    private void ShootLeft()
    {
        Debug.Log("shooting left");
        Vector3 direction = -gunEnd.transform.up;

        GameObject bulletLeft = bulletPool.GetBullet();
        bulletLeft.transform.position = gunEnd.transform.position - gunEnd.transform.right * offsetAngle;

        Rigidbody rigidBody = bulletLeft.GetComponent<Rigidbody>();
        rigidBody.linearVelocity = direction * bulletSpeed;
    }

    public void ActivateMultishooting()
    {
        if (isMultiShooting)
        {
            multiShotTimer += multiShootDuration;
        }
        else
        {
            isMultiShooting = true;
            multiShotTimer = multiShootDuration;
        }
    }
}
