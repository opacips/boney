using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBall : MonoBehaviour
{
    public bool hasBall = false;
    public GameObject dog;
    public GameObject balldog;

    void Start()
    {
        dog.gameObject.SetActive(true);
        balldog.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            Destroy(other.gameObject);
            hasBall = true;
            dog.gameObject.SetActive(false);
            balldog.gameObject.SetActive(true);

            AudioManager.Instance.PlaySound(AudioManager.Instance.audioData.collectSound);
        }
    }
}
