using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SubjectContainer
{
    //es la leccion 
    [Header("Game object configuration")]
    [SerializeField]
    public int Lesson = 0;
    // es la lista de la lecciones
    [Header("Lession Quest Configuration")]
    [SerializeField]
    public List<Leccion> leccionList;
}
