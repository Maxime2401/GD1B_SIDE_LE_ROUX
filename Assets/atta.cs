using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject attackObject; //l'objet d'attaque
    public float attackDuration = 0.5f; // Durée de l'attaque
    private bool canAttack = false; // Indique si le joueur peut attaquer

    void Update()
    {
        // Vérifie si le joueur peut attaquer si oui le joueur attaque avec X
        if (canAttack && Input.GetKeyDown(KeyCode.X))
        {
            Attack();
        }
    }

    // L'attaque (il s'agit juste d'un objet mis devant le personage qui apparait et disparait )
    void Attack()
    {
        // Vérifie si l'objet d'attaque existe
        if (attackObject != null)
        {
            // Active l'objet d'attaque
            attackObject.SetActive(true);
            // Désactive l'attaque après un certain délai 
            Invoke("DisableAttack", attackDuration);
        }
    }

    // désactiver l'attaque 
    void DisableAttack()
    {
      
        attackObject.SetActive(false);
    }

    // activer la possibilitée de l'attaque lorsque le joueur prend un objet
    public void EnableAttack()
    {
        canAttack = true;
    }
}