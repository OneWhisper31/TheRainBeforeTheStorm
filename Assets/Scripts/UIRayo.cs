using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRayo : MonoBehaviour
{
    public AudioClip isReady;
    public AudioClip isUsed;

    [HideInInspector]
    public bool isActivated=true;

    Image rayo;
    AudioSource audioSource;

    private void Start() {
        rayo=GetComponent<Image>();
        audioSource=GetComponent<AudioSource>();
    }

    public void IsActivated(){
        rayo.color=new Color(1,1,1,1);
        audioSource.PlayOneShot(isReady);
    }
    public void IsDesactivated(){
        rayo.color=new Color(1,1,1,0.4f);
        audioSource.PlayOneShot(isUsed);
    }
}
