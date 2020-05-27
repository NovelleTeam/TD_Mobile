using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RocketManager : MonoBehaviour
{
    public GameObject rocket;
    public TextMeshProUGUI text;
    bool rocketSpawner;

    private void Start()
    {
        StartStopSpawnRocket();
    }

    public void StartStopSpawnRocket()
    {
        if(rocketSpawner)
        {
            rocketSpawner = false;
            text.text = "START ROCKET SPAWN";
        }
        if(!rocketSpawner)
        {
            rocketSpawner = true;

            text.text = "STOP ROCKET SPAWM";
        }
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        Instantiate(rocket);
    }
}
