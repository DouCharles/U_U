using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GenerateObject : MonoBehaviour
{
    [SerializeField] private GameObject[] Objects;
    [SerializeField] private Button[] Buttons;
    private Vector3 screenPoint;
    private Vector3 offset;

    [SerializeField] GameObject UI; //input the ans of gameobject
    [SerializeField] InputField inputfield;//input the ans of gameobject
    [SerializeField] Button OK_btn; //input the ans of gameobject
                                                        // Start is called before the first frame update

    void Start()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            GameObject Obj = Objects[i];
            Buttons[i].onClick.AddListener(()=>GenerateObj(Obj));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateObj(GameObject target)
    {
        //Debug.Log("Down");
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
        GameObject temp = Instantiate(target, new Vector3(3, 2, 3), new Quaternion(0,0,0,0));
        temp.tag = "drag";
        if(temp.name == "ClipBoard(Clone)")
        {
            PlayerController.can_move = false;
            Button btn = Instantiate(OK_btn);
            InputField input = Instantiate(inputfield);
            
            
            btn.GetComponent<RectTransform>().SetParent(UI.GetComponent<RectTransform>());
            input.transform.SetParent(UI.transform);
            RectTransform btn_rect = btn.GetComponent<RectTransform>();
            RectTransform input_rect = input.GetComponent<RectTransform>();
            btn_rect.localPosition = new Vector3(50, 70, 0);
            controlanchor.bottomMiddle(btn_rect);
            btn_rect.sizeDelta = new Vector2(100, 30);
            btn.GetComponentInChildren<Text>().text = "OK";

            
            input_rect.localPosition= new Vector3(-150, 70,0);
            controlanchor.bottomMiddle(input_rect);
            input_rect.sizeDelta = new Vector2(300, 100);

            input.placeholder.GetComponent<Text>().text = "請填入物件tips";
            btn.onClick.AddListener(() => { temp.GetComponent<tip_text>().txt = input.text;
                btn.gameObject.SetActive(false);
                input.gameObject.SetActive(false);
                PlayerController.can_move = true;
            });
            

        }
    }

    
}
