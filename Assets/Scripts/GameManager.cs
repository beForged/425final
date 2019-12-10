using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Audio;


public class GameManager : MonoBehaviour {
    public bool speedrun = false;
    public int[] collectibles = new int[5];
    public Save save;
    

    public AudioMixer mixer;

    void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
        // singleton pattern
        if (objs.Length > 1) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        BinaryFormatter bf = new BinaryFormatter();
        if(File.Exists(Application.persistentDataPath + "times.save"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "times.save", FileMode.Open);
            save = (Save)bf.Deserialize(file);
            file.Close();
        } else
        {
            save = createSaveObject();
        }
    }

    // for audio
    public void snapSwitch(string sceneName, float time) {
        switch (sceneName) {
            case "Menu":
                mixer.FindSnapshot("menu").TransitionTo(time);
                break;
            case "Main":
                mixer.FindSnapshot("level01").TransitionTo(time);
                break;
            default:
                break;
        }
    }

    private Save createSaveObject()
    {
        save = new Save();
        save.times = new float[collectibles.Length];
        save.display = new string[collectibles.Length];
        for (int i = 0; i < collectibles.Length; i++)
        {
            save.times[i] = float.MaxValue;
            save.display[i] = "Not yet set";
        }
        return save;
    }

    public void updateScores(int id, float time, string disp)
    {
        if (speedrun)
        {
            save.times[id] = time;
            save.display[id] = disp;
            BinaryFormatter bf = new BinaryFormatter();
            File.Delete(Application.persistentDataPath + "times.save");
            FileStream file = File.Create(Application.persistentDataPath + "times.save");
            bf.Serialize(file, save);
            file.Close();
        }
    }
}
