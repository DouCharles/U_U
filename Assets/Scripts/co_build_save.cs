using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class co_build_save : MonoBehaviour
{
    // Start is called before the first frame update
   
    GameObject[] new_obj,old_obj;
    GameObject door;
    public string username = "charles";
    public string roomname = "escape1";
    public string ObjLocation = "Assets/Prefab/burger prefab.prefab";
    private int prefix = 0;

    //(Clone)


    private void Awake()
    {
        Debug.Log("awake");

    }
    void Start()
    {
        //Debug.Log("start");
       
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => save());
        door = GameObject.Find("Door");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void save()
    {
        new_obj = GameObject.FindGameObjectsWithTag("drag");
        old_obj = GameObject.FindGameObjectsWithTag("tracked");
        //prefix = old_obj.Length;
        for (int j = 0; j < old_obj.Length; j++)
        {
            string[] name = old_obj[j].name.Replace("(Clone)", string.Empty).Split(":");
            ObjLocation = name[0] + ":Assets/Prefab/co_create/" + name[1]+ ".prefab";
            string ans = "";
            if (old_obj[j].name.Contains("CHEST"))
            {
                ans = old_obj[j].GetComponent<TreasureCode_Cocreate>().final_ans.ToString();
            }
            else if (old_obj[j].name.Contains("ClipBoard"))
            {
                ans = old_obj[j].GetComponent<tip_text>().txt;
            }
            StartCoroutine(savephp(old_obj[j], "update", ans));
            prefix = int.Parse(name[0]);
        }
        
        for (int i = 0; i < new_obj.Length; i++)
        {
            
            if (new_obj[i].name == "burger")
                continue;
            prefix++;
            ObjLocation = prefix + ":Assets/Prefab/co_create/" + new_obj[i].name.Replace("(Clone)", string.Empty)+".prefab" ;
            string ans = "";
            if (new_obj[i].name.Contains("CHEST"))
            {
                ans = new_obj[i].GetComponent<TreasureCode_Cocreate>().final_ans.ToString();
            }
            else if (new_obj[i].name.Contains("ClipBoard"))
            {
                ans = new_obj[i].GetComponent<tip_text>().txt;
            }
            StartCoroutine(savephp(new_obj[i],"insert",ans));
            new_obj[i].tag = "tracked";
            
            new_obj[i].name = ObjLocation;
        }
        ObjLocation = "door";
        string door_ans = "";
        drag d = GameObject.Find("Drag").GetComponent<drag>();
        for(int i = 0; i < 8; i++)
        {
            print("22222 = "+ d.door_ans[i]);
            door_ans += d.door_ans[i];
            if(i!=7)
                door_ans += "/";
            print(door_ans);
        }
        if (!d.door_IsSaved)
        {
            d.door_IsSaved = true;
            StartCoroutine(savephp(door, "insert", door_ans));
        }
        else
        {
            StartCoroutine(savephp(door, "update", door_ans));
        }


    }

    IEnumerator savephp(GameObject obj,string up_in,string ans)
    {
        string url = "http://localhost/unity/formal/co_create_save.php";
        WWWForm form = new WWWForm();
        form.AddField("update_insert", up_in);
        /*form.AddField("username", username);
        form.AddField("room_name", roomname);*/
        form.AddField("username", UserInfo.Username);
        form.AddField("room_name", UserInfo.room_name);
        form.AddField("room_type", 1);
        form.AddField("item", ObjLocation);
        form.AddField("pos_x", obj.transform.position.x.ToString());
        form.AddField("pos_y", obj.transform.position.y.ToString());
        form.AddField("pos_z", obj.transform.position.z.ToString());
        form.AddField("rot_x", obj.transform.rotation.eulerAngles.x.ToString());
        form.AddField("rot_y", obj.transform.rotation.eulerAngles.y.ToString());
        form.AddField("rot_z", obj.transform.rotation.eulerAngles.z.ToString());
        form.AddField("scale_x", obj.transform.localScale.x.ToString());
        form.AddField("scale_y", obj.transform.localScale.y.ToString());
        form.AddField("scale_z", obj.transform.localScale.z.ToString());
        form.AddField("ans",ans);
        if(ObjLocation == "door")
        {
            print("indoor");
            print("dor_ans = " + ans + up_in);
        }


        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    IEnumerable loaditems()
    {
        string url = "http://127.0.0.1:8012/unity/formal/co_create_load.php";
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("room_name", roomname);
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Debug.Log(www.downloadHandler.text);

            }
        }

    }

    
}
