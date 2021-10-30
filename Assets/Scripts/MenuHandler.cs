using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
[DefaultExecutionOrder(1000)]
public class MenuHandler : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame

    public TMP_InputField inputfield;
    public TMP_Text bestscore;

        public void SetName(string username)
    {
        username = inputfield.text;
        DataTransfer.Instance.username = username;
    }
    void Start()

    {
        bestscore.text = "Best score: " + DataTransfer.Instance.highscore + " " + DataTransfer.Instance.hscore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
