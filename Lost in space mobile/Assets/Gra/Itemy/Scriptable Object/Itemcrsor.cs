using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Itemcrsor : MonoBehaviour
{
    GameObject player;
    public InventoryObject itemobjectsObject;
    public Image sloto;
    public int slot;
    public int ItemId;
    public GameObject Cursor;
    static bool ograniczenie;
    bool jest;
    static bool jestall;
    GameObject cursorimage;
    // Start is called before the first frame update
    void Start()
    {
        Cursor = GameObject.Find("CursorItem");
        player = GameObject.Find("Player");
        cursorimage = GameObject.Find("Cursor");
    }
    // Update is called once per frame
    public void FixedUpdate()
    {
        if (jest)
        {
            if (Input.GetButton("SelectT") && ItemId > 0 && ograniczenie == false)
            {
                Cursor.GetComponent<Image>().enabled = true;
                Cursor.GetComponent<Image>().sprite = sloto.sprite;
                ograniczenie = true;
                Cursor.GetComponent<CursorItem>().Slot1 = slot;
                Cursor.GetComponent<CursorItem>().ItemID = ItemId;
                cursorimage.GetComponent<Image>().enabled = false;
            }
            if (!Input.GetButton("SelectT") && ograniczenie == true)
            {
                itemobjectsObject.Container.Items[Cursor.GetComponent<CursorItem>().Slot1].item.Id = ItemId;
                itemobjectsObject.Container.Items[Cursor.GetComponent<CursorItem>().Slot1].ID = ItemId;
                itemobjectsObject.Container.Items[slot].ID = Cursor.GetComponent<CursorItem>().ItemID;
                itemobjectsObject.Container.Items[slot].item.Id = Cursor.GetComponent<CursorItem>().ItemID;
                Cursor.GetComponent<CursorItem>().ItemID = 0;
                Cursor.GetComponent<CursorItem>().Slot1 = 0;
                ograniczenie = false;
                Cursor.GetComponent<Image>().enabled = false;
                cursorimage.GetComponent<Image>().enabled = true;
            }
            
            if (Input.GetButtonDown("Select") || Input.GetButton("Interakcja"))
            {
                if (ItemId == 5)
                {
                    FindObjectOfType<Latarka>().levelBaterry+=1;
                    itemobjectsObject.Container.Items[slot].item.Id = -1;
                    itemobjectsObject.Container.Items[slot].ID = -1;
                }
            }
        }
        if (!Input.GetButton("SelectT") && ograniczenie == true&&jestall==false)
        {
            Cursor.GetComponent<CursorItem>().ItemID = 0;
            Cursor.GetComponent<CursorItem>().Slot1 = 0;
            ograniczenie = false;
            Cursor.GetComponent<Image>().enabled = false;
            cursorimage.GetComponent<Image>().enabled = true;
        }
    }
    void Update()
    {
        ItemId = itemobjectsObject.Container.Items[slot].ID;
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cursor") jest=true;
        if (collision.gameObject.tag == "Cursor") jestall=true;

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cursor") jest = false;
        if (collision.gameObject.tag == "Cursor") jestall = false;

    }
}
