using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Elevator : MonoBehaviour
{
    public Animator OpenElevator;
    public AudioSource[] audios;
    bool Open;
    public GameObject lodidingscene;
    public Slider slider;
    public Text Progresstext;
    public zapis zapis;
    public Animator przycisk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenA()
    {
        if (!Open)
        {
            StartCoroutine(OpenElevatorA());
            Open = true;
        }
    }
    bool jest;
    public void CloseA()
    {
        if (Open&&jest)
        {
            Open = false;
            StartCoroutine(CloseElevatorA());
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") jest = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") jest = false;
    }

    IEnumerator OpenElevatorA()
    {
        StartCoroutine(Przycisk());
        audios[2].Play();
        yield return new WaitForSeconds(5);
        audios[2].Stop();
        audios[0].Play();
        yield return new WaitForSeconds(1);
        audios[1].Play();
        OpenElevator.SetBool("Open", true);
    }
    IEnumerator CloseElevatorA()
    {
        yield return new WaitForSeconds(1);
        OpenElevator.SetBool("Open", false);
        audios[1].Play();
        yield return new WaitForSeconds(3);
        audios[2].Play();
        yield return new WaitForSeconds(2);
        audios[2].Stop();
        zapis.Level=3;
        zapis.Zapis();
        StartCoroutine(loadAsynchosly(zapis.Level));
    }
    IEnumerator loadAsynchosly(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            Progresstext.text = progress * 100f + "%";

            yield return null;
        }
    }
    IEnumerator Przycisk()
    {
        przycisk.SetBool("Przycisk", true);
        yield return new WaitForSeconds(3);
        przycisk.SetBool("Przycisk", false);
    }
}
