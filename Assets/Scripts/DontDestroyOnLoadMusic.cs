using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadMusic : MonoBehaviour
{
    private void Awake() {
        //si ya existe un manager, que se destruya el nuevo, sino que reproduzca
        var music = FindObjectOfType<DontDestroyOnLoadMusic>().gameObject;
        if(music&&music!=this.gameObject){
            Destroy(this.gameObject);
            return;
        }
        else
            DontDestroyOnLoad(this.gameObject);
    }
    private void Update() {
        if(SceneManager.GetActiveScene().name=="Menu")
            DestroyImmediate(this.gameObject);
    }
}
