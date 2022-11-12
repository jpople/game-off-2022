using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCombat : DamageableEntity
{   
    [SerializeField]
    Collider2D attackRadius;

    float attackGauge;
    float attackThreshold = 1f;

    [SerializeField]
    TextMeshProUGUI debugText;

    void Start()
    {
        attackRadius.gameObject.SetActive(false);
        attackGauge = 0f;
    }

    void Update()
    {
        attackGauge += Time.deltaTime;
        if (attackGauge >= attackThreshold) {
            StartCoroutine(Attack());
        }
        debugText.text = $"Attack Gauge: {attackGauge} \nHP: {currentHP}";
    }

    private IEnumerator Attack() {
        attackGauge = 0f;
        attackRadius.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        attackRadius.gameObject.SetActive(false);
    }
}
