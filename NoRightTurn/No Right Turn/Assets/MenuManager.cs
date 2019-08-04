using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Movement player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player.goingToTurn = true;

        if(player.winState || player.loseState)
        {
            player.ClearStates();
        }
    }
}
