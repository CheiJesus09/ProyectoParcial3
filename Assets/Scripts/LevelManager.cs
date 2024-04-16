using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [Header("Level Data")]
    public SubjectContainer subject;

    //GameObjects para la UI
    [Header("User Interface")]
    public TMP_Text textQuestion;
    public TMP_Text questiongood;
    public GameObject CheckButton;
    public List<Option> option;
    public GameObject AnswerContainer;
    public Color Green;
    public Color Red;

    //Esto recibirá el script del scriptableObject
    [Header("Game Configuration")]
    public int questionAmount = 0;
    public int currentQuestion = 0;
    public string question;
    public string correctAnswer;
    public int answerFromPlayer = 0;

    [Header("Current Lesson")]
    public Leccion currentLesson;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        subject = SaveSystem.instance.subject;
        //Establecemos la cantidad de preguntas en la leccion
            questionAmount = subject.leccionList.Count;
        //Cargar la primera pregunta
        LoadQuestion();

        
    }


    //Cargar la pregunta siguiente
    private void LoadQuestion()
    {
        //Aseguramos que la pregunta actual este dentro de los limites
        if (currentQuestion < questionAmount)
        {
            //Establecemos la leccion actual
            currentLesson = subject.leccionList[currentQuestion];
            //Establecemos la pregunta
            question = currentLesson.lesson;
            //Establecemos la respuesta correcta
            correctAnswer = currentLesson.options[currentLesson.correctAnswer];
            //Establecemos la pregunta en la UI
            textQuestion.text = question;
            //Establecemos las Opciones
            for (int i = 0; i < currentLesson.options.Count; i++)
            {
                //Agregamos el contenido(respuesta), así como su ID
                option[i].GetComponent<Option>().OptionName = currentLesson.options[i];
                option[i].GetComponent<Option>().OptionID = i;
                option[i].GetComponent<Option>().Updatetext();
            }
        }
        else
        {
            //Si llegamos al final de las preguntas
            Debug.Log("Fin de las preguntas");
        }
    }


    //Para pasar a la siguiente pregunta
    public void NextQuestion()
    {
        //Checa el estado de la respuesta que seleciona el jugador.
        if (CheckPlayerState())
        {
            //Aseguramos que la pregunta actual este dentro de los limites de la cantidad de preguntas asignadas.
            if (currentQuestion < questionAmount)
            {
                //Revisamos si la pregunta es correcta o no.
                bool isCorrect = currentLesson.options[answerFromPlayer] == correctAnswer;

                // se activa la ventana que comprueba la respuesta en la UI.
                AnswerContainer.SetActive(true);

                // Se revisa si la respuesta es correcta o no es correcta.
                if (isCorrect)
                {
                    //Si sí es correcta, se actualizara el componente Image
                    //y se pondra de color verde para referencias que esta correcta la respuesta.
                    AnswerContainer.GetComponent<Image>().color = Green;
                    //Se actualiza el texto, usando un arreglo para poner el mensaje que deseamos mostrar y las variables
                    //string que contienen una cadena de letras.
                    questiongood.text = "Respuesta correcta. " + question + ": " + correctAnswer;
                    answerFromPlayer = 0;
                }
                else
                {
                    //Si no es correcta, se actualizara el componente Image
                    //y se pondra de color rojo para referencias que esta incorrecta la respuesta.
                    AnswerContainer.GetComponent<Image>().color = Red;
                    //Se actualiza el texto, usando un arreglo para poner el mensaje que deseamos mostrar y las variables
                    //string que contienen una cadena de letras.
                    questiongood.text = "Respuesta incorrecta. " + question + ": " + correctAnswer;
                }

                // Incrementamos el indice de la pregunta actual para que no se repita la pregunta.
                currentQuestion++;

                //Se llama la funcion ShowResultAndLoadQuestion que comienza una corrutina la cual
                //suspendera por 2.5 segundos el proceso de comprobar y cambiar de pregunta.
                StartCoroutine(ShowResultAndLoadQuestion(isCorrect));

                // reiniciar la respuesta del usuario
                answerFromPlayer = 9;

            }
            else
            {
                //Cambio la escena
            }
        }
    }

    //Inicia una corrutina que suspende el código dependiendo de lo que se especigique dentro
    //de esta
    private IEnumerator ShowResultAndLoadQuestion(bool isCorrect)
    {
        yield return new WaitForSeconds(1f);//Ajusta el tiempo que deseas mostrar el resultado
        //Oculta el contenedor
        AnswerContainer.SetActive(false);

        //Cargar la nueva pregunta
        LoadQuestion();

        //Activa el botón después de mostrar el resultado
        //Puedes hacer esto aquí o en LoadQuestion(), dependiendo de tu estructuraa
        //por ejemplo, si el botón está en el mismo GameObject que el script:
        //GetComponent<Button>().intercatable = true;
        CheckPlayerState();
    }

    //Asignará la respuesta del jugador
    public void SetPlayerAnswer(int _answer)
    {
        //Actualiza la respuesta del jugador
        answerFromPlayer = _answer;
    }

    //Nos aseguramos si el jugador presionó un botón para cambiar su color y activarlo
    public bool CheckPlayerState()
    {
        //Nos aseguramos si los botonoes cambian de color al ser presionados
        if (answerFromPlayer != 9)
        {
            //Actualizamos el componente boton para que sea interactuable
            CheckButton.GetComponent<Button>().interactable = true;
            //Actualizamos el componente Imagen para que cambie su color
            CheckButton.GetComponent<Image>().color = Color.white;
            return true;
        }
        else //Si no se interactua con el boton
        {
            //Actualizamos el componente boton para que no se pueda presionar
            CheckButton.GetComponent<Button>().interactable = false;
            //Actualizamos el componente Imagen para que cambie su color
            CheckButton.GetComponent<Image>().color = Color.grey;
            return false;
        }
    }

}