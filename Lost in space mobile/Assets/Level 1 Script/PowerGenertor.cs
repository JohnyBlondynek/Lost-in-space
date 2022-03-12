using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerGenertor : MonoBehaviour
{
    public Animator Dzwig;
    public PowerOn powerOn;
    public int whatVal;
    public AudioSource audios;
    bool jest;
    public void Interakcja()
    {
        if (!jest)
        {
            powerOn.PowerI[whatVal] = 1;
            Dzwig.SetBool("Power", true);
            audios.Play();
            jest = true;
        }
    }
}
