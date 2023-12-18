using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusuhDamage : MonoBehaviour
{
    public HealthPlayer HPP;
    [SerializeField] int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HPP.TakeDamage(damage);
        }
    }

}
