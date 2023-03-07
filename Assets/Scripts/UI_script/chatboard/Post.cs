using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading;

public class Post : MonoBehaviour
{

    public GameObject ForumLobby;
    public GameObject PostShow;
    public GameObject ForumPost;

    public Button BackButton;

    public Dropdown School;
    public Dropdown Department;
    public InputField Title;
    public InputField Article;

    public Button PostButton;

    public int regen = 0;


    // 發布文章
    public IEnumerator Posting(string school, string department, string title, string content)
    {
        WWWForm form = new WWWForm();
        // POST
        form.AddField("Username", UserInfo.Username);
        form.AddField("School", school);
        form.AddField("Department", department);
        form.AddField("Title", title);
        form.AddField("Content", content);

        // 注意: 網址要用http，不能用https否則會出錯
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ProjectV1/ForumPost.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                Debug.Log("發布成功");
            }
        }
    }

    // 發布文章
    public void PostArticle()
    {
        string school_val = School.options[School.value].text;
        string department_val = Department.options[Department.value].text;
        StartCoroutine(Posting(school_val, department_val, Title.text, Article.text));
    } 

    // Start is called before the first frame update
    void Start()
    {
        // 按下返回Button，轉到發文介面
        BackButton.onClick.AddListener(() =>
        {
            ForumPost.SetActive(false);
            ForumLobby.SetActive(true);
});

        PostButton.onClick.AddListener(() =>
        {
            PostArticle();
            Title.text = "";
            Article.text = "";
            regen = 1;
            ForumLobby.SetActive(true);
            Thread.Sleep(100);
            ForumPost.SetActive(false);
        });
    }
}
