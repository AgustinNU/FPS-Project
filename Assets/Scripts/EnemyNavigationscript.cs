using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigationscript : MonoBehaviour
{
    
    public NavMeshAgent agent;
    public Transform target;
    public Animator enemyAnimator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent.destination = target.position;
        InvokeRepeating("UpdateTarget", 3f, .2f);
        enemyAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.velocity.magnitude > 0.1)
        {
            enemyAnimator.SetBool("isWalking", true);
        }
        else
        {
            enemyAnimator.SetBool("isWalking", false);
        }
    }

    private void UpdateTarget()
    {
        agent.destination = target.position;
    }
}
