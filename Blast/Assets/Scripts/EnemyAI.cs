using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAI : MonoBehaviour

{
    [SerializeField] GameObject[] EnemyLasers;
    [SerializeField] GameObject[] Player;
    [SerializeField] private float timer = 10f;
    private float laserTime;
    private IEnumerable<GameObject> lasersArray;
    public Transform spawnPoint;
    public float enemySpeed;

    void Update()
    {
        ProcessFiring();
        ActivateEnemyLasers();
        DeactivateEnemyLasers();
    }

    

    private void ProcessFiring()
    {
        laserTime -= Time.deltaTime;
        if (laserTime > 0) return;

        laserTime = timer;
        
      
    }
    // Start is called before the first frame update
    private void ActivateEnemyLasers()
    {
        foreach (GameObject EnemyLasers in lasersArray)
        {
            var eM = EnemyLasers.GetComponent<ParticleSystem>().emission;
            eM.enabled = true;
        }
    }

    private void DeactivateEnemyLasers()
    {
        foreach (GameObject EnemyLasers in lasersArray)
        {
            var eM = EnemyLasers.GetComponent<ParticleSystem>().emission;
            eM.enabled = false;
        }

        




    }
}
