using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItems 
{
    // Start is called before the first frame update
    string Name { get; }
    Sprite Image { get; }
    void OnPickup();

}
public class InventoryEventArgs : EventArgs
{
    public IInventoryItems Item;
    public InventoryEventArgs(IInventoryItems item)
    {
        Item = item;
    }
}
