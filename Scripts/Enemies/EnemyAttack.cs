using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float enemyAttackUsCooldown;
    [SerializeField] public int enemyAttackUsDamage;
    [SerializeField] private CircleCollider2D boxCollider;

    public GameObject GOver;
    public GameObject GOver2;
    //public GameObject diem;
    //private GameOver the_script;
    //private GameWon the_script2;
    public Transform Player;
    private PlayerHealthDamage playerHealth;

    private Rigidbody2D rb2d;
    //private Vector2 movement;

    //public float moveSpeed = 5f;

    //public HealthBar health_bar;
    private float enemyAttackUsCooldownTimer = Mathf.Infinity;
    private bool collidedPlayerEnemy;
    public bool patrol;

    //private int abc = 0;
    
    private Animator anim;    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        //playerHealth = GetComponent<PlayerHealthDamage>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthDamage>();

        rb2d = this.GetComponent<Rigidbody2D>();
        //health_bar = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBar>();
    }

    private void Update()
    {
        enemyAttackUsCooldownTimer += Time.deltaTime;

        Vector3 direction = Player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb2d.rotation = angle;
        //direction.Normalize();
        //movement = direction;

        if (collidedPlayerEnemy == true)
        {
            //Debug.Log("YES");
            //collidedPlayerEnemy = false; //(CHECK THIS)

            //new WaitForSeconds(1.25f); // IF WAIT FOR MORE SECONDS WHEN HEALTH LOW THEN...EDIT TOO... //HEALTH BAR ALSO //THIS MORE THAN COOLDOWN (TOTAL TIME WILL BE COOLDOWN/ ITS' TIME WILL BE COOLDOWN)

            if (enemyAttackUsCooldownTimer >= enemyAttackUsCooldown)
            {
                if (GOver.activeSelf == false && GOver2.activeSelf == false) {
                    enemyAttackUsCooldownTimer = 0;
                    anim.SetTrigger("Attack");

                    //WHEN NOT IN COLLIDER- STOP

                    //enemyAttackUsDamage = 5;
                    //DamagePlayer();
                    //Debug.Log("Hi");
                    //return abc = 10;
                }
            }
            //else
            //{
                //nothing?
            //}
        }
    }

    //private void FixedUpdate() {
        //moveChar(movement);
    //}

    //void moveChar(Vector2 direction) {
        //rb2d.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        
            if (other.gameObject.name == "Player")
            {
                patrol = true;
                collidedPlayerEnemy = true;
            }

            else
            {
                collidedPlayerEnemy = false;
            }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Invoke("setCollidedNot", 0.75f);
            patrol = false;
        }
    }

    private void setCollidedNot() {
        collidedPlayerEnemy = false;
    }
    
    private void DamagePlayer()
    {
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
        //enemyAttackUsDamage = 5;
          //if (playerHealth == null)
          //{
            ///Debug.Log("Yes");
          //}
         // else {
          //if ()
          playerHealth.TakeDamage(enemyAttackUsDamage);
          //health_bar.SetHealth(currentHealth)
         // }
        }
        //else {Debug.Log("No");}
        //if (abc == 0)
        //{
           //gameObject.GetComponent<PlayerHealthDamage>.TakeDamage(enemyAttackUsDamage);
        //}
        //enemyAttackUsDamage = 5;
        //playerHealth =  new PlayerHealthDamage();// PlayerHealthDamage();
        //playerHealth = gameObject.AddComponent<PlayerHealthDamage>();
        
    }
}
