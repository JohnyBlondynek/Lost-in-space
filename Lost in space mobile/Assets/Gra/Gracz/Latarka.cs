using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Latarka : MonoBehaviour
{
    public AudioSource audios;
    [SerializeField] GameObject flashlisht;
    public bool flashlightactive = false;
    bool czasB;
    public Sprite[] sprite;
    public int levelBaterry;
    public float TimeF;
    public Image BatteryI;
    // Start is called before the first frame update
    void Start()
    {
        flashlisht.gameObject.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        if (levelBaterry > 6)
        {
            levelBaterry = 6;
            TimeF = 30;
        }
        if (flashlightactive == true)
        {
            if (TimeF < 1)
            {
                TimeF = 30;
                levelBaterry--;
            }
            TimeF -= 1 * Time.deltaTime;
        }
            BatteryI.sprite = sprite[levelBaterry];
        if (levelBaterry == 0)
        {
            flashlightactive = false;
            flashlisht.gameObject.SetActive(false);
        }
    }
    IEnumerator Czas()
    {
        yield return new WaitForSeconds(1);
        czasB = false;
    }
    public void LatarkaOnAndOff()
    {
        if (czasB == false && levelBaterry > 0)
        {
            if (flashlightactive == false)
            {
                flashlisht.gameObject.SetActive(true);
                flashlightactive = true;
                czasB = true;
                audios.Play();
                StartCoroutine(Czas());
            }
            else
            {
                flashlisht.gameObject.SetActive(false);
                flashlightactive = false;
                audios.Play();
                StartCoroutine(Czas());
                czasB = true;
            }
        }
    }
}
