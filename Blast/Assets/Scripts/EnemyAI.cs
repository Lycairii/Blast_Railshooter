using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAI : MonoBehaviour

{
    [SerializeField] GameObject[] EnemyLasers;
    [SerializeField] GameObject[] Player;
    [SerializeField] private float timer = 5f;
    private float laserTime;
    private IEnumerable<GameObject> lasersArray;

    void Update()
    {
        ProcessFiring();
        
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
        foreach (GameObject enemylaser in lasersArray)
        {
            var eM = enemylaser.GetComponent<ParticleSystem>().emission;
            eM.enabled = true;
        }
    }

    private void DeactivateEnemyLasers()
    {
        foreach (GameObject enemylaser in lasersArray)
        {
            var eM = enemylaser.GetComponent<ParticleSystem>().emission;
            eM.enabled = false;
        }

        //




    }
}
