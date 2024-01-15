using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] int points = 10;
    [SerializeField] float hP = 3;

    [SerializeField] GameObject hitVFX;
    [SerializeField] GameSession gS;

    private void Start()
    {
        gS = FindObjectOfType<GameSession>();
    }
    private void OnParticleCollision(GameObject other)

    {
        
        hP--; 
        if(hP<=0)
        {
            Destroy(gameObject);
            gS.increaseScore(points);
            GameObject explosion = Instantiate (hitVFX, transform.position, Quaternion.identity);
            Destroy(explosion, delay);
        }
        
        
        
    }

   
}
