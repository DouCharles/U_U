using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    [SerializeField] private Button ChatBoardButton;
    [SerializeField] private Button RadarChartButton;
    [SerializeField] private Button ApplyCertificateButton;
    [SerializeField] private Button TipsButton;
    [SerializeField] private Button LeaveButton;
    [SerializeField] private GameObject ButtonUI; 
    [SerializeField] private GameObject ChatBoardUI;
    [SerializeField] private GameObject RadarChartUI;
    [SerializeField] private GameObject ApplyCertificateUI;
    [SerializeField] private GameObject TipsUI;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(index);
        if (index == 2 || index == 3 || index == 4 ) // ChatBoardButton and RadarChartButton and ApplyCertificateButton
        {
            ChatBoardButton.gameObject.SetActive(true);
            RadarChartButton.gameObject.SetActive(true);
            ApplyCertificateButton.gameObject.SetActive(true);
            TipsButton.gameObject.SetActive(false);
            LeaveButton.gameObject.SetActive(true);
        } 
        else if (index == 5 || index == 8) // ChatBoardButton and TipsButton
        {
            ChatBoardButton.gameObject.SetActive(true);
            RadarChartButton.gameObject.SetActive(false);
            ApplyCertificateButton.gameObject.SetActive(false);
            TipsButton.gameObject.SetActive(true);
            LeaveButton.gameObject.SetActive(true);
        }
        else // All false
        {
            ChatBoardButton.gameObject.SetActive(false);
            RadarChartButton.gameObject.SetActive(false);
            ApplyCertificateButton.gameObject.SetActive(false);
            TipsButton.gameObject.SetActive(false);
            LeaveButton.gameObject.SetActive(true);
        }
        ChatBoardButton.onClick.AddListener(() => OpenUI(1));
        RadarChartButton.onClick.AddListener(() => OpenUI(2));
        ApplyCertificateButton.onClick.AddListener(() => OpenUI(3));
        TipsButton.onClick.AddListener(() => OpenUI(4));
        LeaveButton.onClick.AddListener(CloseGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenUI(int num)
    {
        ButtonUI.SetActive(false);
        if(num == 1)
        {
            ChatBoardUI.SetActive(true);
        }
        if(num == 2)
        {
            RadarChartUI.SetActive(true);
        }
        if(num == 3)
        {
            ApplyCertificateUI.SetActive(true);
        }
        if (num == 4)
        {
            TipsUI.SetActive(true);
            UserInfo.tips++;
        }
    }
    void CloseGame()
    {
        if (index == 5)
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        
    }

}
