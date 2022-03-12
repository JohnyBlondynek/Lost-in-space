using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartE());
    }
    IEnumerator StartE()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
