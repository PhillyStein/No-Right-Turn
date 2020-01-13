using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Movement player;

    public SpriteRenderer playerSprite;

    public Sprite[] carSprites;

    public PlayerSettings playerSettings;

    // Start is called before the first frame update
    void Start()
    {
        RandomSprite();
    }

    // Update is called once per frame
    void Update()
    {
        player.goingToTurn = true;

        if(player.winState || player.loseState)
        {
            player.ClearStates();
        }

        if(Input.GetKeyUp(KeyCode.R))
        {
            RandomSprite();
        }
    }

    public void RandomSprite()
    {
        int ran = Random.Range(0, carSprites.Length - 1);
        playerSprite.sprite = carSprites[ran];
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
