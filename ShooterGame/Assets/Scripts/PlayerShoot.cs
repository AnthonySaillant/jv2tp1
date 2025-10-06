using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private InputAction shootAction;
    private GameObject gunEnd;

    void Start()
    {
        shootAction = InputSystem.actions.FindAction("shoot");
        gunEnd = GameObject.FindWithTag("GunEnd");
    }

    void Update()
    {
        transform.position = gunEnd.transform.position; //Ajuste le bullet sur le canon

        if (launchAction.IsPressed())
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        float shootForce = 
    }
}
