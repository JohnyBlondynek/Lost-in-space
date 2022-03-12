using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;
using UnityEngine.UI;

public class InterAkcja : MonoBehaviour
{
    public InventoryObject inventory;
    public AudioSource[] audios;
    public Animator[] animator;
    public UnityEvent onInteract;
    bool Jest = true;
    bool gamover;
    bool menu;
    void Start()
    {

    }
    private void Update()
    {

    }
    public void Drzwi()
    {
        if (Jest == true)
        {
            Jest = false;
            StartCoroutine(DrzwiZamkn());
            StartCoroutine(Przycisk());
        }
    }
    public void PrzyciskNie()
    {
        if (Jest == true)
        {
            Jest = false;
            StartCoroutine(PrzyciskZepsuty());
        }
    }
    IEnumerator DrzwiZamkn()
    {
        animator[0].SetBool("Zamykanie", true);
        audios[0].Play();
        yield return new WaitForSeconds(3);
        audios[1].Play();
        yield return new WaitForSeconds(1);
        animator[0].SetBool("Zamykanie", false);
        yield return new WaitForSeconds(1);
        Jest = true;
    }
    IEnumerator Przycisk()
    {
        animator[1].SetBool("Przycisk", true);
        yield return new WaitForSeconds(3);
        animator[1].SetBool("Przycisk", false);
    }
    IEnumerator PrzyciskZepsuty()
    {
        animator[0].SetBool("Przycisk", true);
        audios[0].Play();
        yield return new WaitForSeconds(1);
        animator[0].SetBool("Przycisk", false);
        yield return new WaitForSeconds(2);
        Jest = true;
    }
    IEnumerator Botdrzwi()
    {
        animator[0].SetBool("Zamykanie", true);
        yield return new WaitForSeconds(8);
        animator[0].SetBool("Zamykanie", false);
        yield return new WaitForSeconds(1);
        Jest = true;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Robot" && Jest == true)
        {
            StartCoroutine(Botdrzwi());
        }
    }
    public ItemObject ItemO;
    public int ItemVar;
    public void Item()
    {
        for (int i = 0; i < inventory.Container.Items.Length; i++)
        {
            if (inventory.Container.Items[i].ID == -1!)
            {
                inventory.AddItem(new Item(ItemO));
                Destroy(gameObject);
                return;
            }
        }
    }

}