using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInventoryItems
{
    private Vector3 velocity;

    public virtual string Name => throw new System.NotImplementedException();

    public virtual Sprite Image => throw new System.NotImplementedException();

    public virtual void OnPickup()
    {
        throw new System.NotImplementedException();
    }
    public void SetLocation(MazeCell cell)
    {
        transform.localPosition = cell.transform.localPosition;
        velocity = cell.transform.localPosition;
    }
    // Start is called before the first frame update

}
