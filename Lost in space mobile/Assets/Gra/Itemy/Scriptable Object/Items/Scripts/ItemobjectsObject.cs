using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Itemobjects Object", menuName = "Inventory System/Items/Itemobjects")]
public class ItemobjectsObject : ItemObject
{
    public int rodzaj;
    public void Awake()
    {
        type = ItemType.ItemoObjects;
    }
}
