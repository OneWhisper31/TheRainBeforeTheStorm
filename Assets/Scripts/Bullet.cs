using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Transform mousePositionPivot;

    float LifeTime = 5f;

    void Start()
    {
        mousePositionPivot.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void Update() {
        LifeTime= LifeTime-Time.deltaTime;
        if(LifeTime<=0) 
            Destroy(this.gameObject);
    }
    private void FixedUpdate() {
        BulletMovement();
    }
    void BulletMovement(){
        if(Vector2.Distance(transform.position,mousePositionPivot.position)>0.5f)
            transform.position = Vector2.MoveTowards(transform.position, mousePositionPivot.position, speed*Time.deltaTime);
        else //si el vector de velocidad es demasiado chico, que le aumente la velocidad
            transform.position = Vector2.MoveTowards(transform.position, mousePositionPivot.position*2, speed*Time.deltaTime);
    }
}
