using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class EnemyZ1Script : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Image healthBar;
    public int health = 100;
    public Animator enemyAnimator;
    public CapsuleCollider  collider;
    public Canvas canvas;
    public NavMeshAgent navMesh;
    private bool isDead = false;
    public GameControllerScript gameController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
        collider = GetComponent<CapsuleCollider>();
        canvas = GetComponentInChildren<Canvas>();
        navMesh = GetComponent<NavMeshAgent>();
        gameController = FindAnyObjectByType<GameControllerScript>();
    }   

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            health -= 25;
            healthText.text = health.ToString();
            healthBar.fillAmount = health / 100f;
            enemyAnimator.SetTrigger("onHit");

            if (isDead)
            {  
                return;
            }

            if (health <= 0)
            {
                isDead = true;
                enemyAnimator.ResetTrigger("onHit");
                navMesh.isStopped = true;
                canvas.enabled = false;
                collider.enabled = false;
                enemyAnimator.SetTrigger("Die");
                gameController.EnemyEliminated();
                Destroy(gameObject, 4f);
                
            }
        }
    }

}
