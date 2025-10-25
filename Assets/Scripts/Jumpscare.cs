using System.Collections;
using UnityEngine;

public class Jumpscare : MonoBehaviour

{
    public Canvas[] jumpscares; // Arreglo de jumpscares
    public float displayTime = 2f; // Tiempo que el jumpscare estar� activo

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Selecciona un jumpscare aleatorio del arreglo
            int randomIndex = Random.Range(0, jumpscares.Length);
            Canvas selectedJumpscare = jumpscares[randomIndex];

            StartCoroutine(ShowCanvasForSeconds(selectedJumpscare, displayTime));
        }
    }

    private IEnumerator ShowCanvasForSeconds(Canvas canvasToShow, float seconds)
    {
        canvasToShow.gameObject.SetActive(true); // Activa el jumpscare seleccionado
        yield return new WaitForSeconds(seconds);
        canvasToShow.gameObject.SetActive(false); // Desactiva el jumpscare despu�s del tiempo especificado
        Destroy(gameObject); // Destruye el objeto despu�s de activar el jumpscare
    }
}




