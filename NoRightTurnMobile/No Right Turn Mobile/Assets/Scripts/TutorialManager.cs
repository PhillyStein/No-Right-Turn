using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    public GameObject[] tutorialScreens;

    private int currentTut;

    // Start is called before the first frame update
    void Start()
    {
        UpdateTutorial();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.currentLevel == 1)
        {
            currentTut = 2;
            UpdateTutorial();
        }

        if (GameManager.instance.currentLevel == 2)
        {
            currentTut = 3;
            UpdateTutorial();
        }

        if (GameManager.instance.currentLevel == 3)
        {
            currentTut = 4;
            UpdateTutorial();
        }
    }

    public void UpdateTutorial()
    {
        foreach(GameObject screen in tutorialScreens)
        {
            screen.SetActive(false);
        }
        tutorialScreens[currentTut].SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            currentTut++;
            if (currentTut < tutorialScreens.Length)
            {
                UpdateTutorial();
            }
        }
    }
}
