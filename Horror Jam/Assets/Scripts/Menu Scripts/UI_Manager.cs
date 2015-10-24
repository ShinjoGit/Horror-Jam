using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Manager : MonoBehaviour
{
    public Text timer;
    public Text score;

    uint hours;
    uint minutes;
    float seconds;

    uint numScore;

    // Use this for initialization
    void Start ()
    {
        timer.text = "Time: 0";
        score.text = "ScOre: 0";

        hours = 0;
        minutes = 0;
        seconds = 0;
        numScore = 0;
    }

    // Update is called once per frame
    void Update ()
    {
        seconds += Time.deltaTime;
        checkTime();

        timer.text = "Time: " + hours + " : " + minutes + " : " + seconds.ToString("F0");
        numScore += 1;
        score.text = "ScOre: " + numScore;
	}

    void checkTime()
    {
        if (seconds > 59.0f)
        {
            seconds = 0;
            minutes += 1;
        }

        if (minutes > 59)
        {
            minutes = 0;
            hours += 1;
        }
    }

}
