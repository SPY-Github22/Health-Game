using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAndroid : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;

    private Animator anim;
    private PlayerHealthDamage PlayerHD;

    public Joystick joystick;

    private void Awake() {
        anim = GetComponent<Animator>();
        PlayerHD = gameObject.GetComponent<PlayerHealthDamage>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHD.lost != true || PlayerHD.won != true) {

            moveInput.x = joystick.Horizontal;
            moveInput.y = joystick.Vertical;

            moveInput.Normalize();

            rb2d.velocity = moveInput * moveSpeed;

            if (moveInput.x > 0.01f) { //Left-Right Move
                transform.localScale = Vector3.one;
            }
            else if (moveInput.x < -0.0f) {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            anim.SetBool("Move", moveInput.x != 0);
        }
    }
}
