using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseManager : MonoBehaviour
{
    public bool continueMode;//si es nivel 1 que resetee, sino no
    Animator anim;
    bool isActive;
    void Start()
    {
        anim=GetComponent<Animator>();
    }
    private void Update() {
        if(isActive==false)return;
        if(continueMode&&Input.GetButtonDown("Jump")) SceneManager.LoadScene("Level2");
        if(Input.GetAxisRaw("Restart")==1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if(Input.GetAxisRaw("Restart")==-1)
            SceneManager.LoadScene("Menu");
    }
    public void SetTrigger(string trigger)=>anim.SetTrigger(trigger);
    public void _IsActive()=>isActive=true;
}
