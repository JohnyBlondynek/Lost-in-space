using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Helth Object", menuName = "Inventory System/Items/Helthbjects")]
public class HelthObject : ItemObject
{
    public float HelthRegen;
    public void Awake()
    {
        type = ItemType.Helth;
    }
}
