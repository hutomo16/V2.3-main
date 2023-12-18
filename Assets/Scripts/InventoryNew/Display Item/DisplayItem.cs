using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayItem : MonoBehaviour
{
    public Image itemImage;
    public ItemManager itemManager;

    void Start()
    {
        // Pastikan itemImage dan itemManager terpasang di Inspector
        UpdateItemDisplay();
    }

    void UpdateItemDisplay()
    {
        Sprite equippedItemSprite = itemManager.GetEquippedItem();

        if (equippedItemSprite != null)
        {
            itemImage.sprite = equippedItemSprite;
            itemImage.enabled = true;
        }
        else
        {
            itemImage.enabled = false;
        }
    }
}
