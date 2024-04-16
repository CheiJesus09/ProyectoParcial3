using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;

    

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;
    public Leccion data;
    public SubjectContainer subject;
    public Subject Subjects;

    //Patron Singleton: crea una instancia de la clase para ser referenciada en otra clase sin la necesidad de declarar una variables.
    private void Awake()
    { 
        if (instance != null)
        {
            return;
        }
        else
        {
            instance = this;
        }

        subject = LoadFromJSON<SubjectContainer>(PlayerPrefs.GetString("SelectedLesson"));
    }

  // se reproduce lo que hay aqui desde el primer frame
    private void Start()
    {
        // adquiere la funcion saveToJSon y guarda el nombre 
        //SaveToJSON("LeccionDummy",data);
        //agarra el subject o un Json con el nombre y lo guarda
        
        
    }
    public void createFile(string filename, string extension)
    {

    }

    // funcion encargada de almacenar objetos en archivos JSON
    public void SaveToJSON(string _filename, object _data)
    {
        // se comprueba ei data es nulo 
        if(_data != null)
        {
            // Convierte el data en un Json de JsonUtility
            string JSONData= JsonUtility.ToJson( _data, true );
            // comprueba y tiene un objeto o guardado el JsonData
            if (JSONData.Length != 0)
            {
                //Mensaje de asdvertencia donde se informa el almacenammiento de la información
                Debug.Log("JSON STRING: "+ JSONData);
                //Creacion del string FileName
                string fileName = _filename + ".json";
                //Se crea la ruta para guardar el JSON en su carpeta
                string filepath= Path.Combine(Application.dataPath + "/Resources/JSONS/", fileName);
                //Se escribe el Json en el archivo con el write text que muestra la info en forma de texto
                File.WriteAllText(filepath, JSONData);
                //Cofirmacion del guardado
                Debug.Log("Json almacenado en la direccion: "+ filepath);
            }
            else 
            {
                //Mensaje de error donde se indica que no hay datos 
                Debug.Log("ERROR - FyleSystem: _data is null, check for param [ string JSONData]");

            }
        }
        else
        {
            //mensaje que dice que no hay datos y se cheque el data del objeto 
            Debug.Log("ERROR - FyleSystem: _data is null, check for param [object _data]");
        }
    }

   //metodo que carga datos y puede devolverlos como en cualquier tipo el cual toma filename y duevuelve en tipo T
    public T LoadFromJSON<T>(string _filename) where T: new()
    {
        // secrea un dato del tipo generico T
        T dato = new T();
         
        string path = Application.dataPath+ "/Resources/JSONS/" + _filename+ ".json";
        
        string JSONdata = "";
        
        if (File.Exists(path)) 
        { 
        
         JSONdata = File.ReadAllText(path);
            
            Debug.Log("JSON STRING: "+ JSONdata);
        }
        else
        {
            Debug.LogWarning("ERROR - FileSystem: path doesnt exist, check for local variable [string path]");

        }
        //Comprueba el contenido del JSON
        if (JSONdata.Length != 0)
        {
            
            JsonUtility.FromJsonOverwrite(JSONdata, dato);
        }
        else
        {
            
            Debug.LogWarning("ERROR - FyleSystem: JsonData is null, check for param [ string JSONData]");
        }
       
        return dato;
    }
   
}
