using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventaire.instance.AddCoins(1);
             Destroy(gameObject);
            
        }
    }
}