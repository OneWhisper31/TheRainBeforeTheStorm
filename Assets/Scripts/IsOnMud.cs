using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOnMud : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            other.GetComponent<Movement>().isInMud=true;
        }
        else if(other.tag=="Enemy"){//health collider, busca al padre
            other.GetComponentInParent<ZombieBehaviour>().isInMud=true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="Player"){
            other.GetComponent<Movement>().isInMud=false;
        }
        else if(other.tag=="Enemy"){//health collider, busca al padre
            other.GetComponentInParent<ZombieBehaviour>().isInMud=false;
        }
    }
}
