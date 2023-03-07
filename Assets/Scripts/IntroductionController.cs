using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntroductionController : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private Image LabelImage;
    [SerializeField] private Text LabelName;
    [SerializeField] private Text LabelText;
    [SerializeField] private Button LeftButton;
    [SerializeField] private Button RightButton;
    [SerializeField] private Button CloseButton;
    [SerializeField] private Sprite[] LabelImageIndex;
    int Index = 0;
    string[] LabelNameIndex = {"世界觀", "密室逃脫", "討論板", "MBTI性向測驗", "雷達圖", "證書申請"};
    string[] LabelTextIndex = {"致力於提供一個包含全台各所大學的遊戲世界", "為不同科系量身打造的密室逃脫遊戲，解謎的同時也能體驗到該科系相關知識。", "提供一個供玩家們分享以及討論的地方。", "根據心理分析家榮格理論為基礎所做出的 MBTI測驗，將人分類成 16 種不同的性格型態，而透過測驗能夠分析出適合的領域特徵。", "體驗遊戲過後提供數據分析，將各項遊玩時的數據轉換成推薦科系的雷達圖。", "在體驗完科系之後，玩家們能夠向服務端提出申請，經過審核之後玩家會得到專屬的區塊鏈證書，而在未來也能夠對申請大學有一定的幫助。"};
    // Start is called before the first frame update
    void Start()
    {
        LabelImage.GetComponent<Image>().sprite = LabelImageIndex[0];
        LabelName.GetComponent<Text>().text = LabelNameIndex[0];
        LabelText.GetComponent<Text>().text = LabelTextIndex[0];
        LeftButton.onClick.AddListener(() => ChangeAppearance(-1));
        RightButton.onClick.AddListener(() => ChangeAppearance(1));
        CloseButton.onClick.AddListener(CloseUI);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ChangeAppearance(int num)
    {
        if (num == -1)
        {
            Index --;
            if(Index == -1)
            {
                Index = 5;
            }
        }
        else if (num == 1)
        {
            Index++;
            if(Index == 6)
            {
                Index = 0;
            }
        }
        LabelImage.GetComponent<Image>().sprite = LabelImageIndex[Index];
        LabelName.GetComponent<Text>().text = LabelNameIndex[Index];
        LabelText.GetComponent<Text>().text = LabelTextIndex[Index];
    }
    void CloseUI()
    {
        UI.SetActive(false);
    }
}
