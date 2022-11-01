using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[]
public class PlayerHealthDamage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth; //{ get; }

    public int no_killed;
    public int no_left;
    public int time_left3;
    public int health_score;
    public int final_score;

    public GameObject GOver;
    public GameObject GOver2;
    public GameObject diem;
    private GameOver the_script;
    private GameWon the_script2;
    private Timer times;
    //public bool lost = false;

    public HealthBar healthBar;
    public bool lost;
    public bool won;

    // Start is called before the first frame update
    void Start()
    {
        if (healthBar != null)
        {
        //currentHealth = maxHealth - 85;
        healthBar.SetMaxHealth(maxHealth);
        }
        
        //GOver = GameObject.Find("Background");
        the_script = GOver.GetComponent<GameOver>();
        the_script2 = GOver2.GetComponent<GameWon>();
        times = GameObject.Find("Timer").GetComponent<Timer>();

        no_left = 16;
        no_killed = 0;
        health_score = 0;
        //time_left3 = Mathf.RoundToInt(times.startingTime); //Not needed


        //lost = false;
        
    }

    // Update is called once per frame
    //void Update()
    //{
        //if (Input.GetKeyDown(KeyCode.Space)) {
            //TakeDamage(5);
        //}
    //}

    public void TakeDamage(int damage) {
        //if (healthBar != null)
        //{
        currentHealth -= damage;
        
        
        if (healthBar != null)
        {
        healthBar.SetHealth(currentHealth);
        }
    }

    void Update() {
        no_left = GameObject.Find("Blue_Enemies").transform.childCount;
        no_killed = 16 - no_left;
        time_left3 = times.time_left2;
        final_score = no_killed*10 + time_left3*10;
        health_score = currentHealth - 15;

        if (health_score <= 0) {
            health_score = 0;
        }

        if (currentHealth >= 100 || times.oh_true) {
            GOver2.SetActive(true);
            won = true;
            the_script2.yes_won = true;
        }

        if (currentHealth <= 0) {
            //lost = true;
            diem.SetActive(true);
            GOver.SetActive(true);
            lost = true;
            the_script.yes_lost = true;
            
            //return;
            //Debug.Log("Yeah");
        }
    }
}
