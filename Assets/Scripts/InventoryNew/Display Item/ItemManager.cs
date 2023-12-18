using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private Sprite equippedItemSprite;

    public Sprite GetEquippedItem()
    {
        return equippedItemSprite;
    }

    public void EquipItem(Sprite itemSprite)
    {
        equippedItemSprite = itemSprite;
    }
}
