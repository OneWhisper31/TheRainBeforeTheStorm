using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPickedUp : MonoBehaviour
{
    public AudioClip audioClip;

    [HideInInspector]
    public bool isPicked;
    AudioSource audioSource;
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPicked){
            StartCoroutine(isPickedUp());
            isPicked=false;
        }
    }
    IEnumerator isPickedUp(){
        audioSource.PlayOneShot(audioClip);
        yield return new WaitForSeconds(1.2f);
        Destroy(this.gameObject);
        yield break;
    }
}
