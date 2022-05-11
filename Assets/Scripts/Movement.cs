using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    
    [HideInInspector]
    public bool isInMud;
    Rigidbody2D rb;
    Animator anim;
    Vector3 inputs;

    private void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        inputs = new Vector3(Input.GetAxis("Horizontal"),
        Input.GetAxis("Vertical"),0);
        AnimHandler();
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.transform.position+Vector3.ClampMagnitude(inputs*(isInMud?speed/1.5f:speed)*Time.deltaTime,1));
    }
    void AnimHandler(){
        if(Input.GetAxisRaw("Horizontal")!=0||Input.GetAxisRaw("Vertical")!=0)
            anim.SetBool("IsMoving", true);
        else
            anim.SetBool("IsMoving", false);
        anim.SetFloat("Horizontal", inputs.x);
        anim.SetFloat("Vertical", inputs.y);
    }
    //Desactiva las animaciones para q quede en pose idle
    public void AnimWin()=>anim.SetBool("IsMoving",false);
}
