using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
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

    private string GetDebuggerDisplay()
    {
        return ToString();
    }

    //private void PlayerHealth();


    //private void ForceField Collisions

    //GetComponent<SphereCollider>

}


