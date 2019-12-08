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
    public GameObject aboutCanvas;

    static Animator anim;

    private GameManager gm;

    private void Start()
    {
        anim = cam.GetComponent<Animator>();
        gm = (GameManager) FindObjectOfType(typeof(GameManager));
        gm.snapSwitch("Menu", 0.01f);
    }
    // Start is called before the first frame update
    public void Play(string sceneName)
    {
        StartCoroutine(LoadAsync(sceneName));
        gm.snapSwitch(sceneName, 3.0f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void About()
    {
        aboutCanvas.SetActive(true);
    }

    public void Settings()
    {
        aboutCanvas.SetActive(false);
        anim.SetTrigger("SettingsButton");
        aboutCanvas.SetActive(false);

    }

    IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        this.gameObject.SetActive(false);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
    }
}
