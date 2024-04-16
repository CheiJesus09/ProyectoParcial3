using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Option : MonoBehaviour
{
    //Almacena la respuesta individual de cada boton
    public int OptionID;
    //Almacena el nombre de la respuesta
    public string OptionName;
    
// Aquí se asigna el texto del botón en la interfaz de usuario.
    public void Start()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }
    
/// Este metodo actualiza el texto de la opción en la interfaz de usuario.
/// Se llama al cambiar de pregunta.
    public void Updatetext()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = OptionName;
    }
    /// Detecta si el jugador selecciona la opción y actualiza la respuesta del jugador y la interactividad del botón de comprobación.
/// Se utiliza como evento de clic en el componente Button del mismo objeto.

public void SelectOption()
{
    LevelManager.Instance.SetPlayerAnswer(OptionID);
    LevelManager.Instance.CheckPlayerState();
}
}
