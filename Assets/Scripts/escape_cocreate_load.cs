using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
//#if UNITY_EDITOR
using UnityEditor;
//#endif
using TMPro;

public class escape_cocreate_load: MonoBehaviour
{
    
    private string[] ItemMessage;
    [SerializeField] GameObject door_code;
    [SerializeField] GameObject[] load_prefab;
    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Load()
    {
        StartCoroutine(LoadItem());
    }
    private IEnumerator LoadItem()
    {
        //string url = "http://localhost/unity/project/CocreateLoad.php";
        string url = "http://localhost/unity/formal/co_create_load.php";
        WWWForm form = new WWWForm();
        /*form.AddField("username", "charles");
        form.AddField("room_name", "escape1");
        UserInfo.room_name = "escape1";*/
        form.AddField("username", "NULL");
        form.AddField("room_name", UserInfo.room_name);
        form.AddField("room_type", UserInfo.room_type);
        /*form.AddField("room_name", "escape1");
        form.AddField("room_type", "1");*/


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
                    print(ItemMessage[i]);
                    createitem(ItemMessage[i]);

                }

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
            /*setting ans*/
            door_code.GetComponentInChildren<door_code>().final_ans = "";
            string[] ans = ItemInfo[10].Split('/'); //ans
            for(int i = 0; i < ans.Length; i++)
            {
                if (i < 4)
                {
                    door_code.GetComponentInChildren<door_code>().final_ans += ans[i];
                }
                else
                {
                    door_code.GetComponentInChildren<door_code>().tips_txt[i - 4] = ans[i];
                }
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
           // obj = Instantiate(obj);
            obj.name = name[0] + ":" + obj.name;
            obj.transform.position = new Vector3(float.Parse(ItemInfo[1]), float.Parse(ItemInfo[2]), float.Parse(ItemInfo[3]));
            obj.transform.rotation = Quaternion.Euler(float.Parse(ItemInfo[4]), float.Parse(ItemInfo[5]), float.Parse(ItemInfo[6]));
            obj.transform.localScale = new Vector3(float.Parse(ItemInfo[7]), float.Parse(ItemInfo[8]), float.Parse(ItemInfo[9]));
            obj.GetComponentInChildren<tip_text>().txt = ItemInfo[10];
            obj.GetComponent<BoxCollider>().enabled = true;
           
        }
        else if (ItemInfo[0].Contains("CHEST"))
        {
            //GameObject obj = AssetDatabase.LoadAssetAtPath(name[1], typeof(GameObject)) as GameObject;
            GameObject obj = null;
            for (int i = 0; i < load_prefab.Length; i++)
            {
                if (load_prefab[i].name.Contains("CHEST"))
                {
                    Debug.Log(load_prefab[i].name);
                    Debug.Log("new instantiate");
                    obj = Instantiate(load_prefab[i]);
                    break;
                }
            }
           // obj = Instantiate(obj);
            obj.name = name[0] + ":" + obj.name;
            obj.transform.position = new Vector3(float.Parse(ItemInfo[1]), float.Parse(ItemInfo[2]), float.Parse(ItemInfo[3]));
            obj.transform.rotation = Quaternion.Euler(float.Parse(ItemInfo[4]), float.Parse(ItemInfo[5]), float.Parse(ItemInfo[6]));
            obj.transform.localScale = new Vector3(float.Parse(ItemInfo[7]), float.Parse(ItemInfo[8]), float.Parse(ItemInfo[9]));
            obj.transform.GetChild(2).GetChild(0).GetChild(7).GetComponent<code_manager>().final_ans= int.Parse(ItemInfo[10]);
            //obj.GetComponent<BoxCollider>().remove
            obj.GetComponent<TreasureCode_Cocreate>().enabled = false;

        }

        else
        {
            print("name[1] = " + name[1]);
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
            obj.transform.position = new Vector3(float.Parse(ItemInfo[1]), float.Parse(ItemInfo[2]), float.Parse(ItemInfo[3]));
            obj.transform.rotation = Quaternion.Euler(float.Parse(ItemInfo[4]), float.Parse(ItemInfo[5]), float.Parse(ItemInfo[6]));
            obj.transform.localScale = new Vector3(float.Parse(ItemInfo[7]), float.Parse(ItemInfo[8]), float.Parse(ItemInfo[9]));
            //if (obj.name == )
            
        }
//#endif
    }
}
