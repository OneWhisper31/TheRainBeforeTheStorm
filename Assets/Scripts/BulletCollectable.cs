using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollectable : MonoBehaviour
{
    public OnPickedUp onPickedUp;
    public int bullets;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            onPickedUp.isPicked=true;
            other.GetComponentInChildren<WeaponSystem>().AddBullets(bullets);
            Destroy(this.gameObject);
        }
    }
}
