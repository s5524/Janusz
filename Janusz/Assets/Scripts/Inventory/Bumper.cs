using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : Item
{
    // Start is called before the first frame update
    public override string Name => "Bumper";

    public Sprite _imaget;
    public override Sprite Image => _imaget;

    public override void OnPickup()
    {
        gameObject.SetActive(false);
    }
}
