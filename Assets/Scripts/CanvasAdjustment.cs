using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAdjustment : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondCamera;
    public Canvas canvas;

    private void Start()
    {
        // Configura el Canvas en modo World Space para poder ajustarlo
        canvas.renderMode = RenderMode.WorldSpace;

        // Aseguramos que la segunda cámara está desactivada al inicio
        //secondCamera.enabled = false;
        canvas.worldCamera = mainCamera; // Asociamos inicialmente el Canvas a la cámara principal
    }

    private void Update()
    {
        if (secondCamera.isActiveAndEnabled)
        {
            AdjustCanvasToSecondCamera();
        }
    }

    public void ActivateSecondCamera(bool activate)
    {
        secondCamera.enabled = activate;

        if (activate)
        {
            AdjustCanvasToSecondCamera();
        }
        else
        {
            AdjustCanvasToMainCamera();
        }
    }

    private void AdjustCanvasToSecondCamera()
    {
        // Ajusta el Canvas a la segunda cámara
        canvas.worldCamera = secondCamera;
        AdjustCanvasDimensions(secondCamera);
    }

    private void AdjustCanvasToMainCamera()
    {
        // Ajusta el Canvas a la cámara principal
        canvas.worldCamera = mainCamera;
    }

    private void AdjustCanvasDimensions(Camera camera)
    {
        // Ajusta las dimensiones y posición del Canvas para que coincidan con la cámara activa
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        canvasRect.position = camera.transform.position + camera.transform.forward * 1f; // Ajusta la distancia si es necesario
        canvasRect.rotation = camera.transform.rotation;
        canvasRect.sizeDelta = new Vector2(camera.pixelWidth, camera.pixelHeight); // Ajusta tamaño al área visible de la cámara
    }

}
