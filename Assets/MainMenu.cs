using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public GameObject settingsCanvas;
    public GameObject gameTitle;
    public GameObject cam;

    static Animator anim;

    private void Start()
    {
        anim = cam.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    public void Play(string sceneName)
    {
        StartCoroutine(LoadAsync(sceneName));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        anim.SetTrigger("SettingsButton");

    }

    IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
    }
}
