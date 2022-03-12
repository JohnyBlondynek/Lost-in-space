using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public GameObject lodidingscene;
    public Slider slider;
    public Text Progresstext;
    public GameObject ustawnienia;
    public zapis zapis;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Continue()
    {
        if (zapis.zapisbyl == 1)
        {
            StartCoroutine(loadAsynchosly(zapis.Level));
            lodidingscene.SetActive(true);
        }
    }
    public void NewGame(int sceneIndex)
    {
        StartCoroutine(loadAsynchosly(sceneIndex));
        lodidingscene.SetActive(true);
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
    public void wyjdz()
    {
        Application.Quit();
    }
    public void ustawnieniaP()
    {
        ustawnienia.SetActive(true);
        menu.SetActive(false);
    }
    public void UstawieniaWyjdz()
    {
        ustawnienia.SetActive(false);
        zapis.zapisustawien();
        menu.SetActive(true);
    }
    public void menuGameover(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
