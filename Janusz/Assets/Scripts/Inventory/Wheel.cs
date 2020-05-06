using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour ,IInventoryItems
{
    public string Name => "Wheel";

    public Sprite _imaget;
    public Sprite Image => _imaget;

    public void OnPickup()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
  
}
