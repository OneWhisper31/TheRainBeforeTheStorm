using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EscapeWithBoat : MonoBehaviour
{
    public UnityEvent winEvent;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player")
            winEvent.Invoke();
    }
}
