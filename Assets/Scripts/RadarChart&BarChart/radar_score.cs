using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class radar_score : MonoBehaviour
{
    // Start is called before the first frame update
    
    float i = 0;
    [SerializeField] private GameObject radarchart;
    RadarChart radar;
    

    void Awake()
    {
        /*for(int i = 0; i < UserInfo.score_0.Length; i++)
        {
            UserInfo.score_0[i] = 0;
        }
        for (int i = 0; i < UserInfo.score_1.Length; i++)
        {
            UserInfo.score_1[i] = 0;
        }
        for (int i = 0; i < UserInfo.score_2.Length; i++)
        {
            UserInfo.score_2[i] = 0;
        }
        for (int i = 0; i < UserInfo.score_3.Length; i++)
        {
            UserInfo.score_3[i] = 0;
        }
        for (int i = 0; i < UserInfo.score_4.Length; i++)
        {
            UserInfo.score_4[i] = 0;
        }
        for (int i = 0; i < UserInfo.score_5.Length; i++)
        {
            UserInfo.score_5[i] = 0;
        }
        for (int i = 0; i < UserInfo.score_6.Length; i++)
        {
            UserInfo.score_6[i] = 0;
        }*/
        //radar = GetComponentInChildren<RadarChart>();
        UserInfo.score_2[1] = 0;
        radar = radarchart.GetComponent<RadarChart>();
        print(this.gameObject.name);

        zero(UserInfo.pr_0);
        zero(UserInfo.pr_1);
        zero(UserInfo.pr_2);
        zero(UserInfo.pr_3);
        zero(UserInfo.pr_4);
        zero(UserInfo.pr_5);
        zero(UserInfo.pr_6);
    }

    private void Start()
    {
        //radar = GetComponentInChildren<RadarChart>();
        //StartCoroutine(get_pr());
    }

    // Update is called once per frame
    void Update()
    {
        //print(radar.m_statusValues[0]);
        /*if (radar)
        {*/
        radar.m_statusValues[0] = sum(UserInfo.score_0) / UserInfo.score_0.Length / 100;
        radar.m_statusValues[1] = sum(UserInfo.score_1) / UserInfo.score_1.Length / 100;
        radar.m_statusValues[2] = sum(UserInfo.score_2) / UserInfo.score_2.Length / 100;
        radar.m_statusValues[3] = sum(UserInfo.score_3) / UserInfo.score_3.Length / 100;
        radar.m_statusValues[4] = sum(UserInfo.score_4) / UserInfo.score_4.Length / 100;
        radar.m_statusValues[5] = sum(UserInfo.score_5) / UserInfo.score_5.Length / 100;
        radar.m_statusValues[6] = sum(UserInfo.score_6) / UserInfo.score_6.Length / 100;
        /*}
        else
        {
            print("NULL");
        }*/
    }


    private float sum(float[] target) 
    {
        float ans = 0;
        for(int i = 0; i < target.Length;i++)
        {
            ans += target[i];
        }
        return ans;
    }
    private IEnumerator get_pr()
    {
        string url = "http://localhost/unity/formal/gameinfo_pr.php";
        WWWForm form = new WWWForm();
        /*form.AddField("username", "test"); 
        form.AddField("department", "資訊工程");
        form.AddField("school", "國立成功大學");*/
        form.AddField("username", UserInfo.Username); 
        form.AddField("department", "資訊工程學系");
        form.AddField("school", "國立成功大學");
        //form.AddField("level", 1);

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
                string[] texts = www.downloadHandler.text.Split("\n");
                // time error tips failedtimes
                print(texts.Length);
                for (int i = 0; i < texts.Length; i++)
                {

                    string[] rank = texts[i].Split("/");
                    if (rank.Length == 5 || rank.Length == 3)
                    {
                        if (rank[1] == "countfailed")
                        {
                            print("inprif");


                            UserInfo.score_2[1] += score_compute(int.Parse(rank[0]), "failed_times", float.Parse(rank[2]));
                            UserInfo.pr_2[1, 0] = float.Parse(rank[2]);
                        }
                        else
                        {
                            print("inpr");
                            UserInfo.score_2[1] += score_compute(int.Parse(rank[0]), "tips", float.Parse(rank[2]));
                            UserInfo.pr_2[1, 1] = float.Parse(rank[2]);
                            UserInfo.score_2[1] += score_compute(int.Parse(rank[0]), "error_times", float.Parse(rank[3]));
                            UserInfo.pr_2[1, 2] = float.Parse(rank[3]);
                            UserInfo.score_2[1] += score_compute(int.Parse(rank[0]), "play_time", float.Parse(rank[4]));
                            UserInfo.pr_2[1, 3] = float.Parse(rank[4]);
                            //print(i+"score = " + score_2[1]);
                        }
                    }
                }
                print(UserInfo.score_2[1]);
                
            }
        }
    }
    private float score_compute(int level, string scoring_standard, float pr)
    {
        int full_score = 100;
        int item_score = full_score / 4;
        int interval = item_score / 5;
        float final_score = 0;
        /*if (scoring_standard == "failed_times")
        {
            for (int i = 0; i < 5; i++)
            {
                if (pr == i)
                {
                    final_score = item_score;
                    //print("failed times :" + i + "//" + final_score);
                    break;
                }
                item_score -= interval;
            }
        }
        else
        {*/


            for (int i = 1; i < 6; i++)
            {
                if (pr < i * 0.2)
                {
                    final_score = item_score;
                    print("final score = " + final_score);
                    break;
                }
                item_score -= interval;
            }
        //}
        return final_score;

    }


    void zero(float[,] target)
    {
        for(int i = 0; i < target.GetLength(0); i++)
        {
            for (int j = 0; j < target.GetLength(1); j++)
            {
                target[i, j] = 0;
            }
        }
    }
}
