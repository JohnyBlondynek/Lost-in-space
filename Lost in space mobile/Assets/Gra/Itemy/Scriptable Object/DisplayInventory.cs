using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DisplayInventory : MonoBehaviour
{

    public GameObject invetoryPrefab;
    public InventoryObject inventory;
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEM;
    Dictionary<GameObject,InventorySlot> itemDisplayed = new Dictionary<GameObject,InventorySlot>();
    // Start is called before the first frame update
    void Start()
    {
        CreateSlots();
    }

    // Update is called once per frame
    void Update()
    {
        Updateslot();
    }
    public void Updateslot()
    {
        foreach(KeyValuePair<GameObject,InventorySlot>_slot in itemDisplayed)
        {
            if(_slot.Value.ID >= 0)
            {
                _slot.Key.transform.GetChild(0).GetComponent<Image>().sprite = inventory.itemDatabase.GetIem[_slot.Value.item.Id].uiDisplay;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
            }
            else
            {
                _slot.Key.transform.GetChild(0).GetComponent<Image>().sprite = null;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
            }
        }
    }
    public bool kontroller;
    EventTriggerType KontrollerClikc;
    public void CreateSlots()
    {
        itemDisplayed = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.Container.Items.Length; i++)
        {
            var obj = Instantiate(invetoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            itemDisplayed.Add(obj, inventory.Container.Items[i]);
            obj.GetComponent<Itemcrsor>().slot = i;
        }
    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN), Y_START + (-Y_SPACE_BETWEEN_ITEM * (i / NUMBER_OF_COLUMN)), 0f);
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Items = new InventorySlot[21];
    }
    
}
