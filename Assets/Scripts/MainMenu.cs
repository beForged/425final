using System.Collections;
using TMPro;
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
    public GameObject about;

    static Animator anim;

    private void Start()
    {
        anim = cam.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    public void Play(string sceneName)
    {
        Cursor.visible = false;
        StartCoroutine(LoadAsync(sceneName));
        ((GameManager) FindObjectOfType(typeof(GameManager))).snapSwitch(sceneName, 10.0f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void About()
    {
        GameManager gm = (GameManager)FindObjectOfType(typeof(GameManager));
        Save save = gm.save;
        string scores = "";
        int i = 1;
        foreach(string s in save.display)
        {
            scores += "Collectible " + i.ToString() + ": " + s + "\n";
            i++;
        }
        TextMeshProUGUI a = about.GetComponent<TextMeshProUGUI>();
        a.text = "This is a project for CMSC425. " +
            "The game is made by Richard Yu, Justin Goodman, and Minh Nguyen. " +
            "This is a first-person platformer, similar to Clustertruck, with a black/white style and glowy neon, think Tron, but better." +
            " The goal is to collect everything as fast as possible without dying." +
            " Death happens from  enemies." +
            " The environment will be split into 2 types: light and dark." +
            " Player will travel through light zones slowly. " +
            "On the other hand, dark zones can be traversed faster, but requires more skill to get through.\n" +
            scores;
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
