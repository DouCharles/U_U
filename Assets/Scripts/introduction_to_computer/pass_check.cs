using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;

public class pass_check : MonoBehaviour
{

    static public int error_times = 20;
    //public float time = 0;
    static public int level = 21;
    static public bool failed = false;
    static public int tips = 22;
    static public string username = "charle", school = "國立成功大學", department = "資訊工程";
    private int timer_i = 0;
    bool start_Timer = true;
    string date = "2022/04/30";
    // Start is called before the first frame update
    private int scene_num = 4;
    void Start()
    {
        //username = UserInfo.Username;
        //string url = "http://127.0.0.1:8012/unity/formal/info.php";
        string url = "http://localhost/unity/formal/info.php";
        date = DateTime.Now.Date.ToString();
        //StartCoroutine(save_info(url));
        UserInfo.tips = 0;
        UserInfo.error_times = 0;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (start_Timer)
        {
            StartCoroutine("timer");
            start_Timer = false;
        }
        if(UserInfo.error_times > 15 || timer_i >900)
        {
            failed = true;
            string url = "http://localhost/unity/formal/info.php";
            StartCoroutine(save_info(url));
            SceneManager.LoadScene(scene_num);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            //Debug.Log("finish the room");

            
            //string url = "http://127.0.0.1:8012/unity/formal/info.php";
            string url = "http://localhost/unity/formal/info.php";
            StartCoroutine(save_info(url));
            
        }
        else
        {
            //Debug.Log(other.name);
        }
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(1);

        timer_i++;
        start_Timer = true;
        //Debug.Log(timer_i);
    }
    IEnumerator save_info(string URL)
    {
        date = DateTime.Now.Date.ToString();
        int hour = timer_i / 3600;
        int min = timer_i/ 60;
        int sec = timer_i % 60;
        string time = hour.ToString() + ":" + min.ToString() + ":" + sec.ToString();
        Debug.Log(timer_i);
        WWWForm form = new WWWForm();
        //form.AddField("", variable);
        /*form.AddField("username", username);
        form.AddField("school", school);
        form.AddField("department", department);*/
        print(UserInfo.Username + "?" + UserInfo.school + "?" + UserInfo.department);
        form.AddField("username", UserInfo.Username);
        form.AddField("school", UserInfo.school);
        form.AddField("department", UserInfo.department);
        form.AddField("level", UserInfo.level);
        //form.AddField("level", level.ToString());
        form.AddField("play_date", date);
        form.AddField("play_time", time);
        form.AddField("tips", UserInfo.tips);
        //form.AddField("tips", tips.ToString());
        //form.AddField("error_times", error_times.ToString());
        form.AddField("error_times", UserInfo.error_times);
        form.AddField("IsFailed", failed.ToString());
        //WWW info = new WWW(URL, form);
        //yield return info;
        //Debug.Log("info finish");
        //info.Dispose();
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                SceneManager.LoadScene(scene_num);
            }
        }
    }

}
