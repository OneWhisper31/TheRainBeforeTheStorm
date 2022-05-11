using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSytem :MonoBehaviour
{
    public int health;

    public Target target;
    public AudioClip zombieClip;

    public UnityEvent dead;

    public UnityEvent gotHit;
    
    [HideInInspector]
    public SpawnSystem spawnSystem;
    AudioSource audioSource;
    int currentHealth;
    

    private void Start() {
        currentHealth=health;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag==target.ToString()){
            gotHit.Invoke();
            Destroy(other.gameObject);
        }
    }
    public void OnPlayerDead(){
        Destroy(GetComponentInParent<Rigidbody2D>().gameObject);
    }
    public void OnDamaged(){
        currentHealth--;
        //call anim
        if(currentHealth==0) dead.Invoke();
    }
    public void OnHealed(){
        if(currentHealth>=4) return;
        currentHealth++;
        //call anim
    }
    public void OnEnemyDead(){
        //usado para descontar cuanto falta para una ronda y para el audioSource
        spawnSystem.ZombieDying();
        Destroy(GetComponentInParent<Rigidbody2D>().gameObject);
    }
    public void PlayOneShotSpawn(){
        if(audioSource==null)//primera vez que se ejecute
            audioSource=spawnSystem.GetComponent<AudioSource>();
        audioSource.PlayOneShot(zombieClip);
    }
}
public enum Target{
    Bullet,
    Bite
}