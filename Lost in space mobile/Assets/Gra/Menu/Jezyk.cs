using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jezyk : MonoBehaviour
{
    public Ustawienia ustawienia;
    public string Polski;
    public string Angielski;
    public Text text;
    // Update is called once per frame
    void Update()
    {
        if (ustawienia.language)
        {
            text.text = Polski;
        }
        else
        {
            text.text = Angielski;
        }
    }
}
