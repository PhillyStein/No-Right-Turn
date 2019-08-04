using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int currentLevel;

    public GameObject[] levels;

    public Movement player;

    public GameObject winScreen,
                        countdownPanel,
                        finishLine;

    public TextMeshProUGUI winText,
                            pressText,
                            countdownText;

    public Vector2[] levelStartPos = { new Vector2(-8, -3.5f) },
                        finishLinePos = { new Vector2(5.5f, 5.5f)};

    public float[] levelStartRotation = { 0 };

    public static GameManager instance;

    public bool isTutorial;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if(winScreen.activeInHierarchy)
        {
            if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            {
                winScreen.SetActive(false);
                StartLevel();
            }
        }

    }

    public void StartLevel()
    {
        player.transform.position = levelStartPos[currentLevel];
        player.rotation = levelStartRotation[currentLevel];
        finishLine.transform.position = finishLinePos[currentLevel];
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        countdownPanel.SetActive(true);
        countdownText.text = "3";
        yield return new WaitForSeconds(1);
        countdownText.text = "2";
        yield return new WaitForSeconds(1);
        countdownText.text = "1";
        yield return new WaitForSeconds(1);
        countdownText.text = "Go!";
        yield return new WaitForSeconds(1);
        countdownPanel.SetActive(false);
        player.ClearStates();
    }

    public void WinLevel()
    {
        winText.text = "Level " + (currentLevel + 1) + " Complete!";
        pressText.text = "Press < to go to the next level.";
        winScreen.SetActive(true);
    }

    public void LoseLevel()
    {
        winText.text = "Too bad! Try again!";
        pressText.text = "Press < to restart level.";
        winScreen.SetActive(true);
    }

    public void NextLevel()
    {
        currentLevel++;

        foreach(GameObject level in levels)
        {
            level.SetActive(false);
        }

        if (currentLevel <= levels.Length)
        {
            levels[currentLevel].SetActive(true);
        }
    }
}
