using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class drag : MonoBehaviour
{
    [SerializeField] private Button DeleteButton;
    [SerializeField] private Button CreativeButton;
    [SerializeField] private int mode = 1;
    [SerializeField] private float baseline;
    [SerializeField] private InputField input;
    [SerializeField] private Button button_ok;
    //private string door_ans;
    [SerializeField] private GameObject code;
    public string[] door_ans = new string[8] { "", "", "", "", "", "", "", "" };
    public bool door_IsSaved = false;
    [SerializeField] private GameObject finish_btn;
    private Vector3 last_pos;
    Rigidbody r;
    float distanceFromCamera;
    private void Awake()
    {
        door_IsSaved = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        //finish_btn = GameObject.Find("Finish_btn");
        if (finish_btn)
        {
            finish_btn.GetComponent<Button>().onClick.AddListener(() => set_door_ans());
        }

        DeleteButton.onClick.AddListener(ChangeMode);
        CreativeButton.onClick.AddListener(ChangeMode);
    }

    // Update is called once per frame
    void Update()
    {

        if (mode == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
                    if ((hit.transform.tag == "drag" || hit.transform.tag == "tracked"))
                    {
                        //drag : use drag_test  which needs to be put  on all obj 
                        //hit.transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
                    }
                    else if (hit.transform.name == "Door")
                    {
                        code.SetActive(true);

                        for (int i = 0; i < 8; i++)
                        {
                            Transform t = code.transform.GetChild(i);
                            print(t.name);
                            if (i < 4)
                            {
                                print("ans = " + door_ans[i]);
                                t.gameObject.GetComponent<TMP_InputField>().text = door_ans[i];
                            }
                            else
                            {
                                t.gameObject.GetComponent<InputField>().text = door_ans[i];
                            }
                        }


                    }


                }
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {

                rotate(new Vector3(30f, 0f, 0f));
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {

                rotate(new Vector3(0f, 30f, 0f));
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {

                rotate(new Vector3(0f, 0f, 30f));
            }
            else if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                print("plus");

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2);
                    if (hit.transform.tag == "drag" || hit.transform.tag == "tracked")
                        hit.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                print("minus");
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2);
                    if (hit.transform.tag == "drag" || hit.transform.tag == "tracked")
                        hit.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
                    if ((hit.transform.tag == "drag" || hit.transform.tag == "tracked") && hit.transform.name.Contains("CHEST"))
                    {
                        print(hit.transform.name +" / " +hit.transform.GetChild(0) + hit.transform.GetChild(1) + " / " + hit.transform.childCount);
                        if (hit.transform.GetChild(0).gameObject.active) 
                        {
                           
                            hit.transform.GetChild(0).gameObject.SetActive(false);
                            hit.transform.GetChild(1).gameObject.SetActive(true);
                            Vector3 boxcenter = hit.transform.GetComponent<BoxCollider>().center;
                            boxcenter.z = 0f;
                            hit.transform.GetComponent<BoxCollider>().center = boxcenter;
                            Vector3 boxsize = hit.transform.GetComponent<BoxCollider>().size;
                            boxsize.z = 1.7f;
                            hit.transform.GetComponent<BoxCollider>().size = boxsize;
                        }
                        else
                        {
                            hit.transform.GetChild(0).gameObject.SetActive(true);
                            hit.transform.GetChild(1).gameObject.SetActive(false);
                            Vector3 boxcenter = hit.transform.GetComponent<BoxCollider>().center;
                            boxcenter.z = 0.7f;
                            hit.transform.GetComponent<BoxCollider>().center = boxcenter;
                            Vector3 boxsize = hit.transform.GetComponent<BoxCollider>().size;
                            boxsize.z = 0.1f;
                            hit.transform.GetComponent<BoxCollider>().size = boxsize;
                        }
                    }

                }


            }
        }
        else if (mode == 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 8);
                    if (hit.transform.tag == "drag" || hit.transform.tag == "tracked")
                    {
                        /*DELETE FROM co_create*/
                        if (hit.transform.tag == "tracked")
                        {
                            StartCoroutine(delete_item(hit));
                            //delete_item(hit);
                        }
                        else
                        {

                            print("destoy untracked");
                            Destroy(hit.collider.gameObject);

                        }
                    }

                }
            }

        }

       
    }
    void ChangeMode()
    {
        if (mode == 1)
        {
            DeleteButton.gameObject.SetActive(false);
            CreativeButton.gameObject.SetActive(true);
            mode = 2;
        }
        else if (mode == 2)
        {
            DeleteButton.gameObject.SetActive(true);
            CreativeButton.gameObject.SetActive(false);
            mode = 1;
        }
    }

    void rotate(Vector3 angle)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2);
            if (hit.transform.tag == "drag" || hit.transform.tag == "tracked")
                hit.transform.Rotate(angle);
        }
    }

    void set_door_ans()
    {
       
        for(int i = 0; i < 8; i++)
        {
            Transform t = code.transform.GetChild(i);
            print(t.name);
            if (i < 4) 
                door_ans[i] = t.GetComponent<TMP_InputField>().text;
            else
                door_ans[i] = t.GetComponent<InputField>().text;
            print("door= "+door_ans[i]);
        }
        code.SetActive(false);
    }

    IEnumerator delete_item(RaycastHit item)
    {
        string[] name = item.transform.name.Replace("(Clone)", string.Empty).Split(":");
        string item_name = name[0] + ":Assets/Prefab/" + name[1] + ".prefab";
        string url = "http://localhost/unity/formal/co_create_delete.php";
        WWWForm form = new WWWForm();
        form.AddField("username", UserInfo.Username);
        form.AddField("room_name", UserInfo.room_name);
        form.AddField("item", item_name);
        /*form.AddField("username", UserInfo.username); 
         form.AddField("room_name", UserInfo.room_name);*/

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                print("destroy tracked");
                Destroy(item.collider.gameObject);
            }
        }
    }
}
