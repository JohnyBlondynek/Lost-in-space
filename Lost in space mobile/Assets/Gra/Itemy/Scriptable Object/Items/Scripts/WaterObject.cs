using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Water Object", menuName = "Inventory System/Items/Waterbjects")]
public class WaterObject : ItemObject
{
    public float Water;
    public void Awake()
    {
        type = ItemType.Water;
    }
}
