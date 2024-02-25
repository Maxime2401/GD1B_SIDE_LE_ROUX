using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            // réduit la santé du monstre lorsqu'il prend un dégats
            TakeDamage();
        }
    }

    void TakeDamage()
    {
    
        currentHealth--;

        // Vérifie si le monstre est mort
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // le monstre meurt
        Destroy(gameObject); // donc détruire le GameObject du monstre
    }
}