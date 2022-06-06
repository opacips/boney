using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject Player;
    public GameObject dog;
    public GameObject balldog;

    public Image[] hearts;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            balldog.gameObject.SetActive(false);
            dog.gameObject.SetActive(true);
            Player.transform.position = startPoint.transform.position;
        }
    }
}
