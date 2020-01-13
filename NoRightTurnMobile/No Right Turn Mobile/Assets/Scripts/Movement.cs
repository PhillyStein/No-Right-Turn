using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float rotation, 
                    speed;

    public Vector2 targetPos;

    public bool goingToTurn,
                isTurning,
                canTurn,
                winState,
                loseState;

    public Rigidbody2D carRB;

    // Start is called before the first frame update
    void Start()
    {

        rotation = transform.rotation.eulerAngles.z;
        loseState = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.eulerAngles = Vector3.forward * rotation;

        if (!isTurning && !winState && !loseState)
        {
            Drive();
        }

        if(canTurn)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                goingToTurn = true;
                canTurn = false;
            }
        }
    }

    public void Drive()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    public void Turn()
    {
        if (rotation == 90)
        {
            rotation = 180;
        }
        else if (rotation == 180)
        {
            rotation = 270;
        }
        else if (rotation == 270)
        {
            rotation = 0;
        }
        else
        {
            rotation = 90;
        }
        goingToTurn = false;
        isTurning = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "TurnTrigger")
        {
            if (goingToTurn)
            {
                isTurning = true;
                Turn();
            }
        }

        if(other.tag == "BeforeTurn")
        {
            canTurn = true;
        }

        if(other.tag == "FinishLine")
        {
            winState = true;
            GameManager.instance.WinLevel();
        }

        if(other.tag == "Boundary")
        {
            if (!winState)
            {
                loseState = true;
                GameManager.instance.LoseLevel();
            }
        }

        if(other.tag == "Oilslick")
        {
            float[] posRotations = { 0, 90, 180, 270};
            float newRotation = posRotations[Random.Range(0, 3)];
            while(newRotation == rotation) {
                 newRotation = posRotations[Random.Range(0, 3)];
            }

            rotation = newRotation;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "BeforeTurn")
        {
            canTurn = false;
        }

        if (other.tag == "Road")
        {
            if (!winState)
            {
                loseState = true;
                GameManager.instance.LoseLevel();
            }
        }
    }

    public void ClearStates()
     {
            winState = false;
            loseState = false;
     }
}
