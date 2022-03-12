using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObjectScript : MonoBehaviour
{
    public InventoryObject inventory;
    public ItemObject ItemO;
    public int ItemVar;
    public void Item()
    {
        for (int i = 0; i < inventory.Container.Items.Length; i++)
        {
            if (inventory.Container.Items[i].ID == -1!)
            {
                inventory.AddItem(new Item(ItemO));
                gameObject.SetActive(false);
                return;
            }
        }
    }
}
