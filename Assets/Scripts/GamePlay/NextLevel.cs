using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private int nextSceneIndex;
    [SerializeField] GameObject dog;
    [SerializeField] GameObject balldog;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            balldog.gameObject.SetActive(false);
            dog.gameObject.SetActive(true);
            SceneManager.LoadScene(nextSceneIndex);

            AudioManager.Instance.PlaySound(AudioManager.Instance.audioData.congratsSound);
        }
    }
}
