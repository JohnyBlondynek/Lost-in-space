using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSystem : MonoBehaviour
{
    public EventSystem eventSystem;
    public MeshRenderer[] LightObject;
    public GameObject Light;
    // Update is called once per frame
    void Update()
    {
        if (eventSystem.lightSystem)
        {
            Light.SetActive(true);
            LightObject[0].enabled = false;
            LightObject[1].enabled = true;
        }
        else
        {
            Light.SetActive(false);
            LightObject[1].enabled = false;
            LightObject[0].enabled = true;
        }
    }
}
