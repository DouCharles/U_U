using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text.RegularExpressions;
using System.Threading;


public class ShowPost : MonoBehaviour
{
    public GameObject PostShow;
    public GameObject Lobby;
    public GameObject CommentCont;

    public Text Title;
    public Text PostUser;
    public Text School_Dept;
    public Text Date;
    public Text Content;
    public Text Like;

    public Button LikeButton;
    public Button BackButton;
    public int id_show = 1;
    public bool isrequest = false;
    public int regen = 0;

    // 取得文章資料
    IEnumerator GetPost(int id)
    {
        WWWForm form = new WWWForm();

        //POST
        form.AddField("Post_ID", id);        

        string strUrl = "http://localhost/ProjectV1/ShowPost.php";
        
        using (UnityWebRequest www = UnityWebRequest.Post(strUrl, form))
        {
            yield return www.SendWebRequest();

            // 發生錯誤
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string res = www.downloadHandler.text;
                Debug.Log(res);
                
                var rec_data = Regex.Split(res, "</next>");
                Title.text = rec_data[0];
                PostUser.text = rec_data[1];
                School_Dept.text = rec_data[2];
                Date.text = rec_data[3];
                Content.text = rec_data[4];
                Like.text = rec_data[5];
            }
        }
    }

    // 檢查此文章是否被此user按讚過
    IEnumerator IsLiked(string username, int id)
    {
        WWWForm form = new WWWForm();

        //POST
        form.AddField("Username", username);
        form.AddField("Post_ID", id);

        string strUrl = "http://localhost/ProjectV1/Like.php";

        using (UnityWebRequest www = UnityWebRequest.Post(strUrl, form))
        {
            yield return www.SendWebRequest();

            // 發生錯誤
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.downloadHandler.text == "0")
                {
                    print(www.downloadHandler.text);
                    LikeButton.GetComponent<Image>().color = Color.white;
                }
                else
                {
                    print(www.downloadHandler.text);
                    LikeButton.GetComponent<Image>().color = Color.blue;
                }
            }
        }
    }

    // 按讚功能
    IEnumerator PushLike(string username, int id, int type)      //type: 1代表讚數+1; -1代表讚數-1
    {
        WWWForm form = new WWWForm();

        //POST
        form.AddField("Username", username);
        form.AddField("Post_ID", id);
        form.AddField("Type", type);

        string strUrl = "http://localhost/ProjectV1/PushLike.php";

        using (UnityWebRequest www = UnityWebRequest.Post(strUrl, form))
        {
            yield return www.SendWebRequest();

            // 發生錯誤
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

    
    // Start is called before the first frame update
    void Start()
    {
        // 按讚OR收回讚
        LikeButton.onClick.AddListener(() =>
        {
            if(LikeButton.GetComponent<Image>().color == Color.white)
            {
                StartCoroutine(PushLike(UserInfo.Username, id_show, 1));
                Thread.Sleep(50);   // 要等php部分先做完，不然可能會抓到還沒更新的資料
                LikeButton.GetComponent<Image>().color = Color.blue;
                StartCoroutine(GetPost(id_show));
            }
            else if(LikeButton.GetComponent<Image>().color == Color.blue)
            {
                StartCoroutine(PushLike(UserInfo.Username, id_show, -1));
                Thread.Sleep(50);   // 要等php部分先做完，不然可能會抓到還沒更新的資料
                LikeButton.GetComponent<Image>().color = Color.white;
                StartCoroutine(GetPost(id_show));
            }           
        });

        // 回到討論版大廳
        BackButton.onClick.AddListener(() =>
        {
            foreach (Transform child in CommentCont.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            PostShow.SetActive(false);
            Lobby.SetActive(true);
            regen = 1;
        });
    }

    // Update is called once per frame
    void Update()
    {
        // 重新載入文章
        if (isrequest)
        {
            StartCoroutine(GetPost(id_show));
            StartCoroutine(IsLiked(UserInfo.Username, id_show));
            isrequest = false;
        }
    }
}
