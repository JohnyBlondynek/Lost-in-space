using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item DataBase",menuName ="Inventory System/Item/Data")]
public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemObject[] Items;
    public Dictionary<int ,ItemObject> GetIem = new Dictionary<int,ItemObject>();

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].Id = i;
            GetIem.Add(i, Items[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        GetIem = new Dictionary<int, ItemObject>();
    }
}
