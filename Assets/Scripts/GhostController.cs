using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float speed = 3.0f; // Velocidad del fantasma
    private Transform target; // Objetivo del jugador
    public AudioSource muerte;

    // Método para establecer el objetivo del fantasma
    public void SetTarget(Transform playerTransform)
    {
        target = playerTransform;
    }

    private void Update()
    {
        // Si tiene un objetivo, sigue al jugador
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Rota el fantasma hacia el jugador manteniendo la rotación en -90 en X
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Euler(-90, 90, lookRotation.eulerAngles.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si colisiona con el jugador, destruye el fantasma
        if (other.CompareTag("Player"))
        {
            muerte.Play();
            Debug.Log("Fantasma Golpe");
            Destroy(gameObject); // Destruye el fantasma al colisionar con el jugador
        }
    }
}





