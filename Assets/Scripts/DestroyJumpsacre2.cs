using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyJumpsacre2 : MonoBehaviour
{
    public float time;  
    void Start()
    {
        Destroy(gameObject, time);

    }    
}
