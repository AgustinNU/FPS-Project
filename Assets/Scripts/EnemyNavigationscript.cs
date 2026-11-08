using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigationscript : MonoBehaviour
{
    
    public NavMeshAgent agent;
    public Transform target;
    public Animator enemyAnimator;
    public float detectionRadius;
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

        if (target == null) return;

        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget <= detectionRadius)
        {
            agent.speed = 0.4f;
            enemyAnimator.SetBool("isWalking", true);
            
        }

        else
        {
            agent.speed = 0;
            enemyAnimator.SetBool("isWalking", false);
        }
    }

    private void UpdateTarget()
    {
        agent.destination = target.position;
    }

}
