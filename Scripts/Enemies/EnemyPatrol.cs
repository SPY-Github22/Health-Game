using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints;

    public float walkSpeed;

    private bool nowWalk = true;

    int wayPointIndex = 0;

    //public Transform Player;

    private EnemyAttack enemyAttack;

    void Start() {
        transform.position = wayPoints[wayPointIndex].position;
        enemyAttack = gameObject.GetComponent<EnemyAttack>();
    }

    void Update() {
        //MovePatrol();
        if (enemyAttack.patrol == true) {
            nowWalk = false;
        } else nowWalk = true;
        
        if (nowWalk == true) {
            MovePatrol();
        }
    }

    public void MovePatrol() {
        if (wayPointIndex <= wayPoints.Count - 1) {
            var targetPosition = wayPoints[wayPointIndex].position;
            var moveThisFrame = walkSpeed*Time.deltaTime;
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPosition,
                moveThisFrame);

            if (transform.position == targetPosition) {
                wayPointIndex++;
            }
        }
        
        else {
                wayPointIndex = 0;
        }
    }
}
