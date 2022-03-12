using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monitor : MonoBehaviour
{
    public zapis zapis;
    public GameObject gameObjectO;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            zapis.zapisbyl = 1;
            zapis.EventSystemValue = 2;
            gameObjectO.SetActive(true);
            zapis.Zapis();
            Destroy(gameObject);
        }
    }
}
