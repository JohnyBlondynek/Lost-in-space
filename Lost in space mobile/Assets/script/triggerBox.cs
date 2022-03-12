using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerBox : MonoBehaviour
{
    public GameObject gameObjects;
    public zapis zapis;
    public int whatValue;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"&&zapis.EventSystemValue==whatValue)
        {
            gameObjects.SetActive(true);
            Destroy(gameObject);
        }
    }
}
