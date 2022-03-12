using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zadanieKomunikat : MonoBehaviour
{
    bool jest;
    // Update is called once per frame
    void Update()
    {
        if(!jest)StartCoroutine(enumerator());
    }
    IEnumerator enumerator()
    {
        jest = true;
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
