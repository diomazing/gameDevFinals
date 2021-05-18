using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoundownTimerDark : MonoBehaviour
{
    public GameObject countdownTimerDark;
    public int secondsLeftDark = 60;
    public bool takingAwayDark = false;

    void Start()
    {
        countdownTimerDark.GetComponent<Text>().text = "TIME: 00:" + secondsLeftDark;
    }

    void Update()
    {
        if (takingAwayDark == false && secondsLeftDark > 0)
        {
            StartCoroutine(TimerTakeDark());
        }

        if (secondsLeftDark == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }

    IEnumerator TimerTakeDark()
    {
        takingAwayDark = true;
        yield return new WaitForSeconds(1);
        secondsLeftDark -= 1;
        if(secondsLeftDark < 10)
        {
            countdownTimerDark.GetComponent<Text>().text = "TIME: 00:0" + secondsLeftDark;
        }
        else
        {
            countdownTimerDark.GetComponent<Text>().text = "TIME: 00:" + secondsLeftDark;
        }
        takingAwayDark = false;
    }
}
