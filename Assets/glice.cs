using UnityEngine;

public class SurfaceGlissante : MonoBehaviour
{
    // Définir la force de glissement
    public float slidingForce = 5f;

    void OnCollisionStay2D(Collision2D collision)
    {
        // Vérifier si le collider en collision est celui du personnage
        if (collision.collider.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            // Si le Rigidbody2D est valide
            if (rb != null)
            {
                // Appliquer une force de glissement dans la direction opposée au mouvement actuel du personnage
                Vector2 slidingDirection = -rb.velocity.normalized;
                rb.AddForce(slidingDirection * slidingForce);
            }
        }
    }
}

