using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int currentLevel;

    public GameObject[] levels;

    public Movement player;

    public GameObject winScreen,
                        countdownPanel;

    public TextMeshProUGUI winText,
                            pressText,
                            countdownText;

    public Vector2[] levelStartPos = { new Vector2(-8, -3.5f), new Vector2(-8,-3.5f), new Vector2(0.5f,4.25f), new Vector2(-0.5f,-4.25f), new Vector2(-0.5f,-4.25f)};

    public float[] levelStartRotation = { 0, 0, 270, 90, 90 };

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

        if(Input.GetKeyUp(KeyCode.K))
        {
            player.winState = true;
            WinLevel();
        }

    }

    public void StartLevel()
    {
        foreach(GameObject level in levels)
        {
            level.SetActive(false);
        }
        if (currentLevel < levels.Length)
        {
            levels[currentLevel].SetActive(true);

            player.transform.position = levelStartPos[currentLevel];
            player.rotation = levelStartRotation[currentLevel];
            StartCoroutine(StartCountdown());
        } else
        {
            SceneManager.LoadScene("Menu");
        }
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
        if (isTutorial)
        {
            if (currentLevel == 3)
            {

                winText.text = "You Have Completed The Tutorial!";
                pressText.text = "Press LEFT to go to the main menu.";
            }
            else
            {
                winText.text = "Tutorial " + (currentLevel + 1) + " Complete!";
                pressText.text = "Press LEFT to go to the next level.";
            }
        }
        else
        {
            winText.text = "Level " + (currentLevel + 1) + " Complete!";
            pressText.text = "Press LEFT to go to the next level.";
        }
        winScreen.SetActive(true);
        currentLevel++;
    }

    public void LoseLevel()
    {
        player.canTurn = false;
        player.isTurning = false;

        winText.text = "Too bad! Try again!";
        pressText.text = "Press LEFT to restart level.";
        winScreen.SetActive(true);
    }
}
