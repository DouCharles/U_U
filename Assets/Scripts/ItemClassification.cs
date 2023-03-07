using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemClassification : MonoBehaviour
{
    public ScrollRect Scroll_Rect;
    public GameObject Classlist;

    /*public GameObject Classlist_01;
    public GameObject Classlist_02;*/
    [SerializeField] private GameObject[] ClassList;
    [SerializeField] public Button Return_Button;
    [SerializeField] public Button Save_Button;
    [SerializeField] public Button Exit_Button;
    /*[SerializeField] public Button Class_01;
    [SerializeField] public Button Class_02;*/
    [SerializeField] public Button[] Class_btn;
    
    // Start is called before the first frame update
    
    void Start()
    {
        print(ClassList.Length);
        print(Class_btn.Length);
        for (int i = 0; i < Class_btn.Length; i++)
        {
            int t = i;
            Class_btn[i].onClick.AddListener(() => { print("i = " + i); list_active(ClassList[t]); });
        }
        /*Class_01.onClick.AddListener(() => list_active(Classlist_01));
        Class_02.onClick.AddListener(() => list_active(Classlist_02));*/
        Return_Button.onClick.AddListener(() => list_active(Classlist));
        Exit_Button.onClick.AddListener(() => LoadScene(4));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void list_active(GameObject targetlist)
    {
        Classlist.SetActive(false);
        for( int j = 0; j < ClassList.Length; j++)
        {
            ClassList[j].SetActive(false);
        }
        /*Classlist_01.SetActive(false);
        Classlist_02.SetActive(false);*/

        targetlist.SetActive(true);
        Scroll_Rect.content = targetlist.GetComponent<RectTransform>();
        
    }
    void LoadScene(int GoToSceneId)
    {
        SceneManager.LoadScene(GoToSceneId);
    }
}
