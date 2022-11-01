using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1 : MonoBehaviour
{
    [SerializeField] Transform target;

    public Vector3 offset;

    void FixedUpdate() {
        transform.position = target.position + offset;
    }
}
