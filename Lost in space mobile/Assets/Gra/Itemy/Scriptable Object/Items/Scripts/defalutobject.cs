using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New default Object",menuName ="Inventory System/Items/Default")]
public class defalutobject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Default;
    }
}
