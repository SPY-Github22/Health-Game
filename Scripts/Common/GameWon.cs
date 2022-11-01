using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    private PlayerHealthDamage PlayerHD;
    public bool yes_won;
    public int the_score;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerHD = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthDamage>();        
    }

    // Update is called once per frame
    void Update()
    {
        the_score = PlayerHD.final_score;        

        if (yes_won) {
            GameIsWon();            
        }
    }

    public void Setup(int score) {
        //gameObject.SetActive(true);
        pointsText.text = "Score: " + score.ToString();
    }

    public void GameIsWon() {
        Setup(the_score + 250); //1 should be score calculated (changed)
    }

    public void MenuButton() {
        SceneManager.LoadScene("MainMenu");
    }
}
