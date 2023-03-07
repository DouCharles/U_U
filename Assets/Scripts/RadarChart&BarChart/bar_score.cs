using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class bar_score : MonoBehaviour
{
    BarChart bar;
    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponentInChildren<BarChart>();
        if (name == "BarChartClass1UI")
        {
            value(UserInfo.score_0);
            //bar.m_statusValues[1] = UserInfo.score_[1] / 100;
        }
        else if (name == "BarChartClass2UI")
        { 
            value(UserInfo.score_1);
        }
        else if (name == "BarChartClass3UI")
        {
            value(UserInfo.score_2);
        }
        else if (name == "BarChartClass4UI")
        {
            value(UserInfo.score_3);
        }
        else if (name == "BarChartClass5UI")
        {
            value(UserInfo.score_4);
        }
        else if (name == "BarChartClass6UI")
        {
            value(UserInfo.score_5);
        }
        else if (name == "BarChartClass7UI")
        {
            value(UserInfo.score_6);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void value(float[] target)
    {
        for(int i = 0; i < bar.m_statusValues.Length; i++)
        {
            bar.m_statusValues[i] = target[i] / 100;
        }
    }
    
}
