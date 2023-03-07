using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChartClassChange : MonoBehaviour
{
    [SerializeField] private Button Class1;
    [SerializeField] private Button Class2;
    [SerializeField] private Button Class3;
    [SerializeField] private Button Class4;
    [SerializeField] private Button Class5;
    [SerializeField] private Button Class6;
    [SerializeField] private Button Class7;
    [SerializeField] private Button AnalysisButton;
    [SerializeField] private GameObject MainClass;
    [SerializeField] private GameObject Class1UI;
    [SerializeField] private GameObject Class2UI;
    [SerializeField] private GameObject Class3UI;
    [SerializeField] private GameObject Class4UI;
    [SerializeField] private GameObject Class5UI;
    [SerializeField] private GameObject Class6UI;
    [SerializeField] private GameObject Class7UI;
    [SerializeField] private GameObject AnalysisUI;
    // Start is called before the first frame update
    void Start()
    {
        Class1.onClick.AddListener(() => ChangeClassUI(1));
        Class2.onClick.AddListener(() => ChangeClassUI(2));
        Class3.onClick.AddListener(() => ChangeClassUI(3));
        Class4.onClick.AddListener(() => ChangeClassUI(4));
        Class5.onClick.AddListener(() => ChangeClassUI(5));
        Class6.onClick.AddListener(() => ChangeClassUI(6));
        Class7.onClick.AddListener(() => ChangeClassUI(7));
        AnalysisButton.onClick.AddListener(AnalysisOpenUI);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ChangeClassUI(int num)
    {
        print(num);
        if (num == 1)
        {
            MainClass.SetActive(false);
            Class1UI.SetActive(true);
        }
        else if (num == 2)
        {
            MainClass.SetActive(false);
            Class2UI.SetActive(true);
        }
        else if (num == 3)
        {
            MainClass.SetActive(false);
            Class3UI.SetActive(true);
        }
        else if (num == 4)
        {
            MainClass.SetActive(false);
            Class4UI.SetActive(true);
        }
        else if (num == 5)
        {
            MainClass.SetActive(false);
            Class5UI.SetActive(true);
        }
        else if (num == 6)
        {
            MainClass.SetActive(false);
            Class6UI.SetActive(true);
        }
        else if (num == 7)
        {
            MainClass.SetActive(false);
            Class7UI.SetActive(true);
        }
    }
    void AnalysisOpenUI()
    {
        MainClass.SetActive(false);
        AnalysisUI.SetActive(true);
    }
}
