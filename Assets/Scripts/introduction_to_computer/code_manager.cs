using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class code_manager : MonoBehaviour
{
    // Start is called before the first frame update
    private string[] text = new string[4];
    //[SerializeField] public Button test;
    private Button[] code= new Button[4];
    private GameObject code_ans;
    private int ans;
    private int[] num = new int[4];
    private bool[] isclicked = new bool[4];
    private Button check_btn, return_btn;
    [SerializeField]private GameObject chest_close, chest_open;
    [SerializeField] public int final_ans = 15;
    private int error_time = 0;
    [SerializeField] private int max_error_time = 5;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "EscapeRoom_1")
        {
            chest_close = GameObject.Find("chest_close");
            chest_open = GameObject.Find("chest_open");
            chest_open.SetActive(false);
        }
        else if(SceneManager.GetActiveScene().name == "EscapeRoom_SmallRoom")
        {
            chest_close = this.transform.parent.parent.parent.GetChild(0).gameObject;
            chest_open = this.transform.parent.parent.parent.GetChild(1).gameObject;
            chest_open.SetActive(false);
        }

    }
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "EscapeRoom_SmallRoom" || SceneManager.GetActiveScene().name == "EscapeRoom_1") {
            for (int i = 0; i < 4; i++)
            {
                code[i] = transform.parent.GetChild(i).gameObject.GetComponent<Button>();
                Debug.Log(transform.parent.GetChild(i).gameObject.name);


                num[i] = 0;
                text[i] = "0";
                transform.parent.GetChild(i).GetChild(0).gameObject.GetComponent<TMP_Text>().text = "0";
                isclicked[i] = false;
            }
            code[0].onClick.AddListener(() => code_clicked(0));
            code[1].onClick.AddListener(() => code_clicked(1));
            code[2].onClick.AddListener(() => code_clicked(2));
            code[3].onClick.AddListener(() => code_clicked(3));


            code_ans = transform.parent.GetChild(4).gameObject;
            Debug.Log(code_ans.name);
            ans = 0;
            code_ans.GetComponentInChildren<TMP_Text>().text = final_ans.ToString();
            

            check_btn = transform.parent.GetChild(5).gameObject.GetComponent<Button>();
            check_btn.onClick.AddListener(() => Check_Clicked());

            return_btn = transform.parent.GetChild(6).gameObject.GetComponent<Button>();
            return_btn.onClick.AddListener(() => return_clicked());
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void code_clicked(int k)
    {
        //int k = 0;
        /*Debug.Log("button clicked" + k);
        print("sadsadsad");
        print(isclicked.Length);*/
        if (isclicked[k])
        {
            isclicked[k] = false;
            text[k] = "0";
            transform.parent.GetChild(k).GetChild(0).gameObject.GetComponent<TMP_Text>().text = "0";
            num[k] = 0;
        }
        else
        {
            isclicked[k] = true;
            text[k] = "1";
            transform.parent.GetChild(k).GetChild(0).gameObject.GetComponent<TMP_Text>().text = "1";
            num[k] = 1;

        }
        ans = 0;
        for(int i = 0; i < 4; i++)
        {

            ans += num[i] * (int)Mathf.Pow(2f,i);
            print("i = "+ i +"ans = " + ans);
        }
        //code_ans.GetComponentInChildren<TMP_Text>().text = ans.ToString();

    }

    public void Check_Clicked()
    {
        if(final_ans == ans)
        {
            transform.parent.gameObject.SetActive(false);
            chest_close.SetActive(false);
            chest_open.SetActive(true);
            
        }
        else
        {
            error_time++;
            //info_manager temp = GameObject.Find("pass_check_point").GetComponent<info_manager>();
            //temp.error_times++;
            //pass_check.error_times++;
            UserInfo.error_times++;
            if (error_time == max_error_time)
            {
                info_manager.failed = true;
                Debug.Log("failed");
            }
            
            Debug.Log("error");
        }
    }

    public void return_clicked()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
