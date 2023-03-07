using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class co_createpublish : MonoBehaviour
{

    [SerializeField] Button OK_btn, NO_btn, publish_btn;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        publish_btn.onClick.AddListener(() => check_publish());
        OK_btn.onClick.AddListener(() => publish());
        NO_btn.onClick.AddListener(() => NO_publish());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void check_publish()
    {
        gameObject.SetActive(true);

    }

    void publish()
    {
        
        StartCoroutine(push());
    }

    void NO_publish()
    {
        gameObject.SetActive(false);
    }

    IEnumerator push()
    {
        string url = "http://localhost/unity/formal/push_room.php";
        WWWForm form = new WWWForm();
        form.AddField("username", UserInfo.Username);
        form.AddField("room_name", UserInfo.room_name);
        form.AddField("room_type", UserInfo.room_type);
        /*form.AddField("username", "charles");
        form.AddField("room_name", "escape1");
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
                Debug.Log(www.downloadHandler.text);
                gameObject.SetActive(false);
            }
        }

    }
}
