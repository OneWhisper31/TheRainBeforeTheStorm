using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthColectable : MonoBehaviour
{
    public OnPickedUp onPickedUp;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            if(Camera.main.GetComponentInChildren<HealthUI>().currentHealth<4){
                onPickedUp.isPicked=true;
                other.GetComponentInChildren<HealthSytem>().OnHealed();
                Camera.main.GetComponentInChildren<HealthUI>().HealedUpdateUIHealth();
                Destroy(this.gameObject);
            }
        }
    }
}
