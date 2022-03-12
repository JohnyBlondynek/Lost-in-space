using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class interakcja : MonoBehaviour
{
    public Color[] MyszkaCol;
    public Camera kamera;
    public Image MyszkaIm;
    public GameObject gameObjectO;
    public LayerMask InterakcjaDrzwi=6;
    UnityEvent onInteract;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            RaycastHit hit;

            if (Physics.Raycast(kamera.transform.position,kamera.transform.forward, out hit, 2, InterakcjaDrzwi))
            {
                if (hit.collider.GetComponent<InterakcjaEvent>() != false)
                {
                    onInteract = hit.collider.GetComponent<InterakcjaEvent>().onInteract;
                    if (jest)
                    {
                        onInteract.Invoke();  
                    }
                }
                MyszkaIm.color = MyszkaCol[1];
            gameObjectO.SetActive(true);
            }
            else
            {
                MyszkaIm.color = MyszkaCol[0];
            gameObjectO.SetActive(false);
            }
        }
    bool jest;
    public void Funkcja()
    {
        if (!jest)StartCoroutine(enumerator());
    }
    IEnumerator enumerator()
    {
        jest = true;
        yield return new WaitForSeconds(1);
        jest = false;
    }

}
