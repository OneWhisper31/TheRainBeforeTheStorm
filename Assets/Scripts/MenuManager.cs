using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
            SceneManager.LoadScene("Level1");
        if(Input.GetButtonDown("Escape"))
            Application.Quit();
    }
}
