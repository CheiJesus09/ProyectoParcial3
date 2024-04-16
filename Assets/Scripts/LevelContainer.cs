using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelContainer : MonoBehaviour
{

    [Header("GameObject Configuration")]
    public int Lection = 0;
    public int currentLession = 0;
    public int TotalLession = 0;
    public bool AreAllLessonsComplete = false;

    [Header("UI Configuration")]
    public TMP_Text StageTitle;
    public TMP_Text LessonStage;

    [Header("External GameObject Configuration")]
    public GameObject lessonContainer;

    [Header("Lesson Data")]
    public ScriptableObject LessonData;

    [Header("External GameObject Configuration")]
    public GameObject LesonContainer;
    public string LessonName;

    // Start is called before the first frame update
    void Start()
    {
        if (lessonContainer != null)
        {
            OnUpdateUI();
        }

        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo GameObject lessonContainer");
        }

    }

    public void OnUpdateUI()
    {

        if (StageTitle != null || LessonStage != null)
        {
            StageTitle.text = "Leccion " + Lection;
            LessonStage.text = "Leccion " + currentLession + " de " + TotalLession;
        }

        else
        {
            Debug.LogWarning("GameObject Nulo, revisa las variables de tipo TMP_text");
        }
    }

    public void EnableWindow()
    {
        OnUpdateUI();
        //hacemos que la ventana de la leccion aparezca y desaparezca
        if (LesonContainer.activeSelf)
        {
            LesonContainer.SetActive(false);
        }
        else
        {
            LesonContainer.SetActive(true);
            MainScript.instance.SetSelectedLesson(LessonName);
        }
    }

}
    
  
