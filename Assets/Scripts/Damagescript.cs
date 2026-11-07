using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Damagescript : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Image healthBar;
    public int health = 100;
    public Animator enemyAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Hit by projectile!");
            
            Destroy(collision.gameObject);
            health -= 25;
            healthText.text = health.ToString();
            healthBar.fillAmount = health / 100f;
            StartCoroutine(OnHit());    

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

    }

    private System.Collections.IEnumerator OnHit()
    {
        yield return new WaitForSeconds(.1f);
        enemyAnimator.SetBool("isWalking", false);
        enemyAnimator.SetBool("onHitt", true);
        yield return new WaitForSeconds(10f);
        enemyAnimator.SetBool("onHitt", false);
        enemyAnimator.SetBool("isWalking", true);
    }
}
