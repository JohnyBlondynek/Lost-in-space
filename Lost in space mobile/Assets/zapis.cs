using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zapis : MonoBehaviour
{
    public int Level=0;
    public int EventSystemValue;

    public Ustawienia ustawienia;

    [SerializeField] public bool zapisgryaktywny;
    public GameObject Gracz;
    public Transform spawn;
    public InventoryObject itemsave;
    public int zapisbyl;
    public Latarka latarka;
    // Start is called before the first frame update
    void Start()
    {
        ustawienia.sensivity = PlayerPrefs.GetFloat("Sensivity");
        ustawienia.volumeF = PlayerPrefs.GetFloat("Volume");
        ustawienia.language = PlayerPrefs.GetInt("language") != 0;
        ustawienia.fullscreen = PlayerPrefs.GetInt("Fullscreen") != 0;
        zapisbyl = PlayerPrefs.GetInt("Zapisbyl");
        EventSystemValue = PlayerPrefs.GetInt("EventSystemValue");
        Level = PlayerPrefs.GetInt("Level");
        itemsave.load();
        latarka.levelBaterry = PlayerPrefs.GetInt("BatteryLevel");
        latarka.TimeF = PlayerPrefs.GetFloat("BatteryTime");
        Gracz.GetComponent<Player>().czuloscMyszki = ustawienia.sensivity;
    }
    public void Zapis()
    {
            PlayerPrefs.SetInt("EventSystemValue", EventSystemValue);
            PlayerPrefs.SetInt("Level", Level);;
            PlayerPrefs.SetInt("Zapisbyl", zapisbyl);
        PlayerPrefs.SetInt("BatteryLevel", latarka.levelBaterry);
        PlayerPrefs.SetFloat("BatteryTime", latarka.TimeF);
            itemsave.save();
    }
    public void reset()
    {
        PlayerPrefs.SetInt("EventSystemValue", 0);
        PlayerPrefs.SetInt("Level", 2);
        PlayerPrefs.SetInt("Zapisbyl", 0);
        PlayerPrefs.SetInt("BatteryLevel", 6);
        PlayerPrefs.GetFloat("BatteryTime", 30);
        itemsave.Clear();
        itemsave.save();
    }
    public void zapisustawien()
    {
        PlayerPrefs.SetFloat("Sensivity", ustawienia.sensivity);
        PlayerPrefs.SetInt("language", ustawienia.language ? 1 : 0);
        PlayerPrefs.SetInt("Fullscreen", ustawienia.fullscreen ? 1 : 0);
        PlayerPrefs.SetFloat("Volume",ustawienia.volumeF);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) Zapis();
    }
}
