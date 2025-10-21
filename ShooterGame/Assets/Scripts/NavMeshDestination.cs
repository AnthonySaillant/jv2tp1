using UnityEngine;
using UnityEngine.AI;

public class Actor : MonoBehaviour
{
    private GameObject goal;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        goal = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (goal == null) return;

        if (navMeshAgent == null)
        {
            transform.position = Vector3.MoveTowards(transform.position, goal.transform.position, 5f * Time.deltaTime);
        }
        else
        {
            if (navMeshAgent.enabled == true)
            {
                navMeshAgent.SetDestination(goal.transform.position);
            }
        }
    }
}
