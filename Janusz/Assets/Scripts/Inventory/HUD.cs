using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory Inventory;

    // Start is called before the first frame update
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
      

    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        //Transform inventoryPanel = transform.Find("Canvas");
        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    Debug.Log(transform.GetChild(i).name);
        //}
        //foreach (var item in transform.c)
        //{
        //    Debug.Log(item);

        //}
        foreach (Transform slot in transform)
        {
            Image image = slot.GetChild(0).GetComponent<Image>();
            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;
                break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
