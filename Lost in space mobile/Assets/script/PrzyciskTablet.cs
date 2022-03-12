using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrzyciskTablet : MonoBehaviour
{
    public GameObject Ekwipunek;
    public GameObject Mapa;
    public bool jest;
    public enum Przycisk
    {
        Ekwipunek,
        Mapa
    }
    public Przycisk przyciskT;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jest)
        {
            if (Input.GetButtonDown("Select") || Input.GetButton("Interakcja"))
            {
                if (przyciskT == Przycisk.Ekwipunek) {

                    Ekwipunek.SetActive(true);
                    Mapa.SetActive(false);
                }
                else if (przyciskT == Przycisk.Mapa)
                {
                    Ekwipunek.SetActive(false);
                    Mapa.SetActive(true);
                }
            }
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cursor") jest = true;

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cursor") jest = false;

    }
}
