using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PlayerLifeScript : MonoBehaviour
{
    public TextMeshProUGUI playerHealthText;
    public Image playerHealthBar;
    public int playerHealth = 100;
    public GameControllerScript gameController;
    private bool isInvincible = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameController = FindAnyObjectByType<GameControllerScript>();

        PlayerUpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(25);
        }
    }

    private void TakeDamage(int damage)
    {
        if (playerHealth <= 0 || isInvincible) return;

        playerHealth -= damage;
        if (playerHealth < 0) playerHealth = 0;

        PlayerUpdateUI();

        if (playerHealth <= 0)
        {
            gameController.GameOver();
        }
        else
        {
            StartCoroutine(InvincibilityTimer());
        }
    }

    private IEnumerator InvincibilityTimer()
    {
        isInvincible = true;
        yield return new WaitForSeconds(0.5f);
        isInvincible = false;
    }

    private void PlayerUpdateUI()
    {
        playerHealthText.text = "HP: " + playerHealth;
        playerHealthBar.fillAmount = playerHealth / 100f;
    }
}
