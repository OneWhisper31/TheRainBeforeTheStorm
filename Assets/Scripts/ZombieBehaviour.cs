using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieBehaviour : MonoBehaviour
{
    public float speed;
    
    [HideInInspector]
    public bool isInMud;
    Transform player;
    HealthSytem playerHealth;
    Animator anim;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    // NavMeshAgent navAgent;
    
    bool isClose=false;//encargado de indicar si el zombie tiene q perseguir o no

    private void Start() {
        player=GameObject.FindGameObjectWithTag("Player").transform;
        anim=GetComponent<Animator>();
        sprite=GetComponent<SpriteRenderer>();
        rb=GetComponent<Rigidbody2D>();
        // navAgent=GetComponentInChildren<NavMeshAgent>();
        // StartCoroutine(UpdatePathHandler());
        // //para que no rote
        // navAgent.updateRotation=false;
        // navAgent.updateUpAxis=false;
    }
    private void Update() {
        if(player==null)return;
        //si la distancia va en negativo flipx
        if(player.position.x-this.transform.position.x<0)
            sprite.flipX=true;
        else
            sprite.flipX=false;
    }
    private void FixedUpdate() {
        if(player==null)return;
        if(!isClose)
            this.transform.position = Vector2.MoveTowards(this.transform.position, player.position, 
            (isInMud?speed/1.5f:speed)*Time.deltaTime);
    }
    // IEnumerator UpdatePathHandler(){//Encargado de actualizar el camino
    //     while(player!=null){
    //         if(!isClose){
    //             navAgent.SetDestination(player.position);
    //         }
    //         yield return new WaitForSeconds(0.3f);
    //     }
    //     yield break;
    // }
    private void OnTriggerEnter2D(Collider2D other) {
        //setea los timers y bools para volver a pegar
        if(other.tag=="Player"){
            isClose=true;
            anim.SetBool("Attack",true);
            if(playerHealth==null)//si es la primera vez, que se guarde su HealthSystem
                playerHealth=other.GetComponentInChildren<HealthSytem>();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag=="Player"){
            isClose=false;
            anim.SetBool("Attack",false);
        }
    }
    //Que el zombie pegue en el animator, y que llame a una funcion
    public void Onhit(){//Llama al evento encargado de recibir el daño
        if(player==null)return;
        playerHealth.gotHit.Invoke();
    }
}
