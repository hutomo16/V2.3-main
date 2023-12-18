using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private bool Healed;
    public HealthPlayer HPP;
    [SerializeField] private AudioSource collectionSoundEffect;
    void Start()
    {
        HPP = GetComponent<HealthPlayer>();
        if (HPP == null)
        {
            Debug.LogError("Health script not found on the same GameObject as PlayerPickup.");
        }
    }

    void Update()
    {
        Canheal();
    }

    private void Canheal()
    {
        if (HPP != null && HPP.currentHealth < 5f)
        {
            Healed = true;
        }
        else
        {
            Healed = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Healed)
        {
            if (other.CompareTag("Heal"))
            {
                AudioManager.instance.PlaySFX("Collect");
                Destroy(other.gameObject);
                /*Debug.Log("player Healed");*/
                
            }
        }
        else
        {
            /*Debug.Log("can't be healed");*/
        }
    }
}
