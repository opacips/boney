using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyhole : MonoBehaviour
{
    [SerializeField] GameObject keyhole;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("key"))
        {
            Destroy(gameObject);
            Destroy(keyhole);
        }
    }
}
