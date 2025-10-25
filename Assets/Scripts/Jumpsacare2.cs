using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Jumpsacare2 : MonoBehaviour
{
    public GameObject[] screamer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(screamer[Random.Range(0, screamer.Length)]);
            Destroy(gameObject);
        }
        Debug.Log("SCREAMER");
    }

}
