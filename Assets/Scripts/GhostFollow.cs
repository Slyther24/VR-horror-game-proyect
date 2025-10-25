using UnityEngine;

public class GhostBehavior : MonoBehaviour
{
    private Transform player;
    private float speed;
    private GhostController spawner;

    public void Initialize(Transform playerTarget, float moveSpeed, GhostController ghostSpawner)
    {
        player = playerTarget;
        speed = moveSpeed;
        spawner = ghostSpawner;
    }

    private void Update()
    {
        if (player == null) return;

        // Ajusta la rotación hacia el jugador y mueve el fantasma hacia él
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Destruye el fantasma y notifica al spawner
            //spawner.GhostDestroyed();
            Destroy(gameObject);
        }
    }
}



