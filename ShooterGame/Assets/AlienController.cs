using UnityEngine;
using UnityEngine.AI;

public class AlienController : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] private float activateDelay = 1f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            agent.enabled = false;
        }
    }

    private void OnEnable()
    {
        if (agent != null)
        {
            agent.enabled = false;
            StartCoroutine(EnableAgentAfterDelay());
        }
    }

    private System.Collections.IEnumerator EnableAgentAfterDelay()
    {
        yield return new WaitForSeconds(activateDelay);

        if (agent != null)
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

    public void ResetAlien()
    {
        if (agent != null)
        {
            agent.enabled = false;
            StartCoroutine(EnableAgentAfterDelay());
        }
    }
}
