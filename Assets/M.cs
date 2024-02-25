using UnityEngine;

public class Mouv : MonoBehaviour
{
    public float moveSpeed; // vitesse de déplacement du joueur
    public float jumpForce; // force du saut

    private bool isJumping; // montre si le joueur est en train de sauter

    public Rigidbody2D rb; // rigidbody2D du joueur
    public Animator animator; // gére les animations
    public SpriteRenderer sprite; // Composant SpriteRenderer pour gérer l'apparence du joueur

    private Vector2 velocity = Vector2.zero; // vecteur de vitesse du joueur

    void FixedUpdate()
    {
        // calcul le déplacement horizontal 
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        // vérifie si le joueur appuie sur la touche d'espace et si il ne saute pas déja
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true; 
            Jump();
        }

        Move(horizontalMovement); 
        Flip(rb.velocity.x); 

        // met à jour la vitesse du joueur dans l'animator pour permettre le changement d'animation
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void Move(float _horizontalMovement)
    {
        
        Vector2 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);

        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);
    }

    void Jump()
    {
       
        rb.AddForce(new Vector2(0f, jumpForce));
    }

    void Flip(float _velocity)
    {
        // vérifie la vitesse horizontale pour déterminer le sens du joueur
        if (_velocity > 0.1f)
        {
            sprite.flipX = false; 
        }
        else if (_velocity < -0.1f)//met dans le bon sens
        {
            sprite.flipX = true; 
        }
    }

    // déclenché lorsqu'une collision 2D se produit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // vérifie si le joueur touche un objet avec le tag "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false; // le joueur n'est plus en train de sauter
        }
    }
}
