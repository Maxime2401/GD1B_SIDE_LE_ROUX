using UnityEngine;

public class Suiviecam : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 postOffset;
    public float verticalSpeed = 5f; // vitesse de la caméra

    private Vector3 velocity;

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float verticalMovement = verticalInput * verticalSpeed * Time.deltaTime;
        postOffset.x += verticalMovement;// sert à cadrer la caméra

        // suivi du joueur avec un décalage
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + postOffset, ref velocity, timeOffset);
    }
}
