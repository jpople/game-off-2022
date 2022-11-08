using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        other.gameObject.GetComponent<DamageableEntity>().TakeDamage(10);
    }
}
