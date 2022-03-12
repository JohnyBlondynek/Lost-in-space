using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1event : MonoBehaviour
{
    public zapis zapis;
    public EventSystem eventSystem;
    public GameObject[] gameObjects;
    public GameObject player;
    private void Start()
    {
        if (zapis.EventSystemValue == 0)player.transform.position = gameObjects[0].transform.position;
        if (zapis.EventSystemValue == 2) player.transform.position = gameObjects[1].transform.position;
    }
    private void Update()
    {
        if (zapis.EventSystemValue == 0)
        {
            gameObjects[0].SetActive(true);
            gameObjects[1].SetActive(false);
        }
        else if (zapis.EventSystemValue == 2)
        {
            gameObjects[0].SetActive(false);
            gameObjects[1].SetActive(true);
            gameObjects[2].SetActive(false);
            gameObjects[3].GetComponent<Drzwi>().ERROR = false;
            eventSystem.lightSystem = false;
            gameObjects[4].SetActive(true);
            gameObjects[5].SetActive(true);
        }
    }
}
