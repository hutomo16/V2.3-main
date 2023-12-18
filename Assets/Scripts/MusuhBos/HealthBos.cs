using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBos : MonoBehaviour
{
    [Header("Damage L, Heal K")]
    [SerializeField] public int health = 100;
    [SerializeField] private int MAXHealth = 100;

    public FadeOut gameManager;
    //private bool isDead;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Heal(10);
        }
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Damage Can't be negative");
        }

        this.health -= amount;
        StartCoroutine(VisualIndicator(Color.red));

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Heal Can't be negative");
        }

        bool wouldbeOverMaxHealth = health + amount > MAXHealth;

        if (wouldbeOverMaxHealth)
        {
            this.health = MAXHealth;
        }
        else
        {
            this.health += amount;
        }
    }

    private void Die()
    {
        //isDead = true;
        Debug.Log("Object Died");
        gameManager.FadeOutCoba();
        Destroy(gameObject);
    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
