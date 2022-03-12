using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ustawienia : MonoBehaviour
{
    public zapis zapis;
    public bool language;
    public bool fullscreen;
    public Slider Volume;
    public Slider SensivityS;
    public float sensivity;
    public float volumeF;
    private void Start()
    {
        SensivityS.value = sensivity;
        Volume.value = volumeF;
    }
    public void Update()
    {
        Screen.fullScreen = fullscreen;
        AudioListener.volume = volumeF;
    }
    public void Jezyk(bool jezyko)
    {
        language = jezyko;
    }
    public void FullScreen(bool fullscreenP)
    {
        fullscreen = fullscreenP;
    }
    public void VolumeP()
    {
        volumeF = Volume.value;
    }
    public void SensivityP()
    {
        sensivity = SensivityS.value;
    }
}
