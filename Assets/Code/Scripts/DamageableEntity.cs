using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableEntity : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    [SerializeField]
    GameObject healthBar;

    void Awake() {
        currentHP = maxHP;
    }

    public void TakeDamage(int damageAmount) {
        currentHP -= damageAmount;
        float scaledHealth = ((float)currentHP / maxHP) * 100;
        healthBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, scaledHealth);
    }
}
