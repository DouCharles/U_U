using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class co_build_load : MonoBehaviour
{
    
    private string[] ItemMessage;
    [SerializeField] GameObject setting_room_name;
    // Start is called before the first frame update
    void Start()
    {
        setting_room_name.SetActive(true);
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
        form.AddField("username", UserInfo.Username); 
         form.AddField("room_name", UserInfo.room_name);


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
                if (ItemMessage.Length == 1)
                {
                    print("123");
                    setting_room_name.SetActive(true);
                }
                else
                {
                    print("length = " + ItemMessage.Length);
                    for (int i = 0; i < ItemMessage.Length; i++)
                    {
                        print(ItemMessage[i]);
                        createitem(ItemMessage[i]);
                    }
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
        
#if UNITY_EDITOR
        
        //GameObject obj = AssetDatabase.LoadAssetAtPath("Assets/Prefab/Sphere.prefab", typeof(GameObject)) as GameObject;
        if (ItemInfo[0] == "door") 
        {
            drag d = GameObject.Find("Drag").GetComponent<drag>();
            d.door_IsSaved = true;
            string[] ANS = ItemInfo[7].Split("/");
            for(int i = 0; i < 8; i++)
            {
                d.door_ans[i] = ANS[i];
            }
        }
        else
        {
            GameObject obj = AssetDatabase.LoadAssetAtPath(name[1], typeof(GameObject)) as GameObject;
            obj = Instantiate(obj);
            obj.name = name[0] + ":" + obj.name;
            obj.tag = "tracked";
            //if (obj.name == )
            obj.transform.position = new Vector3(float.Parse(ItemInfo[1]), float.Parse(ItemInfo[2]), float.Parse(ItemInfo[3]));
            obj.transform.rotation = Quaternion.Euler(float.Parse(ItemInfo[4]), float.Parse(ItemInfo[5]), float.Parse(ItemInfo[6]));
            

        }
#endif
    }
}
