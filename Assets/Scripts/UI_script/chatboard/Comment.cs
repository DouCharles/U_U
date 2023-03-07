using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text.RegularExpressions;
using System.Threading;

public class Comment : MonoBehaviour
{

    public InputField CommentIN;
    public Button SendButton;
    public Text NoComment;

    public GameObject Content;
    public GameObject CmtBlock;
    public int id_show_c = 0;
    public bool isrequest = false;

    // 取得文章留言資料並生成留言方塊
    IEnumerator GetComment(int id)
    {
        WWWForm form = new WWWForm();
        //POST
        form.AddField("ID", id);

        string strUrl = "http://localhost/ProjectV1/Comment.php";
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
                // Debug.Log(res);
                var rec_data = Regex.Split(res, "</next>");
                int datanum = (rec_data.Length - 1) / 5;
                NoComment.text = "尚無任何留言";
                if (datanum > 0)
                {
                    NoComment.text = "";
                }
                foreach (Transform child in Content.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }

                GameObject[] newCmtBlock = new GameObject[datanum];
                Vector3 BlockPos = new Vector3(0f, -70, 0f);
                GameObject[] Info = new GameObject[5];      //username, date, like, content, id;
                if (datanum > 2)
                {
                    Content.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 130 * datanum + 30);
                    Content.GetComponent<RectTransform>().localPosition = new Vector3(0, -130 * datanum / 2, 0);
                }
                for (int i = 0; i < datanum; i++)
                {
                    newCmtBlock[i] = Instantiate(CmtBlock, BlockPos, Quaternion.identity) as GameObject;
                    newCmtBlock[i].transform.SetParent(Content.transform, false);
                    for (int j = 0; j < 4; j++)
                    {
                        Info[j] = newCmtBlock[i].transform.GetChild(j).gameObject;    //抓到 Prefab CommentBlock[i] 的第j個子物件 Text
                        Info[j].GetComponent<Text>().text = rec_data[i * 5 + j];
                    }
                    newCmtBlock[i].name = rec_data[i * 5 + 4].ToString();
                    BlockPos -= new Vector3(0f, 130f, 0f);
                }
            }
        }
    }

    // 發布留言
    IEnumerator PostComment(int id, string username, string comment)
    {
        WWWForm form = new WWWForm();
        // POST
        form.AddField("ID", id);
        form.AddField("Username", username);
        form.AddField("Comment", comment);

        // 注意: 網址要用http，不能用https否則會出錯
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ProjectV1/CommentPost.php", form))
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
    // Start is called before the first frame update
    void Start()
    {
        // 留言送出
        SendButton.onClick.AddListener(() =>
        {
            StartCoroutine(PostComment(id_show_c, UserInfo.Username, CommentIN.text));
            Thread.Sleep(50);
            CommentIN.text = "";
            StartCoroutine(GetComment(id_show_c));
        });
    }

    // Update is called once per frame
    void Update()
    {
        // 資料更動時要重新生成留言方塊
        if (isrequest)
        {
            StartCoroutine(GetComment(id_show_c));
            isrequest = false;
        }
    }
}
