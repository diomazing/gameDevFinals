using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementScoreScript : MonoBehaviour
{
    public Text movementScoreText;
    private int movementsNumber;
    // Start is called before the first frame update
    void Start()
    {
        movementsNumber = 0;
        movementScoreText.text = "Movements Made : " + movementsNumber;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            movementsNumber += 1;
            movementScoreText.text = "Movements Made : " + movementsNumber;
        }else if(Input.GetKeyDown("a"))
        {
            movementsNumber += 1;
            movementScoreText.text = "Movements Made : " + movementsNumber;
        }else if(Input.GetKeyDown("s"))
        {
            movementsNumber += 1;
            movementScoreText.text = "Movements Made : " + movementsNumber;
        }else if (Input.GetKeyDown("d"))
        {
            movementsNumber += 1;
            movementScoreText.text = "Movements Made : " + movementsNumber;
        }
    }
}
