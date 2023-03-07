using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TreasureCode_Cocreate : MonoBehaviour
{
    // Start is called before the first frame update
    private string[] text = new string[4];
    [SerializeField] private Button[] code;
    private int ans;
    private int[] num = new int[4];
    private bool[] isclicked = new bool[4];
    [SerializeField] private Button check_btn;
    private GameObject chest_close, chest_open;
    [SerializeField] public int final_ans = 15;
    [SerializeField] private InputField ans_input;

    private void Awake()
    {

    }
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            num[i] = 0;
            text[i] = "0";
            isclicked[i] = false;
        }
        code[0].onClick.AddListener(() => code_clicked(0));
        code[1].onClick.AddListener(() => code_clicked(1));
        code[2].onClick.AddListener(() => code_clicked(2));
        code[3].onClick.AddListener(() => code_clicked(3));

        check_btn.onClick.AddListener(() => Check_Clicked());
;
        

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
            code[k].GetComponentInChildren<TMP_Text>().text = "0";
            num[k] = 0;
        }
        else
        {
            isclicked[k] = true;
            text[k] = "1";
            code[k].GetComponentInChildren<TMP_Text>().text = "1";
            num[k] = 1;

        }
        //ans = 0;
        /*for(int i = 0; i < 4; i++)
        {

            ans += num[i] * (int)Mathf.Pow(2f,i);
            print("i = "+ i +"ans = " + ans);
        }*/

    }

    public void Check_Clicked()
    {
        print("check" + ans_input.text);
        if (ans_input.text != "" && 0<=int.Parse(ans_input.text)&& int.Parse(ans_input.text) <= 15)
        {
            final_ans = int.Parse(ans_input.text);
            transform.GetChild(2).gameObject.SetActive(false);
        }
    }


    
}
