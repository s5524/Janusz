using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheel : Item
{
    public override string Name => "SteeringWheel";

    public Sprite _imaget;
    public override Sprite Image => _imaget;

    public override void OnPickup()
    {
        gameObject.SetActive(false);
    }
}
