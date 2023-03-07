using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class door_code : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public string[] tips_txt = new string[4];
    private TMP_InputField[] ans = new TMP_InputField[4];
    private TMP_Text[] tips_obj = new TMP_Text[4];
    private Button finish;
    [SerializeField] private GameObject door;
    private int focus = 0;
    private bool auto_focus = true;
    [SerializeField] public string final_ans = "Open";
    
    void Start()
    {
        
        for(int i = 0; i < 4; i++)
        {
            ans[i] = transform.parent.GetChild(i).gameObject.GetComponent<TMP_InputField>();
           // Debug.Log(transform.parent.GetChild(i).name);
        }
        finish = transform.parent.GetChild(4).gameObject.GetComponent<Button>();
        //Debug.Log(finish.name);
        finish.onClick.AddListener(() => finish_clicked());
        for (int i = 0; i < 4; i++)
        {
            tips_obj[i] = transform.parent.GetChild(i + 5).gameObject.GetComponent<TMP_Text>();
            tips_obj[i].text = tips_txt[i];
        }

    }

    // Update is called once per frame
    void Update()
    {
        //if (auto_focus)
        ans[focus].Select();
        if(ans[focus].text.Length == 1 && focus < 3)
        {
            focus++;
        }
        if (Input.GetKeyDown(KeyCode.Backspace) && ans[focus].text.Length == 0)
        {
            focus--;
            if (focus < 0)
                focus = 0;
            ans[focus].text = "";
        }
    }

    public void finish_clicked()
    {
        string txt = "";
        for (int i = 0; i < 4; i++)
        {
            txt += ans[i].text;
        }
        if (txt == final_ans)
        {
            Debug.Log(name + "correct");
            
            transform.parent.gameObject.SetActive(false);
            door.transform.localPosition = new Vector3(-0.5f, door.transform.localPosition.y, -0.9f);
            door.transform.eulerAngles = new Vector3(0, 250, 0);

        }
        else
        {
            UserInfo.error_times++;
            this.transform.parent.gameObject.SetActive(false);
            Debug.Log("ERROR");
        }

    }
}
