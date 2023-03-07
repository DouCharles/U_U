using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartSceneUI : MonoBehaviour
{
    [SerializeField] private Button StartButton;
    [SerializeField] private Button TextButton;
    [SerializeField] private Button LeaveButton;
    [SerializeField] private Button CheckCertificateButton;
    [SerializeField] private Button AboutUsButton;
    [SerializeField] private GameObject TextUI;
    // Start is called before the first frame update
    void Start()
    {
        StartButton.onClick.AddListener(LoadScene);
        TextButton.onClick.AddListener(TextShow);
        LeaveButton.onClick.AddListener(LeaveGame);
        CheckCertificateButton.onClick.AddListener(() => { SceneManager.LoadScene(1); });//OpenURL(1));
        AboutUsButton.onClick.AddListener(() => OpenURL(2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
    void TextShow()
    {
        TextUI.SetActive(true);
    }
    void LeaveGame()
    {
        Application.Quit();
    }
    void OpenURL(int num)
    {
        if (num == 1)
        {
            Application.OpenURL("http://localhost/website/login.php");
        }
        else if (num == 2)
        {
            Application.OpenURL("http://localhost/website/about.html");
        }
    }
}
