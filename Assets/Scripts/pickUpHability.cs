using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class pickUpHability : MonoBehaviour
{
    public UnityEvent onPicked;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            onPicked.Invoke();///si entra en cierta zona, se activan elementos
            Destroy(this);
        }
    }

}
