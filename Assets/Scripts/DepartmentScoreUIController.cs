using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DepartmentScoreUIController : MonoBehaviour
{
    [SerializeField] private GameObject[] DepartmentButton;
    [SerializeField] private GameObject DepartmentUI;
    [SerializeField] private GameObject TitleText;
    [SerializeField] private GameObject TimeText;
    [SerializeField] private GameObject ErrorText;
    [SerializeField] private GameObject TipsText;
    [SerializeField] private GameObject FailText;
    string[] InfoText = new string[4] { "", "", "", "" };
    // Start is called before the first frame update

    private void Awake()
    {
        /*for(int i = 0; i < pr.Length; i++)
        {
            pr[i] = 0;
        }*/
    }
    void Start()
    {
        for (int i = 0; i < DepartmentButton.Length; i++)
        {
            Text DepartmentName = DepartmentButton[i].GetComponent<Text>();
            DepartmentButton[i].GetComponent<Button>().onClick.AddListener(() => UIModify(DepartmentName));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UIModify(Text name)
    {
        InfoText[0] = Mathf.Round((UserInfo.pr_2[1, 3] + 1)).ToString();
        InfoText[1] = Mathf.Round((UserInfo.pr_2[1, 2] + 1)).ToString();
        InfoText[2] = Mathf.Round((UserInfo.pr_2[1, 1] + 1)).ToString();
        InfoText[3] = Mathf.Round((UserInfo.pr_2[1, 0] + 1)).ToString();
        /*for (int i = 0; i < 5; i++)
        {
            if (UserInfo.pr_2[1, 0] == i)
            {
                InfoText[3] = (100 - 20 * i).ToString();
                break;
            }
        }*/
        DepartmentUI.SetActive(true);
        TitleText.GetComponent<Text>().text = "您在" + name.text + "系的pr值為";
        TimeText.GetComponent<Text>().text = "Time : " + InfoText[0];
        ErrorText.GetComponent<Text>().text = "Error : " + InfoText[1];
        TipsText.GetComponent<Text>().text = "Tips : " + InfoText[2];
        FailText.GetComponent<Text>().text = "Fail : " + InfoText[3];
    }
}
