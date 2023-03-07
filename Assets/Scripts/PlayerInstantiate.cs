using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerInstantiate : MonoBehaviour
{
    public string Player_No;
    public float position_x;
    public float position_y;
    public float position_z;
    public float scale_x;
    public float scale_y;
    public float scale_z;

    public GameObject Player_1;
    public GameObject Player_2;
    public GameObject Player_3;

    public IEnumerator GetAppearance(string username)
    {
        WWWForm form = new WWWForm();
        // POST
        form.AddField("Username", username);

        // 注意: 網址要用http，不能用https否則會出錯
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ProjectV1/Appearance.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("87" + www.downloadHandler.text);
                if(www.downloadHandler.text == "1")
                {
                    GameObject Role = Instantiate(Player_1, new Vector3(position_x, position_y, position_z), new Quaternion(0, 0, 0, 0));
                    Role.transform.localScale = new Vector3(scale_x, scale_y, scale_z);
                }
                else if(www.downloadHandler.text == "2")
                {
                    GameObject Role = Instantiate(Player_2, new Vector3(position_x, position_y, position_z), new Quaternion(0, 0, 0, 0));
                    Role.transform.localScale = new Vector3(scale_x, scale_y, scale_z);
                }
                else if(www.downloadHandler.text == "3")
                {
                    GameObject Role = Instantiate(Player_3, new Vector3(position_x, position_y, position_z), new Quaternion(0, 0, 0, 0));
                    Role.transform.localScale = new Vector3(scale_x, scale_y, scale_z);
                }
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetAppearance(UserInfo.Username));
        /*
        if (Player_No == "1")
        {
            print("111");
            GameObject Role = Instantiate(Player_1, new Vector3(position_x, position_y, position_z), new Quaternion(0,0,0,0));
            Role.transform.localScale = new Vector3(scale_x, scale_y, scale_z);
        }
        else if (Player_No == "2")
        {
            print("222");
            GameObject Role = Instantiate(Player_2, new Vector3(position_x, position_y, position_z), new Quaternion(0,0,0,0));
            Role.transform.localScale = new Vector3(scale_x, scale_y, scale_z);
        }
        else if (Player_No == "3")
        {
            print("333");
            GameObject Role = Instantiate(Player_3, new Vector3(position_x, position_y, position_z), new Quaternion(0,0,0,0));
            Role.transform.localScale = new Vector3(scale_x, scale_y, scale_z);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
