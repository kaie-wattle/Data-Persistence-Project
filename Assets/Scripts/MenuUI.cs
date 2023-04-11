using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputName;
    [SerializeField] private TextMeshProUGUI highScoreInfo;

    private void Start()
    {
        if(GameManager.instance != null)
        {
            highScoreInfo.SetText("High Score:" + GameManager.instance.highScoreName + ":" + GameManager.instance.highScore);
        }
    }

    public void StartButtom()
    {
        SceneManager.LoadScene(1);
        GameManager.instance.SetName(inputName.text);
    }

    public void ExitButtom()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
