using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class radar_analysis_txt : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button next_btn, previous_btn;
    [SerializeField] private Text txt;
    private int mode = 0;
    private string[] analysis_txt = { 
        "您最適合的科系:\n1.資訊工程 分數: 85 \n2.機械工程 分數 :73\n3.電機工程系 分數:70",
        "此雷達圖之分析方式會將您於基本密室逃脫的遊玩時間、使用tips次數、答錯次數、該關卡失敗次數記錄下來，並依照全體玩家做排名後計算分數",
        "該科系level 共n關\n各關分數 : \nlevel_score   = [100/(1+2+..+n)]*level\n\n每關各項目得分 : \n[(100 - 百分名次)/100 ] * (level_score / 4) \n將每關各項目得分加總即為最終分數"};
    void Start()
    {
        mode = 0;
        txt.text = analysis_txt[mode];
        next_btn.onClick.AddListener(() => change_txt("next"));
        previous_btn.onClick.AddListener(() => change_txt("previous"));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void change_txt(string instruction)
    {
        if (instruction == "next")
        {
            if (mode < 3)
                mode++;
        }
        else
        {
            if (mode > 0)
                mode--;
        }

        txt.text = analysis_txt[mode];
    }
}
