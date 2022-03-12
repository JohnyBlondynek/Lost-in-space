using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public string savePth;
    public ItemDatabaseObject itemDatabase;
    public inventory Container;
     
    public void AddItem(Item _item)
    {
        SetEmpetySlot(_item);
    }
    public InventorySlot SetEmpetySlot(Item _item)
    {
        for (int i = 0; i < Container.Items.Length; i++)
        {
            if (Container.Items[i].ID <= -1)
            {
                Container.Items[i].updateslot(_item.Id,_item);
                return Container.Items[i];
            }
        }
        return null;
    }
    [ContextMenu("Save")]
    public void save()
    {
        #region Optional Save
        string saveData = JsonUtility.ToJson(Container, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePth));
        bf.Serialize(file, saveData);
        file.Close();
        #endregion

        //IFormatter formatter = new BinaryFormatter();
        //Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePth), FileMode.Create, FileAccess.Write);
        //formatter.Serialize(stream, Container);
        //stream.Close();
    }
    [ContextMenu("Load")]
    public void load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePth)))
        {
            #region Optional Load
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePth), FileMode.Open, FileAccess.Read);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), Container);
            file.Close();
            #endregion

            //IFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePth), FileMode.Open, FileAccess.Read);
            //inventory newContainer = (inventory)formatter.Deserialize(stream);
            //stream.Close();
        }
    }
    [ContextMenu("Clear")]
    public void Clear()
    {
        Container = new inventory();
    }
}
[System.Serializable]
public class inventory
{
    public InventorySlot[] Items = new InventorySlot[21];
}
[System.Serializable]
public class InventorySlot
{
    public int ID=0;
    public Item item;
    public InventorySlot()
    {
        ID = -1;
        item = null;
    }
    public void updateslot(int _id,Item _item)
    {
        ID = _id;
        item = _item;
    }
}
