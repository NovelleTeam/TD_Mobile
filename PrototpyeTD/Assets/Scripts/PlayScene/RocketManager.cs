using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RocketManager : MonoBehaviour
{
    public GameObject rocket;
    public TMP_Text text;
    bool rocketSpawner;
    bool st;

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
            StartCoroutine(wait());
        }
    }
    private void FixedUpdate()
    {
        if (rocketSpawner & st)
        {
            StartCoroutine(wait());
            st = false;
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        Instantiate(rocket);
        st = true;
    }
}
