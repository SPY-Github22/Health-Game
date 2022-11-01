using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    //public Transform Player;
    private bool inside = false;
    private int currentNumber = 0;
    private PlayerHealthDamage playerHealth;
    private Animator anim;

    [SerializeField] private int theHealth;

    [SerializeField] private int theNumber;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthDamage>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D obj) {
        if (obj.gameObject.name == "Player") {
            //Debug.Log("Yo"); //Works
            inside = true;
        }
        else {inside = false;}
    }

    private void OnMouseDown() {
        if (inside == true) {
            anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
            anim.SetTrigger("Attack");
            //Debug.Log("Okk"); //Kinda works
            currentNumber += 1;
            anim = GetComponent<Animator>();
        }
        if (currentNumber == theNumber) {
            playerHealth.TakeDamage(-theHealth);
            anim.SetTrigger("Die");
            Destroy(gameObject);
        }
    }
}
