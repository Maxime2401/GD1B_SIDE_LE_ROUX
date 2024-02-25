using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Speed; // vitesse du monstre
    public Transform[] waypoints; // cloture du monstre
    public SpriteRenderer graphics; 

    private Transform target; // point de passage actuel
    private int destPoint = 0; // index du point de passage actuel

    void Start()
    {
        target = waypoints[0]; // initialise la cible avec le premier point de passage
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position; // calcul de la direction 
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World); // déplacement 

        // vérifie si le monstre est proche de sa cible
        if (Vector3.Distance(transform.position, target.position) < 0.03f)
        {
            // permet de passer au point suivant
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];

            // inverse l'anime
            graphics.flipX = !graphics.flipX; 
        }
    }

    // déclenché lorsqu'une collision 2D se produit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // vérifie si le joueur et le monstre entre en collision
        if (collision.transform.CompareTag("Player"))
        {
            // si oui Inflige des dégâts au joueur
            barvi barvi = collision.transform.GetComponent<barvi>();
            barvi.TakeDamage(20);
        }
    }
}
