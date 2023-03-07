using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
//#if UNITY_EDITOR
using UnityEditor;
//#endif

public class co_setting_roomname : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Button ok,new_old;
    [SerializeField] InputField room_name;
    [SerializeField] Dropdown dropdown;
    [SerializeField] Text txt;
    private string[] ItemMessage;
    bool mode = true;
    [SerializeField] GameObject[] load_prefab;
    void Start()
    {
        dropdown.gameObject.SetActive(false);
        txt.text = "請輸入新密室名字";
        new_old.GetComponentInChildren<Text>().text = "舊密室";
        new_old.onClick.AddListener(() =>change_mode());
        ok.onClick.AddListener(() => set_name());
        StartCoroutine(look_for_old_room());
        //look_for_old_room()
        for(int i = 0; i < load_prefab.Length; i++)
        {
            if (load_prefab[i].name.Contains("CH"))
            {
                Debug.Log("CH IS in the prefab " + load_prefab[i].name);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void set_name()
    {
        if (mode)
        {
            if (room_name.text != "")
            {
                UserInfo.room_name = room_name.text;
                this.gameObject.SetActive(false);
                
            }
            else
            {
                room_name.placeholder.GetComponentInChildren<Text>().text = "房間名字不可為空";
            }
        }
        else
        {
            UserInfo.room_name = dropdown.captionText.text;
            
            StartCoroutine(LoadItem());
        }
    }

    void change_mode()
    {
        if (mode)
        {
            /*choose old room*/
            dropdown.gameObject.SetActive(true);
            room_name.gameObject.SetActive(false);
            txt.text = "請選擇已有的密室";
            new_old.GetComponentInChildren<Text>().text = "新密室";
        }
        else
        {
            /*choos new room*/
            dropdown.gameObject.SetActive(false);
            room_name.gameObject.SetActive(true);
            txt.text = "請輸入新密室名字";
            room_name.placeholder.GetComponentInChildren<Text>().text = "";
            new_old.GetComponentInChildren<Text>().text = "舊密室";
        }
        mode = !mode;
    }


    private IEnumerator look_for_old_room()
    {
        string url = "http://localhost/unity/formal/co_pushed_room.php";
        WWWForm form = new WWWForm();
        form.AddField("username",UserInfo.Username);
        int type = 0;
        if (SceneManager.GetActiveScene().name == "SmallRoom")
            type = 1;
        else if (SceneManager.GetActiveScene().name == "MiddleRoom")
            type = 2;
        else if (SceneManager.GetActiveScene().name == "BigRoom")
            type = 3;
        print("type = " + type);
        form.AddField("room_type", type);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                print(www.downloadHandler.text);
                string[] room = www.downloadHandler.text.Split('/');

                List<string> options = new List<string> { };
                options.AddRange(room);
                options.RemoveAt(options.Count - 1);
                dropdown.ClearOptions();
                dropdown.AddOptions(options);
            }
        }
    }

    private IEnumerator LoadItem()
    {
        //string url = "http://localhost/unity/project/CocreateLoad.php";
        string url = "http://localhost/unity/formal/co_create_load.php";
        WWWForm form = new WWWForm();
        form.AddField("username", UserInfo.Username);
        //form.AddField("username", "charles");
        form.AddField("room_name", UserInfo.room_name);
        form.AddField("room_type", UserInfo.room_type);
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
                ItemMessage = www.downloadHandler.text.Split(';');
                print("length = " + ItemMessage.Length);
                for (int i = 0; i < ItemMessage.Length; i++)
                {
                    Debug.Log(ItemMessage[i]);
                    createitem(ItemMessage[i]);
                }
                this.gameObject.SetActive(false);
            }
        }
    }
    void createitem(string item)
    {
        string[] ItemInfo;
        ItemInfo = item.Split('|');
        if (ItemInfo.Length < 5)
        {
            return;
        }
        string[] name = ItemInfo[0].Split(":");
        
        //#if UNITY_EDITOR

        //GameObject obj = AssetDatabase.LoadAssetAtPath("Assets/Prefab/Sphere.prefab", typeof(GameObject)) as GameObject;
        if (ItemInfo[0] == "door")
        {
            drag d = GameObject.Find("Drag").GetComponent<drag>();
            d.door_IsSaved = true;
            string[] ANS = ItemInfo[10].Split("/");
            for (int i = 0; i < 8; i++)
            {
                d.door_ans[i] = ANS[i];
                print("doorans="+  d.door_ans[i]);
            }

        }
        else if (ItemInfo[0].Contains("ClipBoard"))
        {
            //GameObject obj = AssetDatabase.LoadAssetAtPath(name[1], typeof(GameObject)) as GameObject;
            GameObject obj = null;
            for (int i = 0; i < load_prefab.Length; i++)
            {
                if (load_prefab[i].name.Contains("ClipBoard"))
                {
                    Debug.Log("new instantiate");
                    obj = Instantiate(load_prefab[i]);
                    break;
                }
            }
            obj = Instantiate(obj);
            obj.name = name[0] + ":" + obj.name;
            obj.tag = "tracked";
            obj.transform.position = new Vector3(float.Parse(ItemInfo[1]), float.Parse(ItemInfo[2]), float.Parse(ItemInfo[3]));
            obj.transform.rotation = Quaternion.Euler(float.Parse(ItemInfo[4]), float.Parse(ItemInfo[5]), float.Parse(ItemInfo[6]));
            obj.transform.localScale = new Vector3(float.Parse(ItemInfo[7]), float.Parse(ItemInfo[8]), float.Parse(ItemInfo[9]));
            obj.GetComponent<tip_text>().txt = ItemInfo[10];
            obj.GetComponent<BoxCollider>().enabled = true;

        }
        
        else if (ItemInfo[0].Contains("CHEST"))
        {
            Debug.Log("chest");
            //GameObject obj = AssetDatabase.LoadAssetAtPath(name[1], typeof(GameObject)) as GameObject;
            GameObject obj = null;
            for(int i = 0; i < load_prefab.Length; i++)
            {
                if (load_prefab[i].name.Contains("CHEST"))
                {
                    Debug.Log(load_prefab[i].name);
                    Debug.Log("new instantiate");
                    obj = Instantiate(load_prefab[i]);
                    break;
                }
            }
            obj.name = name[0] + ":" + obj.name;
            obj.tag = "tracked";
            obj.transform.position = new Vector3(float.Parse(ItemInfo[1]), float.Parse(ItemInfo[2]), float.Parse(ItemInfo[3]));
            obj.transform.rotation = Quaternion.Euler(float.Parse(ItemInfo[4]), float.Parse(ItemInfo[5]), float.Parse(ItemInfo[6]));
            obj.transform.localScale = new Vector3(float.Parse(ItemInfo[7]), float.Parse(ItemInfo[8]), float.Parse(ItemInfo[9]));
            obj.transform.GetChild(2).GetChild(0).GetChild(7).GetComponent<code_manager>().final_ans = int.Parse(ItemInfo[10]);
            
            obj.GetComponent<TreasureCode_Cocreate>().final_ans = int.Parse(ItemInfo[10]);
            obj.transform.GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            //name[1] = name[1].Replace("Assets/",string.Empty);
            //GameObject obj = Resources.Load(name[1], typeof(GameObject)) as GameObject;
            //GameObject obj = AssetDatabase.LoadAssetAtPath(name[1], typeof(GameObject)) as GameObject;
            GameObject obj = null;
            string[] object_name = name[1].Split("/");
            string obj_name = object_name[3].Replace(".prefab", string.Empty);
            for (int i = 0; i < load_prefab.Length; i++)
            {
                //if (name[1].Contains(load_prefab[i].name))
                if (obj_name == load_prefab[i].name) 
                {
                    Debug.Log("else new instantiate");
                    obj = Instantiate(load_prefab[i]);
                    break;
                }
            }
            //obj = Instantiate(obj);
            obj.name = name[0] + ":" + obj.name;
            obj.tag = "tracked";
            //if (obj.name == )
            obj.transform.position = new Vector3(float.Parse(ItemInfo[1]), float.Parse(ItemInfo[2]), float.Parse(ItemInfo[3]));
            obj.transform.rotation = Quaternion.Euler(float.Parse(ItemInfo[4]), float.Parse(ItemInfo[5]), float.Parse(ItemInfo[6]));
            obj.transform.localScale = new Vector3(float.Parse(ItemInfo[7]), float.Parse(ItemInfo[8]), float.Parse(ItemInfo[9]));

        }
//#endif
    }
}
