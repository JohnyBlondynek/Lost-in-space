using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Drzwi : MonoBehaviour
{
    public bool ERROR;
    public Animator[] animator;
    public AudioSource[] audios;
    public bool Jest;
    public void DrzwiI()
    {
        if (Jest == true)
        {
            Jest = false;

            if (!ERROR)
            {
                StartCoroutine(DrzwiZamkn());
                StartCoroutine(Przycisk());
            }
            else if (ERROR)
            {
                StartCoroutine(PrzyciskZepsuty());
            }
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
    IEnumerator DrzwiZamknBot()
    {
        animator[0].SetBool("Zamykanie", true);
        yield return new WaitForSeconds(3);
        yield return new WaitForSeconds(1);
        animator[0].SetBool("Zamykanie", false);
        yield return new WaitForSeconds(1);
        Jest = true;
    }
    IEnumerator Przycisk()
    {
        animator[1].SetBool("Przycisk", true);
        animator[2].SetBool("Przycisk", true);
        yield return new WaitForSeconds(3);
        animator[1].SetBool("Przycisk", false);
        animator[2].SetBool("Przycisk", false);
    }
    IEnumerator PrzyciskZepsuty()
    {
        animator[1].SetBool("Przycisk", true);
        animator[2].SetBool("Przycisk", true);
        audios[2].Play();
        yield return new WaitForSeconds(1);
        animator[1].SetBool("Przycisk", false);
        yield return new WaitForSeconds(2);
        Jest = true;
        animator[2].SetBool("Przycisk", false);
    }
    public void DrzwiIBot()
    {
        if (Jest == true)
        {
            Jest = false;

            if (!ERROR)
            {
                StartCoroutine(DrzwiZamknBot());
                StartCoroutine(Przycisk());
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Robot" && Jest == true)
        {
            DrzwiIBot();
        }
    }
}
