using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// <summary>
/// Esta clase gestiona las lecciones: recupera el contenido de preguntas y respuestas previamente guardadas
/// y maneja lo que aparece en la interfaz de usuario.
/// </summary>
public class LessonContainer : MonoBehaviour
{
    // Variables para configurar la lección:
    //Header= nos ayuda a clasificar y separar nuestras variables en el inspector por medio de etiquetas 
    [Header("Configuración del GameObject")]
    //aquí vamos a personalizar desde el inspector toda nuestra información que va a aparecer en el UI
    public int indiceLeccion = 0;
    public int indiceLeccionActual = 0;
    public int totalLecciones = 0;
    public bool todasLasLeccionesCompletas = false;

    // Variables para configurar la interfaz de usuario
    [Header("Configuración de la UI")]
    //estas variables TMP_Text ya están creadas en el canvas, esas se enlazarán con estas
    public TMP_Text tituloEtapa;
    public TMP_Text etapaLeccion;

    [Header("Configuración del GameObject Externo")]
    //esta es nuestra imagen principal que contiene las UI de los textos y el botón
    public GameObject contenedorLeccion;
    

    [Header("Datos de la Lección")]
    public ScriptableObject datosLeccion;
    public string NombreLeccion;


    /// <summary>
    /// Verifica si enlazamos el gameObject o nuestra imagen de contenedorLeccion, donde nos da la información de qué lección es,
    /// si no está enlazado, en la consola nos avisará que está vacío el contenedor con un mensaje de advertencia
    /// </summary>
    void Start()
    {
        //este va a verificar si nuestra imagen UI principal con toda nuestra infomacion está ligada en el inspector
        if(contenedorLeccion != null)
        {
            ActualizarUI();
        }
        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo GameObject contenedorLeccion");
        }
    }

    /// <summary>
    /// Este mét verifica si están enlazados a nuestro contenedor de la variable los textos, 
    /// <c>
    /// 1. Que nos comunica la Lección principal y actual seleccionada 
    /// 2. En qué nivel nos encontramos y si llevamos algún avance
    /// estos se ligan a otras variables que le informan qué botón fue seleccionado para saber qué imprimir en la UI
    /// </c>
    /// 
    /// En caso contrario, tenemos un else que nos avisa que tenemos que ligar nuestros textos, ya que actualmente se encuentran vacíos
    /// </summary>
    public void ActualizarUI()
    {
        //este va a verificar que nuestros textos estén ligados a nuestro inspector en sus variables correspondientes
        if(tituloEtapa != null || contenedorLeccion != null) 
        {
            //Los .text solo funcionan con variables TMP_Text
            tituloEtapa.text = "Lección " + indiceLeccion;
            etapaLeccion.text = "Lección " + indiceLeccionActual + " de " + totalLecciones;
        }
        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo TMP_Text");
        }
    }

    /// <summary>
    /// A la hora de jugar, este se encarga de aparecer y desparecer nuestra ventana de lecciones
    /// detecta si se interactuó con el botón, al hacer clic: se activa o se desactiva la ventana
    /// </summary>
    //Esta es una función o mé que nosotros creamos para personalizar por nuestra cuenta un evento
    //este mét específicamente activa/desactiva la ventana de contenedorLeccion
    public void EnableWindow()
    {
        ActualizarUI();
        //activeSelf es si está activado
        if (contenedorLeccion.activeSelf)
        {
            //desactiva el objeto si está activo
            contenedorLeccion.SetActive(false);
        }
        else
        {
            //activa el objeto si está desactivado
            contenedorLeccion.SetActive(true);
            MainScript.instance.SetSelectedLesson(NombreLeccion);
        }
    }
   
}
