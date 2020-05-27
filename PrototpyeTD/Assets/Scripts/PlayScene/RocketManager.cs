using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RocketManager : MonoBehaviour
{
    public GameObject rocket;
    public TMP_Text text;
    bool rocketSpawner;
    public float rateOfSpawning;


    private void Start()
    {
        StartStopSpawnRocket();
    }
    public void StartStopSpawnRocket()
    {
        text.text = rocketSpawner ? "START ROCKET SPAWN" : "STOP ROCKET SPAWM";
        rocketSpawner = rocketSpawner ? true : false;
    }
    private void Update()
    {

        if (rocketSpawner)
        {

            Instantiate(rocket);
        }
    }
}
