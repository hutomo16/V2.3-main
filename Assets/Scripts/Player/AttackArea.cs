using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField]private int damage = 10;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<HealthMusuh>() != null)
        {
            HealthMusuh health = collider.GetComponent<HealthMusuh>();
            health.Damage(damage);
        }

        if (collider.GetComponent<HealthBos>() != null)
        {
            HealthBos health = collider.GetComponent<HealthBos>();
            health.Damage(damage);
        }
    }
}

