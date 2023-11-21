using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{

    private float timeBetweenObstacles = 2f;
    private float startDelay = 1.5f;

    private PlayerController playerControllerScript;

    [SerializeField] private GameObject[] obstaclesArray;
    private int obstaclesIndex;

    private Vector3 spawnPos;

    private void Awake()
    {
        spawnPos = new Vector3(20, 0, 0);
    }
    private void Start()
    {
       playerControllerScript = FindObjectOfType<PlayerController>();

       InvokeRepeating("InstantiateRandomObstacles", startDelay, timeBetweenObstacles);

    }

    private void Update()
    {

        if (playerControllerScript.isGameOver)
        {
            CancelInvoke("InstantiateRandomObstacles");
        }

    }

    private void InstantiateRandomObstacles()
    {
        obstaclesIndex = Random.Range(0, obstaclesArray.Length);

        Instantiate(obstaclesArray[obstaclesIndex], spawnPos, Quaternion.identity);

        /*if (!playerControllerScript.isGameOver)
        {
            Instantiate(obstaclesArray[obstaclesIndex], spawnPos, Quaternion.identity);
        }*/


    }

}
