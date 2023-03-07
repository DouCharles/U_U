using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField UsernameInput;
    public InputField PasswordInput;
    public Button LoginButton;
    public Button RegisterButton;
    public Button EndButton;
    public Text ResponseMessage;
    public GameObject login;
    public GameObject register;

    // Start is called before the first frame update
    void Start()
    {
        // 登入按鈕
        LoginButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.Login(UsernameInput.text, PasswordInput.text, (msg) =>
            {
                switch (msg)
                {
                    case 1:
                        ResponseMessage.text = "**登入成功**";

                        SceneManager.LoadScene(2);
                        break;
                    case 2:
                        ResponseMessage.text = "**大學登入成功**";
                        SceneManager.LoadScene(9);
                        break;
                    case 3:
                        ResponseMessage.text = "**密碼錯誤**";
                        break;
                    case 4:
                        ResponseMessage.text = "**此使用者名稱不存在**";
                        break;
                    default:
                        ResponseMessage.text = "**Error**";
                        break;
                }
                
            }));
        });

        // 註冊按鈕
        RegisterButton.onClick.AddListener(() =>
        {
            ResponseMessage.text = "";
            login.SetActive(false);
            register.SetActive(true);
        });

        // 結束遊戲按鈕
        EndButton.onClick.AddListener(() =>
        {
            //EditorApplication.isPlaying = false;
            Application.Quit();
        });
    }
}
