using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public GameObject countdownTimer;
    public int secondsLeft = 60;
    public bool takingAway = false;

    void Start()
    {
        countdownTimer.GetComponent<Text>().text = "TIME: 00:" + secondsLeft;
    }
    void Update()
    {
        if(takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }

        if(secondsLeft == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if(secondsLeft < 10)
        {
            countdownTimer.GetComponent<Text>().text = "TIME: 00:0" + secondsLeft;
        }
        else
        {
            countdownTimer.GetComponent<Text>().text = "TIME: 00:" + secondsLeft;
        }
        takingAway = false;
    }
    
}
