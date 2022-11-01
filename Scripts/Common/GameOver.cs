using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    private PlayerHealthDamage PlayerHD;
    private Timer TimeR;
    //public GameObject diem;

    public bool yes_lost;
    public bool yes_end;
    public bool play_lost;
    public bool play_lost2;
    //public bool now_done;
    public int the_score;
    public int the_score2 = 1;

    void Start() {
        PlayerHD = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthDamage>();
        //Debug.Log("Bruh");
        //yes_lost = false;
        //PlayerHD.lost = false;
        TimeR = GameObject.Find("Timer").GetComponent<Timer>();
        //now_done = false;
        play_lost = true;
        play_lost2 = false;
    }

    public void Setup(int score) {
        //gameObject.SetActive(true);
        pointsText.text = "Score: " + score.ToString();
    }

    public void GameIsOver() {
        Setup(the_score); //1 should be score calculated (changed)
    }

    void Update() {
        the_score = PlayerHD.final_score - PlayerHD.time_left3*10 + PlayerHD.health_score;
        if (yes_lost || yes_end || (yes_lost && yes_end)) { //Also add if all enemies are defeated but less than 100 health
            //play_lost = true;
            makeGOver();
        }
        //if (PlayerHD.lost == true) {
            //Debug.Log("True");
            //yes_lost = true;
        //}

        //if (yes_lost == true) {
            //Debug.Log("abcd");
            //GameIsOver();
        //}
    }

    public void RestartButton() {
        SceneManager.LoadScene("MainMenu");
        SceneManager.LoadScene("Game(MainLevel)");
    }

    public void MenuButton() {
        SceneManager.LoadScene("MainMenu");
    }

    private void makeGOver() {
        //if (play_lost && play_lost2) {
        //if (play_lost) {
        //now_done = true;
          //play_lost = true;
          //play_lost2 = true;
        
        //diem.SetActive(true);
        GameIsOver();
    }
}
