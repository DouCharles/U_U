using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class info_manager : MonoBehaviour
{
    // Start is called before the first frame update
    static public int error_times = 0;
    //public float time = 0;
    static public int level;
    static public bool failed = true;
    static public int tips = 0;
    static public string username = "charles", school = "國立成功大學", department = "資訊工程";
    private int timer_i = 0;
    bool start_Timer = true;
    string date = "";

    private void Reset()
    {
        /*error_times = 0;
        failed = false;
        tips = 0;
        timer_i = 0;
        start_Timer = true;*/
    }
    private void Awake()
    {
        timer_i = 0;
        error_times = 0;
        failed = false;
        tips = 0;
        
        start_Timer = true;
        date = "";
    }
    void Start()
    {
     /*   Debug.Log(DateTime.Now.Year);
        Debug.Log(DateTime.Now.Month);
        Debug.Log(DateTime.Now.Day);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (start_Timer)
        {
          //  StartCoroutine("timer");
            start_Timer = false;
        }
        if (failed)
        {
            //Debug.Log("faileddddddd");
        }
        if(error_times > 2)
        {
            //Debug.Log("error timessss" + error_times);
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(1);
        
        timer_i++;
        start_Timer = true;
        //Debug.Log(timer_i);
    }

    private void OnDestroy()
    {
        // TODO: add connect to the database
        string url = "http://127.0.0.1:8012/unity/formal/info.php";
        //StartCoroutine(save_info(url));
    }

    IEnumerator save_info(string URL)
    {
        WWWForm form = new WWWForm();
        //form.AddField("", variable);
        form.AddField("username", username);
        form.AddField("school", school);
        form.AddField("department", department);
        form.AddField("level", level);
        form.AddField("play_date", date);
        form.AddField("play_time", timer_i);
        form.AddField("tips", tips);
        form.AddField("error_times", error_times);
        form.AddField("IsFailed", failed.ToString());
        // WWW info = new WWW(URL, form);
        //yield return info;
        using (UnityWebRequest www = UnityWebRequest.Post(URL, form)) {
            yield return www.SendWebRequest();

            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
