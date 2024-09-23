using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{
    [HideInInspector] public float score;
    public float spawnCooldownStart;
    [HideInInspector] public float spawnCooldown;
    public Transform spawnPos;
    public float cutoffDistance;

    Queue<GameObject> wasteList = new Queue<GameObject>();
    public GameObject[] waste;

    void Start()
    {
        Invoke("spawn", 5);
        spawnCooldown = spawnCooldownStart;
    }

    void Update()
    {
        if (spawnCooldown < .5){spawnCooldown = .5f;} 
        else {spawnCooldown = spawnCooldownStart - (0.01f * score);}
        if (wasteList.Count > 0){
            if (Input.GetKeyDown(KeyCode.A)){
                buttonPressed("compost");
            }
            if (Input.GetKeyDown(KeyCode.S)){
                buttonPressed("landfill");
            }
            if (Input.GetKeyDown(KeyCode.D)){
                buttonPressed("aluminum");
            }
        }
    }

    void spawn(){
        GameObject spawned = Instantiate(waste[Random.Range(0, waste.Length)], spawnPos.position, spawnPos.rotation);
        wasteList.Enqueue(spawned);

        Invoke("spawn", spawnCooldown);
    }
    void buttonPressed(string type){
        GameObject mostRecentWaste = wasteList.Dequeue();
        Vector3 distance = mostRecentWaste.transform.position - transform.position;
        //print(distance.magnitude);
        if (mostRecentWaste.tag == type && distance.magnitude <= cutoffDistance){
            Destroy(mostRecentWaste);
            score += 10 * distance.magnitude;
        } else {
            gameLost();
        }
    }
    public void gameLost(){
        print("score: " + score);
    }
}
