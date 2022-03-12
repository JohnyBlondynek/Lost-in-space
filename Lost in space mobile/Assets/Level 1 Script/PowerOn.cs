using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOn : MonoBehaviour
{
    public Animator przycisk;
    public int[] PowerI;
    public EventSystem eventSystem;
    public Drzwi[] drzwis;
    public GameObject zdanie;
    public AudioSource audio;
    public zapis zapis;
    bool jest;
    public GameObject[] Problemy;
    private void Update()
    {
        if (PowerI[0] == 1) Problemy[0].SetActive(false);
        if(PowerI[1]==1) Problemy[1].SetActive(false);
    }
    public void Interaction()
    {
        if (PowerI[0] == 1 && PowerI[1] == 1&&jest==false)
        {
            Problemy[2].SetActive(false);
            zapis.EventSystemValue = 3;
            jest = true;
            eventSystem.lightSystem = true;
            drzwis[0].ERROR = false;
            drzwis[1].ERROR = false;
            zdanie.SetActive(true);
            audio.Play();
        }
        StartCoroutine(Przycisk());
    }
    IEnumerator Przycisk()
    {
        przycisk.SetBool("Przycisk", true);
        yield return new WaitForSeconds(3);
        przycisk.SetBool("Przycisk", false);
    }
}
