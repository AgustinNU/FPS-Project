using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Damagescript : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Image healthBar;
    public int health = 100;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
