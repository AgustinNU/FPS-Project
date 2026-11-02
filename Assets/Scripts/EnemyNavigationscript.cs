using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigationscript : MonoBehaviour
{
    
    public NavMeshAgent agent;
    public Transform target;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent.destination = target.position;
        InvokeRepeating("UpdateTarget", 3f, .2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateTarget()
    {
        agent.destination = target.position;
    }
}
