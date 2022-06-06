using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToggleAudio : MonoBehaviour
{
    [SerializeField] private bool toggleMusic, toggleEffects;


    public void Toggle()
    {
        if (toggleEffects) AudioManager.Instance.ToggleEffects();
        if (toggleMusic) AudioManager.Instance.ToggleMusic();
        
    }

   
}
