using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public HealthPlayer HPP;
    [SerializeField] int damagespike = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HPP.TakeDamage(damagespike);
        }
    }
}

