using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 50f;
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private float timeBetweenShots = 0.4f;
    [SerializeField] private float multiShootDuration = 10f;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private RocketPool rocketPool;

    private float shotTimer = 0f;
    private float multiShotTimer = 0f;
    private bool isMultiShooting = false;
    private float offsetAngle = 3f;
    private int numberOfRockets = 0;
    private float rocketCooldown = 2f;
    private float rocketShotTimer = 0f;

    private InputAction shootAction;
    private InputAction shootRocketAction;
    private GameObject gunEnd;

    private AudioSource audioSource;
    [SerializeField] private AudioClip bulletShotClip;
    [SerializeField] private AudioClip tripleShootShotClip;


    void Start()
    {
        shootAction = InputSystem.actions.FindAction("shoot");
        shootRocketAction = InputSystem.actions.FindAction("ShootRocket");
        gunEnd = GameObject.FindWithTag("GunEnd");
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        shotTimer += Time.deltaTime;
        rocketShotTimer += Time.deltaTime;

        if (shootAction.IsPressed() && !shootRocketAction.IsPressed() && shotTimer >= timeBetweenShots)
        {
            if (isMultiShooting)
            {
                ShootMultiShot();
                audioSource.PlayOneShot(tripleShootShotClip);
            }
            else
            {
                Shoot();
                audioSource.PlayOneShot(bulletShotClip);
            }

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
        if (numberOfRockets > 0 && shootRocketAction.IsPressed() && !shootAction.IsPressed() && rocketShotTimer >= rocketCooldown)
        {
            ShootRocket();
            numberOfRockets--;
            gameManager.UpdateRocketUi(numberOfRockets);
            rocketShotTimer = 0f;
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

    private void ShootRocket()
    {
        Vector3 direction = -gunEnd.transform.up; // le "-" pour que ça pointe vers l'avant

        GameObject rocket = rocketPool.GetMissile();
        rocket.transform.position = gunEnd.transform.position;

        Rigidbody rigidbody = rocket.GetComponent<Rigidbody>();
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

    public void AddRockets()
    {
        numberOfRockets += 5;
    }
}
