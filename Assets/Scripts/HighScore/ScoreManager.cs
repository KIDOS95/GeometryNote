using UnityEngine;
using TMPro;
using System.IO;
using System;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private int highScore;
    private int score;
    private int weather;

    [SerializeField] private string savePath;
    public Save sv = new Save();

    private void Start()
    {
        weather = RandomWeatherParser.Value;
    }

    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        savePath = Path.Combine(Application.persistentDataPath, "highScore.json");
#else
        savePath = Path.Combine(Application.dataPath, "highScore.json");
#endif
        if (File.Exists(savePath))
        {
            sv = JsonUtility.FromJson<Save>(File.ReadAllText(savePath));
        }

        LoadScore();
    }

    private void OnEnable()
    {
        Figure.OnObjectClicked += UpdateScore;
    }

    private void OnDisable()
    {
        Figure.OnObjectClicked -= UpdateScore;
    }

    private void UpdateScore()
    {
        score += weather;
        scoreText.text = score.ToString();

        SaveScore();
    }


    private void SaveScore()
    {
        if (score >= highScore)
        {
            highScore = score;
            sv.saveScore = score;
            string json = JsonUtility.ToJson(sv, true);
            File.WriteAllText(savePath, json);
        }
    }

    private void LoadScore()
    {
        if (!File.Exists(savePath))
        {
            return;
        }
        string json = File.ReadAllText(savePath);
        sv = JsonUtility.FromJson<Save>(json);
        highScore = sv.saveScore;
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause) File.WriteAllText(savePath, JsonUtility.ToJson(sv));
    }
#endif
    private void OnApplicationQuit()
    {
        File.WriteAllText(savePath, JsonUtility.ToJson(sv));
    }
}

