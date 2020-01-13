using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    public Movement player;

    public Sprite playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        playerSprite = player.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Movement>().GetComponent<SpriteRenderer>().sprite = playerSprite;
    }

    public void SetSprite(Sprite sprite)
    {
        playerSprite = sprite;
    }
}
