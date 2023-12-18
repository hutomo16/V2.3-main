using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class KeyHandler : MonoBehaviour
{

    private bool Key1 = false;
    private bool Key2 = false;
    private bool Key3 = false;
    private bool Key4 = false;

    [Header("KeyList")]
    [SerializeField] private GameObject KeyObject1;
    [SerializeField] private GameObject KeyObject2;
    [SerializeField] private GameObject KeyObject3;
    [SerializeField] private GameObject KeyObject4;

    [Header("DoorList")]
    [SerializeField] private GameObject Door1;
    [SerializeField] private GameObject Door2;
    [SerializeField] private GameObject Door3;
    [SerializeField] private GameObject Door4;

    private void Update()
    {
        UseKeys();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == KeyObject1)
        {
            Key1 = true;
            Destroy(KeyObject1); 
        }
        else if (collision.gameObject == KeyObject2)
        {
            Key2 = true;
            Destroy(KeyObject2);
        }
        else if (collision.gameObject == KeyObject3)
        {
            Key3 = true;
            Destroy(KeyObject3);
        }
        else if (collision.gameObject == KeyObject4)
        {
            Key4 = true;
            Destroy(KeyObject4);
        }

        
    }

    private void UseKeys()
    {
        // Check if the player has the required key and the door is in the vicinity
        if (Key1 && Door1 != null)
        {
            Door1.SetActive(false);
        }
        if (Key2 && Door2 != null)
        {
            Door2.SetActive(false);
        }
        if (Key3 && Door3 != null)
        {
            Door3.SetActive(false);
        }
        if (Key4 && Door4 != null)
        {
            Door4.SetActive(false);
        }
    }

}
