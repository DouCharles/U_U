using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Register : MonoBehaviour
{
    public InputField UsernameInput;
    public InputField PasswordInput;
    public InputField PasswordCheckInput;
    public InputField NameInput;
    public InputField EmailInput;
    public Toggle PlayerToggle;
    public Toggle CreatorToggle;

    public GameObject creator;
    public Dropdown School;
    public Dropdown Department;
    public Button UploadButton;

    public Image Appearance;
    public Sprite App1;
    public Sprite App2;
    public Sprite App3;
    public Button LeftButton;
    public Button RightButton;

    public GameObject login;
    public GameObject register;
    public Button RegisterButton;
    public Button BackLoginButton;

    public Text ResponseMessage;
    public Text VerifyMsg;

    int Identity = 0;
    int Character = 1;
    bool success;

    // Start is called before the first frame update
    void Start()
    {
        
        // 當選擇共創者，要求填寫共創學校系所資料及驗證身分
        creator.SetActive(false);
        PlayerToggle.onValueChanged.AddListener(delegate
        {
            if (PlayerToggle.isOn)
            {
                creator.SetActive(false);
                RegisterButton.interactable = true;
                Identity = 0;              
            }
            else
            {
                creator.SetActive(true);
                if(VerifyMsg.text == "**驗證成功**")
                {
                    RegisterButton.interactable = true;
                }
                else
                {
                    RegisterButton.interactable = false;
                }
                Identity = 1;
            }
            print(Identity);
        });

        // 選擇角色
        RightButton.onClick.AddListener(() =>
        {
            Character += 1;
            if (Character == 4) Character = 1;
            //C_test.text = Character.ToString();
            switch (Character)
            {
                case 1:
                    Appearance.GetComponent<Image>().sprite = App1;
                    break;
                case 2:
                    Appearance.GetComponent<Image>().sprite = App2;
                    break;
                case 3:
                    Appearance.GetComponent<Image>().sprite = App3;
                    break;
                default:
                    break;
            }
        });

        LeftButton.onClick.AddListener(() =>
        {
            Character -= 1;
            if (Character == 0) Character = 3;
            switch (Character)
            {
                case 1:
                    Appearance.GetComponent<Image>().sprite = App1;
                    break;
                case 2:
                    Appearance.GetComponent<Image>().sprite = App2;
                    break;
                case 3:
                    Appearance.GetComponent<Image>().sprite = App3;
                    break;
                default:
                    break;
            }
        });

        // 返回登入
        BackLoginButton.onClick.AddListener(() =>
        {
            ResponseMessage.text = "";
            login.SetActive(true);
            register.SetActive(false);
        });

        // 完成註冊
        RegisterButton.onClick.AddListener(() =>
        {
            if (Identity == 0)
            {
                StartCoroutine(Main.Instance.Web.Register(UsernameInput.text, PasswordInput.text, PasswordCheckInput.text, NameInput.text, EmailInput.text, Identity, Character, "", "",  (msg) =>
                {
                    switch (msg)
                    {
                        case 1:
                            ResponseMessage.text = "** 註冊成功 **";
                            login.SetActive(true);
                            register.SetActive(false);
                            break;
                        case 2:
                            ResponseMessage.text = "** 此使用者名稱已被使用 **";
                            break;
                        case 3:
                            ResponseMessage.text = "** 請填寫所有資料 **";
                            break;
                        case 4:
                            ResponseMessage.text = "** 確認密碼錯誤 **";
                            break;
                        default:
                            ResponseMessage.text = "**Error**";
                            break;
                    }

                }));
            }
            else
            {
                string school_val = School.options[School.value].text;
                string department_val = Department.options[Department.value].text;
                StartCoroutine(Main.Instance.Web.Register(UsernameInput.text, PasswordInput.text, PasswordCheckInput.text, NameInput.text, EmailInput.text, Identity, Character, school_val, department_val, (msg) =>
                {
                    switch (msg)
                    {
                        case 1:
                            ResponseMessage.text = "** 註冊成功 **";
                            login.SetActive(true);
                            register.SetActive(false);
                            break;
                        case 2:
                            ResponseMessage.text = "** 此使用者名稱已被使用 **";
                            break;
                        case 3:
                            ResponseMessage.text = "** 請填寫所有資料 **";
                            break;
                        case 4:
                            ResponseMessage.text = "** 確認密碼錯誤 **";
                            break;
                        default:
                            ResponseMessage.text = "**Error**";
                            break;
                    }

                }));
            }
        });
    }

    void Update()
    {
       
    }
}
