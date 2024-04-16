using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageToggle : MonoBehaviour
{
    public GameObject imageWithText; // Referencia al objeto de la imagen con texto
    private bool isVisible = false; // Variable para controlar la visibilidad

    // Método para alternar la visibilidad de la imagen con texto
    public void ToggleImageVisibility()
    {
        // Si la imagen es visible, la oculta; de lo contrario, la muestra
        isVisible = !isVisible;
        imageWithText.SetActive(isVisible);
    }
}


