using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class terminal_txt : MonoBehaviour
{
    [SerializeField] bool active = false;
    [SerializeField] Button exit_btn;
    [SerializeField] private string[] txt;
    // Start is called before the first frame update
    void Start()
    {

        print("terminal");
        exit_btn.onClick.AddListener(() => exit_clicked());
        Text txt_show = transform.parent.GetComponentInChildren<Text>();
        string temp = "";
        for(int i = 0; i < txt.Length; i++)
        {
            temp += txt[i];
            temp += "\n";
        }
        temp = temp.Replace("\\n", "\n");
        txt_show.text = temp;
        transform.parent.gameObject.SetActive(active);
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void exit_clicked()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
