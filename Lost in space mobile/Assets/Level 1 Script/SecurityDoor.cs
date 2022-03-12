using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityDoor : MonoBehaviour
{
    public Drzwi drzwi;
    public void open()
    {
        drzwi.ERROR = false;
    }
}
