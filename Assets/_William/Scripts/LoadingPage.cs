using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingPage : MonoBehaviour {

    public GameObject loadPage;
    public Text loadText;
    public Slider loadBar;
    // Use this for initialization
    void Start()
    {
      
    }

    void StartClick(string sceneName, ScreenOrientation orientation)
    {
        Screen.orientation = orientation;
        loadPage.SetActive(true);
        StartCoroutine(StartLoading(sceneName));

    }
    IEnumerator StartLoading(string sceneName)
    {
        int displayProgress = 0;
        int toProgress = 0;
        AsyncOperation op = Application.LoadLevelAsync(sceneName);
        op.allowSceneActivation = false;
        while (op.progress < 0.9f)
        {
            toProgress = (int)op.progress * 100;
            while (displayProgress < toProgress)
            {
                ++displayProgress;
                SetLoadingPercentage(displayProgress);
                yield return new WaitForEndOfFrame();
            }
        }

        toProgress = 100;
        while (displayProgress < toProgress)
        {
            ++displayProgress;
            SetLoadingPercentage(displayProgress);
            yield return new WaitForEndOfFrame();
        }
        op.allowSceneActivation = true;
    }
    void SetLoadingPercentage(int persent)
    {
        loadText.text = persent.ToString() + "%";
        loadBar.value = (float)(persent / 100.00f);
    }

    public void ImmediateLoadingScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
