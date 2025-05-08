using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCleanup : MonoBehaviour
{
    public int countDown = 3;

    void Start()
    {
        Destroy(gameObject, countDown); //self destruct in x number of seconds   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
