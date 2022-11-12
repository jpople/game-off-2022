using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    [SerializeField]
    float moveSpeed;

    void Start() {
        player = GameObject.Find("Player").transform;
    }

    private void FixedUpdate() {
        if ((player.position - transform.position).magnitude > 1) { // dirty hack, will worry about RigidBodies and etc. later
            transform.position += (CalculateMovementDirection() * moveSpeed);
        }
    }

    Vector3 CalculateMovementDirection() {
        return (player.position - transform.position).normalized;
    }
}
