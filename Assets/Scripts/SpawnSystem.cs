using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class SpawnSystem : MonoBehaviour
{
    public int roundsToWin;
    public int zombiesPerRound;

    public GameObject[] zombiesPrefab;
    public TextMeshProUGUI currentWave;

    public UnityEvent WinSing;

    int currentRoundsToWin=1;
    int zombiesSpawned;
    private void Awake() {
        //zombies ignoren colision de obstaculos
        Physics2D.IgnoreLayerCollision(23,24,true);
    }
    
    private void Update() {
        if(currentRoundsToWin>roundsToWin&&zombiesSpawned==0){
            WinSing.Invoke();
            return;
        }
        //si todos los zombies murieron y no gano, spawnea una nueva ronda
        else if(zombiesSpawned==0)
            StartCoroutine(SpawnNewRound());
    }
    IEnumerator SpawnNewRound(){
        zombiesSpawned=currentRoundsToWin*zombiesPerRound;

        for (int i = 0; i < zombiesSpawned; i++)
        {   //elige uno de los hijos para spawnear el zombie
            Transform child = this.transform.
                GetChild(Random.Range(0,this.transform.childCount));
            int random = Random.Range(0,zombiesPrefab.Length);
            GameObject zombiePrefab = null;
            if(zombiesPrefab.Length<=2)
                zombiePrefab=zombiesPrefab[random];
            else if(zombiesPrefab.Length==3){
                int _random = Random.Range(1,101);
                if(_random<=10)//10%
                    zombiePrefab=zombiesPrefab[2];
                else if(_random<=50)//40%
                    zombiePrefab=zombiesPrefab[1];
                else//40%
                    zombiePrefab=zombiesPrefab[0];
            }
            var zombie =Instantiate(zombiePrefab,child.position,Quaternion.Euler(Vector3.zero));
            zombie.GetComponentInChildren<HealthSytem>().spawnSystem=this;
            yield return new WaitForEndOfFrame();
        }
        currentWave.text=currentRoundsToWin.ToString();
        currentRoundsToWin++;
        yield break;
    }

    public void ZombieDying(){
        //Cuando un zombie muere, llama al evento, avisandole q murio
        zombiesSpawned--;
    }
}
