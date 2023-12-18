using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour,IPointerClickHandler
{
    //=======ITEM Data========//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;

    [SerializeField]
    private int maxNumberOfItems;


    //=======ITEM SLOT========//
    [SerializeField]
    private TMP_Text quantityText;
    [SerializeField]
    private Image itemImage;

    //======= ITEM DESCRIPTION=======//
    public Image itemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;

    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }
    public int Additem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        //buat cek kalo slotnya udh full apa blm
        if (isFull)
            return quantity;

        //updateName    
        this.itemName = itemName;

        //update Image
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;
        itemImage.enabled = true;

        //update Description
        this.itemDescription = itemDescription;

        //update quantity
        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;
    
        //Return the LEFTOVERS
        int extraItems = this.quantity - maxNumberOfItems;
        this.quantity = maxNumberOfItems;
        return extraItems;
        }

        // update quantity text
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
     if ( eventData.button== PointerEventData.InputButton.Left )
        {
            OnleftClick();
        }
        if ( eventData.button == PointerEventData.InputButton.Right )
        {
            OnRightClick();
        }
    }
    public void OnleftClick()
    {
        if (thisItemSelected)
        {
            bool usable = inventoryManager.UseItem(itemName);
                if (usable)
            {
                this.quantity -= 1;
                quantityText.text = this.quantity.ToString();
                if (this.quantity <= 0)
                    EmptySlot();
            }
            
        }

        else
        { 
        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true); 
        thisItemSelected = true;
        ItemDescriptionNameText.text = itemName;
        ItemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite;
        if (itemDescriptionImage.sprite == null)
            itemDescriptionImage.sprite = emptySprite;
        }
    }

    private void EmptySlot()
    {
        quantityText.enabled = false;
        itemImage.sprite = emptySprite;
        itemDescription = "";
        itemName = "";

        ItemDescriptionNameText.text = "";
        ItemDescriptionText.text = "";
        itemDescriptionImage.sprite = emptySprite;
        itemSprite = emptySprite;
    }

    public void OnRightClick()
    {

    }
}
