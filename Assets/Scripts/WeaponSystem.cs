using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponSystem : MonoBehaviour
{
    public Texture2D cursorTexture;
    public GameObject bulletPrefab;
    public Transform playerCoords;
    public Camera mainCamera;
    public TextMeshProUGUI bulletCounter;
    public UIRayo ultiUI;
    public AudioClip bulletSound;
    public AudioClip outOfBullets;
    public float cooldownTime;
    public float UltiTime;
    public float UltiCooldown;
    public int intialBullets;
    AudioSource bulletsAudio;
    bool isUltiUsed;
    bool isUltipicked;
    float timeUntilUltiFinished;
    float currentCooldownTime;
    float currentUlti;
    int bullets;

    void Start()
    {
       bulletsAudio=GetComponent<AudioSource>();
       Cursor.SetCursor(cursorTexture,Vector2.zero, CursorMode.Auto);
       Cursor.lockState = CursorLockMode.Confined;
       bullets=intialBullets;
       UpdateUI();
    }
    void Update(){
        if(currentCooldownTime>0)currentCooldownTime-=Time.deltaTime;//cooldown para tirar otra bullet
        if(currentUlti>0)currentUlti-=Time.deltaTime;//cuanto dura la ulti
        if(timeUntilUltiFinished>0)timeUntilUltiFinished-=Time.deltaTime;//cuando se recarga
        if(currentUlti<=0) isUltiUsed=false;//si se queda sin tiempo se desactiva
        if(timeUntilUltiFinished<=0&&isUltipicked){
            if(!ultiUI.isActivated){
                ultiUI.IsActivated();//que se active
                ultiUI.isActivated=true;//que active una vez

            }
        }
        if(Input.GetButtonDown("Shift")&&currentUlti<=0&&timeUntilUltiFinished<=0&&isUltipicked){
            isUltiUsed=true;
            currentUlti=UltiCooldown;
            timeUntilUltiFinished=UltiTime;
            ultiUI.IsDesactivated();
            ultiUI.isActivated=false;
        }    
        if(Input.GetButton("Fire1")&&currentCooldownTime<=0&&bullets>0){
            currentCooldownTime=(isUltiUsed&&isUltipicked?cooldownTime/1.5f:cooldownTime);
            bulletsAudio.PlayOneShot(bulletSound);
            bullets--;
            UpdateUI();
            GameObject bullet= Instantiate(bulletPrefab,playerCoords.position,Quaternion.Euler(Vector3.zero));
        }
        else if(Input.GetButton("Fire1")&&bullets==0&&currentCooldownTime<=0){
            //asi no se reproduce infinito el sonido
            currentCooldownTime=cooldownTime;
            bulletsAudio.PlayOneShot(outOfBullets);
        }
    }   
    public void AddBullets(int incrementBullets){
        bullets+=incrementBullets;
        UpdateUI();
    }
    public void UltiPicked(){
        isUltipicked=true;
    }
    void UpdateUI(){
       bulletCounter.text = "x "+bullets;
    }
}
