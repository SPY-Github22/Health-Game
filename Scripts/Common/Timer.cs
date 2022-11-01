using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    //float currentTime = 0;
    public float startingTime = 125;
    public TextMeshProUGUI timeText;
    public bool end;
    public GameObject GOver;
    private GameOver the_script;

    public GameObject GOver2;
    private GameWon the_script2;

    private PlayerHealthDamage PlayerHD;
    public bool oh_true;

    public float time_left;
    public int time_left2;

    //[SerializeField] Text countdownText;

    void Start() {
        startingTime = 125;
        //end = false;
        the_script = GOver.GetComponent<GameOver>();
        the_script2 = GOver2.GetComponent<GameWon>();
        //currentTime = startingTime;
        //timeText = this.GetComponent<TMPro.Text>().text;

        PlayerHD = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthDamage>();

        time_left = startingTime;
    }

    void Update() {
        if (startingTime > 0) {
            if (GOver2.activeSelf == false) {
                startingTime -= Time.deltaTime;
        }   }

        //else {
            //startingTime += 125;
        //}

        DisplayTime(startingTime);
        //currentTime -= Time.deltaTime;
        //countdownText.Text = currentTime.ToString("0");

        //if (currentTime <= 0) {
            //currentTime = 0;
        //}
    }

    void DisplayTime(float timeToDisplay) {
        if (timeToDisplay < 0) {
            timeToDisplay = 0;
            GOver.SetActive(true);
            end = true;
            the_script.yes_end = true;
            //Debug.Log(end);
        }

        else if (timeToDisplay < 0 && PlayerHD.currentHealth > 100) {
            oh_true = true;
        }

        else if ((timeToDisplay > 0 && GOver2.activeSelf) || (timeToDisplay > 0 && GOver.activeSelf)) { //2nd one remove and also on its script
            timeToDisplay += 1;
            time_left = timeToDisplay;
            time_left2 = Mathf.RoundToInt(time_left);
        }

        else if (timeToDisplay > 0) {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
