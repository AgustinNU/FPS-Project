using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.AI;

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
            Destroy(collision.gameObject);
            health -= 25;
            healthText.text = health.ToString();
            healthBar.fillAmount = health / 100f;
            enemyAnimator.SetTrigger("onHit");


            if (health <= 0)
            {
                enemyAnimator.SetTrigger("Die");
                /*Destroy(gameObject);*/
                
            }
        }
    }

}
