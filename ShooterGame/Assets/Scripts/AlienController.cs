using UnityEngine;
using UnityEngine.AI;

public class AlienController : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (agent != null && collision.gameObject.CompareTag("Floor"))
        {
            agent.enabled = true;
        }
    }

    public void DeactivateAlien()
    {
        if (agent != null)
        {
            agent.enabled = false;
        }
        gameObject.SetActive(false);
    }
}
