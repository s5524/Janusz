using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : Item 
{ 

    public override string Name => "Wheel";

    public Sprite _imaget;
    public override Sprite Image => _imaget;

    public override void OnPickup()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
  
}
