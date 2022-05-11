using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public float coolDown;
    public float radius;
    CircleCollider2D hitbox;
    float currentCoolDown;

    private void Update() {
        if(currentCoolDown>0) 
            currentCoolDown= currentCoolDown-Time.deltaTime;
        if(currentCoolDown<=0){
            //elige uno de los hijos para spawnear el item
            Vector3 randomPosition = transform.position + Random.insideUnitSphere*radius;
            randomPosition.z=0;
            Instantiate(itemPrefab,randomPosition,Quaternion.Euler(Vector3.zero));
            currentCoolDown=coolDown;
        }        
    }
}
