using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    float delay = 1f;
    [SerializeField] ParticleSystem deathVFX;

    private void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        deathVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadLevel", delay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
    }
}
