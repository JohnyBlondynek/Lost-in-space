using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject lodidingscene;
    public Slider slider;
    public Text Progresstext;
    public zapis zapis;
    private void Start()
    {
        StartCoroutine(Continue());
    }
    IEnumerator Continue()
    {
        yield return new WaitForSeconds(2);
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
}
