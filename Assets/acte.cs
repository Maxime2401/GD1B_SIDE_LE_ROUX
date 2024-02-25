using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                // le joueur prend cet objet
                player.EnableAttack();
            }

            // détruire cet objet
            Destroy(gameObject);
        }
    }
}
