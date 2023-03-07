using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading;

public class CommentLike : MonoBehaviour
{
    GameObject Show;

    public Button LikeButton;

    // 檢查留言是否已被此user按讚過
    IEnumerator IsLiked(string username, int id)
    {
        WWWForm form = new WWWForm();

        //POST
        form.AddField("Username", username);
        form.AddField("Comment_ID", id);

        string strUrl = "http://localhost/ProjectV1/CommentLike.php";

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

    // 留言按讚
    IEnumerator PushLike(string username, int id, int postid, int type)      //type: 1代表讚數+1; -1代表讚數-1
    {
        WWWForm form = new WWWForm();

        //POST
        form.AddField("Username", username);
        form.AddField("Comment_ID", id);
        form.AddField("Post_ID", postid);
        form.AddField("Type", type);

        string strUrl = "http://localhost/ProjectV1/CommentPushLike.php";

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
        StartCoroutine(IsLiked(UserInfo.Username, int.Parse(this.name)));
        Show = GameObject.Find("PostShow");
        LikeButton.onClick.AddListener(() =>
        {
            
            if (LikeButton.GetComponent<Image>().color == Color.white)
            {
                StartCoroutine(PushLike(UserInfo.Username, int.Parse(this.name), Show.GetComponent<ShowPost>().id_show, 1));
                Thread.Sleep(50);   // 要等php部分先做完，不然可能會抓到還沒更新的資料
                LikeButton.GetComponent<Image>().color = Color.blue;
                StartCoroutine(IsLiked(UserInfo.Username, int.Parse(this.name)));
                Show.GetComponent<Comment>().isrequest = true;
            }
            else if (LikeButton.GetComponent<Image>().color == Color.blue)
            {
                StartCoroutine(PushLike(UserInfo.Username, int.Parse(this.name), Show.GetComponent<ShowPost>().id_show, - 1));
                Thread.Sleep(50);   // 要等php部分先做完，不然可能會抓到還沒更新的資料
                LikeButton.GetComponent<Image>().color = Color.white;
                StartCoroutine(IsLiked(UserInfo.Username, int.Parse(this.name)));
                Show.GetComponent<Comment>().isrequest = true;
            }
        });
    }
}
