using UnityEngine;
using TMPro;
using System.IO;

public class DisplayHighScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScoreText;
    [SerializeField]
    private Save save;
    [SerializeField] private string savePath;

    private void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        savePath = Path.Combine(Application.persistentDataPath, "highScore.json");
#else
        savePath = Path.Combine(Application.dataPath, "highScore.json");
#endif

        LoadScore();
    }

    private void LoadScore()
    {
        if (!File.Exists(savePath))
        {
            return;
        }
        string json = File.ReadAllText(savePath);
        save = JsonUtility.FromJson<Save>(json);
        highScoreText.SetText(save.saveScore.ToString());
    }
}
