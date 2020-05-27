using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RocketSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private TMP_Text debugText;
    [SerializeField] private float spawnRate;
    bool rocketSpawner;

    private float rocketSpawnTimer;

    private void Start()
    {
        StartStopSpawnRocket();
    }
    public void StartStopSpawnRocket()
    {
        rocketSpawner = !rocketSpawner;
        debugText.text = rocketSpawner ? "START ROCKET SPAWN" : "STOP ROCKET SPAWM";
        rocketSpawnTimer = spawnRate;
    }
    private void Update()
    {
        rocketSpawnTimer -= Time.deltaTime;
        if(rocketSpawnTimer <= 0){
            ShootRocket();
            rocketSpawnTimer = spawnRate;
        }
    }

    private void ShootRocket(){
        Instantiate(rocketPrefab,spawnPoint.position,Quaternion.identity);
    }

}
