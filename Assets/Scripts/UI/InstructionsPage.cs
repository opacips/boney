using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsPage : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject tutorialPanel2;

    private void Start()
    {
        tutorialPanel2.SetActive(false);
        tutorialPanel.SetActive(true);
    }

    public void InvisibleTutorialButton()
    {
        tutorialPanel.SetActive(false);
        Time.timeScale = 1f;
        tutorialPanel2.SetActive(true);
    }

    public void InvisibleTutorialButton2()
    {
        tutorialPanel2.SetActive(false);
        Time.timeScale = 1f;
    }
}
