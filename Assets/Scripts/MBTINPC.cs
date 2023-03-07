using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text.RegularExpressions;

public class MBTINPC : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Dialog_Box;
    public GameObject Dialog_Box_1;
    public GameObject MBTI_Questionnaire;
    public GameObject MBTI_Result;
    public GameObject MBTI_Analysis;
    [SerializeField] public Button YesButton;
    [SerializeField] public Button NoButton;
    [SerializeField] public Button CheckButton;
    [SerializeField] public GameObject OptionA;
    [SerializeField] public GameObject OptionB;
    [SerializeField] public GameObject QuestionNoText;
    [SerializeField] public Button PreviousButton;
    [SerializeField] public Button NextButton;
    [SerializeField] public Button FinishButton;
    [SerializeField] public Button OptionAZeroButton;
    [SerializeField] public Button OptionAOneButton;
    [SerializeField] public Button OptionATwoButton;
    [SerializeField] public Button OptionAThreeButton;
    [SerializeField] public Button OptionAFourButton;
    [SerializeField] public Button OptionAFiveButton;
    [SerializeField] public Button OptionBZeroButton;
    [SerializeField] public Button OptionBOneButton;
    [SerializeField] public Button OptionBTwoButton;
    [SerializeField] public Button OptionBThreeButton;
    [SerializeField] public Button OptionBFourButton;
    [SerializeField] public Button OptionBFiveButton;
    [SerializeField] public GameObject OptionAScore;
    [SerializeField] public GameObject OptionBScore;
    [SerializeField] public GameObject IType;
    [SerializeField] public GameObject EType;
    [SerializeField] public GameObject NType;
    [SerializeField] public GameObject SType;
    [SerializeField] public GameObject TType;
    [SerializeField] public GameObject FType;
    [SerializeField] public GameObject PType;
    [SerializeField] public GameObject JType;
    [SerializeField] public Button MBTIAnalysisButton;
    [SerializeField] public GameObject PersonalityName;
    [SerializeField] public GameObject PersonalityDept;
    [SerializeField] public GameObject PersonalityDescription;
    [SerializeField] public GameObject personalityDetail;
    [SerializeField] public Button MBTIPreviousButton;
    [SerializeField] public Button MBTINextButton;
    [SerializeField] public Button MBTIFinishButton;
    int QuestionNo = 1;
    private bool isPlayerStartTest;
    string[] OptionAText = {"Text for A", "我會先了解別人的想法﹐再下決定。", "我是一個富於想像或憑直覺的人。", "我會根據現有資料及情境的分析，對他人做評斷。", "我會順著他人的意思做出承諾。", "我要有安靜、獨自思考的時間。", "我會運用我熟悉的好方法來完成工作。", "我會以合乎邏輯思考及按部就班的分析得到結論。", "我會訂下完成工作的最後期限。", "我會與人稍談笑話題後，再自我思考一番。", "我會設想各種可能發生的情況。", "我認為自己是一個善長於思考的人。", "我會事前詳細考慮各種可能性，事後反覆思考。", "我擁有內在的思想和情感﹐而不為他人所知。", "我喜歡抽象與理論的事。", "我會協助別人探索他們自己的感受。", "我對問題的答案保持彈性﹐且可修改。", "我很少表達自己內心的想法及感受。", "我傾向從大處著眼。", "我慣於運用常識，憑著信念來做決定。", "我會事先詳細計劃。", "我喜歡結交新朋友。", "我重視概念。", "我相信自已的想法。", "我會儘可能在記事簿記下事情。", "我會在團體中詳細地討論新奇未決定的問題。", "我會擬定詳密計劃﹐然後確實的執行。", "我是理性的。", "我會隨心所欲做些事。", "我喜歡成為眾人的焦點。", "我喜歡自由想像。", "我喜歡體驗感人的情境或事物。", "我會在預定的時間內開會。"};
    string[] OptionBText = {"Text for B", "我不和別人商量, 就下決定。", "我是一個講求精確﹐講求事實的人。", "我會先了解他人的需要及價值觀，才對他人做評斷。", "我會自己做承諾﹐並確實加以實踐。", "我喜歡與他人打成一片。", "我會嘗試運用新的方法來完成工作。", "我會根據過去生活的體驗及信息來得到結論。", "我會擬訂時間表，並嚴格遵行。", "我會和他人盡興暢談某事後﹐再自我思考一番。", "我只按實際的情況處理問題。", "我被別人認為是一個敏於感覺的人。", "我會搜集需要的資料，稍後作考慮後﹐作出明快決定。", "我會與他人共同分享某些活動或事件。", "我喜歡具體與實際的事。", "我會協助別人做出合理的決定。", "我對問題的答案是明確的、可預知的。", "我很自在表達自己內心的想法及感受。", "我喜歡從小處著手。", "我善於運用資料分析事實來做決定。", "我會臨時視需要而作計劃。", "我喜歡獨處或與熟識者交往。", "我重視事實。", "我相信經證實的結論。", "我儘可能少用記事簿記載事情。", "我全會自已先想出結論，然後才和他人討論。", "我擬定的計劃﹐但不一定執行。", "我是感性的。", "我儘量事先了解別人期望我做什麼。", "我喜歡退居幕後。", "我傾向檢視實情。", "我傾向運用能力，分析情境。", "我會在一切妥當或安適的情況下，宣報開會。"};
    string[] OptionATypes = {"Points for A", "2", "3", "5", "7", "1", "4", "5", "7", "1", "3", "5", "7", "1", "3", "6", "7", "1", "3", "6", "8", "2", "3", "6", "8", "2", "4", "5", "7", "2", "3", "6", "8"};
    string[] OptionBTypes = {"Points for B", "1", "4", "6", "8", "2", "3", "6", "8", "2", "4", "6", "8", "2", "4", "5", "8", "2", "4", "5", "7", "1", "4", "5", "7", "1", "3", "6", "8", "1", "4", "5", "7"};
    
    int[] OptionAAnswer = new int[33]; // 每題A選項分數
    int[] OptionBAnswer = new int[33]; // 每題B選項分數
    int[] AnswerCount = new int[9];
    int[] TypeCheck = new int[9];

    string[] Personality = {"ESTJ 行政者型", "ESTP 挑戰型", "ESFJ 主人型", "ESFP 表演型", "ENTJ 元帥型", "ENTP 發明家型", "ENFJ 教育家型", "ENFP 記者型", "ISTJ 公務型", "ISTP 冒險家型", "ISFJ 照顧型", "ISFP 藝術家型", "INTJ 專家型", "INTP 學者型", "INFJ 作家型", "INFP 哲學家型"};
    string[] PersonalityDeptText = { "法政、管理、工程", "財經、休憩運動、大眾傳播", "醫藥衛生、教育、社會心理", "休憩運動、大眾傳播、社會心理", "法政、財經、管理", "財經、大眾傳播、藝術", "大眾傳播、教育、文史哲", "社會心理、藝術、大眾傳播", "財經、法政、工程", "資訊、工程、財經", "醫藥衛生、生命科學、社會心理", "藝術、建築設計、社會心理", "數理化、資訊、建築設計", "資訊、數理化、工程", "文史哲、教育、藝術", "社會心理、教育、藝術" };
    string[] PersonalityText = {"軍警、企業管理、司法領域", "貿易、商業、服務業、金融證券業、娛樂、體育領域等", "保健、教育、社會服務、銷售", "消費類商業、服務業、廣告業、娛樂業、旅遊業、社區服務等", "工商業、政界、金融和投資領域、管理諮商、培訓、專業性領域", "投資顧問、項目策劃、投資銀行、自我創業、市場營銷、創造性領域、公共關係、政治等", "培訓、諮詢、教育、新聞傳播、公共關係、文化藝術", "心理學、顧問、記者、諮詢領域", "工商業領域、政府機構、金融銀行業、政府機構、技術領域、醫務領域", "技術領域、證券、金融業、貿易、商業領域、戶外、運動、藝術等", "醫護領域、消費類商業、服務業領域", "手工藝、藝術領域、醫護領域、商業、服務業領域等", "科研、科技應用、技術諮詢、管理諮詢、金融投資領域、創造性行業", "計算機技術、理論研究、學術領域、專業領域、創造性領域等", "諮詢、教育、科研、文化、藝術、設計等", "創作性、藝術類、教育研究、諮詢類等"};
    string[] PersonalityDetailText = { "講求實際，注重現實，注重事實。\n果斷，很快作出實際可行的決定。", "靈活、忍耐力強，實際，注重結果，喜歡積極地採取行動解決問題。\n在大多數的社交場合中，友善，富有魅力、輕鬆自如而受人歡迎。", "有愛心、有責任心、合作。希望周邊的環境溫馨而和諧。\n十分小心謹慎，也非常傳統化，因而能恪守自己的責任與承諾。", "外向，友善，包容。熱愛生活、人類和物質上的享受。\n天真率直，很有魅力和說服力。", "坦誠、果斷，有天生的領導能力。\n有條理和分析能力，樂於完成一些需要解決的復雜問題。", "反應快、叡智，有激勵別人的能力，警覺性強、直言不諱。\n富有想象力，他們深深地喜歡新思想，留心一切可能性。", "溫情，有同情心，反應敏捷，有責任感。\n具有平和的性格與忍耐力，長於外交，擅長在自己的周圍激發幽默感。", "熱情洋溢、富有想象力。認為生活是充滿很多可能性。\n不墨守成規，善於發現做事情的新方法。", "沉靜，認真；貫徹始終、得人信賴而取得成功。\n工作縝密，講求實際，對於細節有很強的記憶和判斷。", "容忍，有彈性；是冷靜的觀察者，但當問題出現，便迅速行動，找出解決方法。\n好奇心強，而且善於觀察，只有理性、可靠的事實才能使他們信服。", "沉靜，友善，有責任感和謹慎，能堅定不移地承擔責任。\n忠誠、有奉獻精神和同情心，理解別人的感受。", "沉靜，友善，敏感和仁慈，欣賞目前和他們週遭所發生的事情。\n從經歷中直接瞭解和感受的東西很感興趣，富有藝術天賦和審美感。", "在實現自己的想法和達成自己的目標時有創新的想法和非凡的動力。\n完美主義者，強烈地要求個人自由和能力", "沉靜，滿足，有彈性，適應力強。\n十分獨立，喜歡冒險和富有想象力的活動。", "有很強的洞察力。有責任心，堅持自己的價值觀。\n喜歡說服別人，使之相信他們的觀點是正確的。", "理想主義者，忠於自己的價值觀及自己所重視的人。\n思維開闊、有好奇心和洞察力，常常具有出色的長遠眼光。" };
    int[] PersonalityCheck = new int[16]; // 16型人格有哪些
    int PersonalityNum = 0;
    string[] Personality_Show = new string[16]; // 擁有的16型人格名字
    string[] PersonalityDeptText_Show = new string[16]; //擁有的16型人格建議學群
    string[] PersonalityText_Show = new string[16]; // 擁有的16型人格介紹
    string[] PersonalityDetailText_Show = new string[16]; //擁有的16型人格職業細節
    int PersonalityShowNum = 0;

    public IEnumerator SaveResult(string username, int []result)
    {
        WWWForm form = new WWWForm();
        // POST
        form.AddField("Username", username);
        form.AddField("I", result[1]);
        form.AddField("E", result[2]);
        form.AddField("N", result[3]);
        form.AddField("S", result[4]);
        form.AddField("T", result[5]);
        form.AddField("F", result[6]);
        form.AddField("P", result[7]);
        form.AddField("J", result[8]);

        // 注意: 網址要用http，不能用https否則會出錯
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ProjectV1/SaveMBTI.php", form))
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

    public IEnumerator IsDoneMBTI(string username, System.Action<bool>DoneBefore)
    {
        WWWForm form = new WWWForm();
        // POST
        form.AddField("Username", username);

        // 注意: 網址要用http，不能用https否則會出錯
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ProjectV1/IsDoneMBTI.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                //還沒做過測驗
                if (www.downloadHandler.text == "0")
                {
                    DoneBefore(false);
                }
                // 已經做過測驗
                else
                {
                    DoneBefore(true);
                    string res = www.downloadHandler.text;
                    Debug.Log(res);

                    var rec_data = Regex.Split(res, "</next>");
                    AnswerCount[1] = int.Parse(rec_data[0]);
                    AnswerCount[2] = int.Parse(rec_data[1]);
                    AnswerCount[3] = int.Parse(rec_data[2]);
                    AnswerCount[4] = int.Parse(rec_data[3]);
                    AnswerCount[5] = int.Parse(rec_data[4]);
                    AnswerCount[6] = int.Parse(rec_data[5]);
                    AnswerCount[7] = int.Parse(rec_data[6]);
                    AnswerCount[8] = int.Parse(rec_data[7]);
                }
            }
        }
    }

    void Start()
    {
        YesButton.onClick.AddListener(() => QuestionnaireIO(true));
        NoButton.onClick.AddListener(() => QuestionnaireIO(false));
        CheckButton.onClick.AddListener(() => ShowBeforeResult());
        NextButton.onClick.AddListener(() => QuestionChange(++ QuestionNo));
        PreviousButton.onClick.AddListener(() => QuestionChange(-- QuestionNo));
        FinishButton.onClick.AddListener(FinishTest);
        OptionAZeroButton.onClick.AddListener(() => OptionScore('A', 0));
        OptionAOneButton.onClick.AddListener(() => OptionScore('A', 1));
        OptionATwoButton.onClick.AddListener(() => OptionScore('A', 2));
        OptionAThreeButton.onClick.AddListener(() => OptionScore('A', 3));
        OptionAFourButton.onClick.AddListener(() => OptionScore('A', 4));
        OptionAFiveButton.onClick.AddListener(() => OptionScore('A', 5));
        OptionBZeroButton.onClick.AddListener(() => OptionScore('B', 0));
        OptionBOneButton.onClick.AddListener(() => OptionScore('B', 1));
        OptionBTwoButton.onClick.AddListener(() => OptionScore('B', 2));
        OptionBThreeButton.onClick.AddListener(() => OptionScore('B', 3));
        OptionBFourButton.onClick.AddListener(() => OptionScore('B', 4));
        OptionBFiveButton.onClick.AddListener(() => OptionScore('B', 5));
        MBTIAnalysisButton.onClick.AddListener(MBTIAnalysis);
        MBTINextButton.onClick.AddListener(() => PersonalityChange(++ PersonalityShowNum));
        MBTIPreviousButton.onClick.AddListener(() => PersonalityChange(-- PersonalityShowNum));
        MBTIFinishButton.onClick.AddListener(MBTIFinish);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            StartCoroutine(IsDoneMBTI(UserInfo.Username, (DoneBefore) =>
            {
                if (DoneBefore)
                {
                    Dialog_Box_1.SetActive(true);
                    other.GetComponentInChildren<PlayerPerspective>().mouseSensitivity = 1f;
                }
                else
                {
                    Dialog_Box.SetActive(true);
                    other.GetComponentInChildren<PlayerPerspective>().mouseSensitivity = 1f;
                }
            }));            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(IsDoneMBTI(UserInfo.Username, (DoneBefore) =>
            {
                if (DoneBefore)
                {
                    Dialog_Box_1.SetActive(false);
                    MBTI_Result.SetActive(false);
                    MBTI_Analysis.SetActive(false);
                    other.GetComponentInChildren<PlayerPerspective>().mouseSensitivity = 100f;
                }
                else
                {
                    Dialog_Box.SetActive(false);
                    MBTI_Questionnaire.SetActive(false);
                    other.GetComponentInChildren<PlayerPerspective>().mouseSensitivity = 100f;
                }
            }));
        }
    }

    void ShowBeforeResult()
    {
        MBTI_Result.SetActive(true);
        Dialog_Box_1.SetActive(false);
        IType.GetComponent<Text>().text = "內向型(I) : " + AnswerCount[1].ToString();
        EType.GetComponent<Text>().text = "外向型(E) : " + AnswerCount[2].ToString();
        NType.GetComponent<Text>().text = "直覺型(N) : " + AnswerCount[3].ToString();
        SType.GetComponent<Text>().text = "辨識型(S) : " + AnswerCount[4].ToString();
        TType.GetComponent<Text>().text = "理性(T) : " + AnswerCount[5].ToString();
        FType.GetComponent<Text>().text = "感性(F) : " + AnswerCount[6].ToString();
        PType.GetComponent<Text>().text = "熟思型(P) : " + AnswerCount[7].ToString();
        JType.GetComponent<Text>().text = "果斷型(J) : " + AnswerCount[8].ToString();
    }

    void QuestionnaireIO(bool flag)
    {
        if(flag == true)
        {
            MBTI_Questionnaire.SetActive(true);
            Dialog_Box.SetActive(false);
            isPlayerStartTest = true;
            QuestionNo = 1;
            PreviousButton.enabled = false;
            NextButton.enabled = false;
            FinishButton.enabled = false;
            OptionA.GetComponent<Text>().text = "A." + OptionAText[1];
            OptionB.GetComponent<Text>().text = "B." + OptionBText[1];
            QuestionNoText.GetComponent<Text>().text = QuestionNo.ToString() + "/ 32";
        }
        else
        {
            MBTI_Questionnaire.SetActive(false);
            Dialog_Box.SetActive(false);
        }
    }
    void QuestionChange(int No)
    {
        PreviousButton.enabled = false;
        NextButton.enabled = false;
        OptionA.GetComponent<Text>().text = "A." + OptionAText[No];
        OptionB.GetComponent<Text>().text = "B." + OptionBText[No];
        QuestionNoText.GetComponent<Text>().text = No.ToString() + "/ 32";
        if(OptionAAnswer[No] == 0 && OptionBAnswer[No] == 0)
        {
            OptionAScore.GetComponent<Text>().text = "0";
            OptionBScore.GetComponent<Text>().text = "0";
        }
        else
        {
            OptionAScore.GetComponent<Text>().text = OptionAAnswer[No].ToString();
            OptionBScore.GetComponent<Text>().text = OptionBAnswer[No].ToString();
            if(No > 1)
            {
                PreviousButton.enabled = true;
            }
            if(No < 32)
            {
                NextButton.enabled = true;
                NextButton.gameObject.SetActive(true);
                FinishButton.gameObject.SetActive(false);
            }
            if(No == 32)
            {
                NextButton.gameObject.SetActive(false);
                FinishButton.gameObject.SetActive(true);
            }
            
        }
        
    }

    void OptionScore(char option, int score)
    {
        if(QuestionNo > 1)
        {
            PreviousButton.enabled = true;
        }
        if(QuestionNo < 32)
        {
            NextButton.enabled = true;
            NextButton.gameObject.SetActive(true);
            FinishButton.gameObject.SetActive(false);
        }
        if(QuestionNo == 32)
        {
            NextButton.gameObject.SetActive(false);
            FinishButton.gameObject.SetActive(true);
            FinishButton.enabled = true;
        }
        if (option == 'A')
        {
            OptionAScore.GetComponent<Text>().text = score.ToString();
            OptionBScore.GetComponent<Text>().text = (5 - score).ToString();
            OptionAAnswer[QuestionNo] = score;
            OptionBAnswer[QuestionNo] = 5 - score;
        }
        else if(option == 'B')
        {
            OptionBScore.GetComponent<Text>().text = score.ToString();
            OptionAScore.GetComponent<Text>().text = (5 - score).ToString();
            OptionAAnswer[QuestionNo] = 5 - score;
            OptionBAnswer[QuestionNo] = score;
        }
    }
    void FinishTest()
    {
        for (int i = 1; i < 33 ; i ++)
        {
            switch (OptionATypes[i])
            {
                case "1":
                    AnswerCount[1] += OptionAAnswer[i];
                    break;
                case "2":
                    AnswerCount[2] += OptionAAnswer[i];
                    break;
                case "3":
                    AnswerCount[3] += OptionAAnswer[i];
                    break;
                case "4":
                    AnswerCount[4] += OptionAAnswer[i];
                    break;
                case "5":
                    AnswerCount[5] += OptionAAnswer[i];
                    break;
                case "6":
                    AnswerCount[6] += OptionAAnswer[i];
                    break;
                case "7":
                    AnswerCount[7] += OptionAAnswer[i];
                    break;
                case "8":
                    AnswerCount[8] += OptionAAnswer[i];
                    break;
                default:
                    break;
            }

            switch (OptionBTypes[i])
            {
                case "1":
                    AnswerCount[1] += OptionBAnswer[i];
                    break;
                case "2":
                    AnswerCount[2] += OptionBAnswer[i];
                    break;
                case "3":
                    AnswerCount[3] += OptionBAnswer[i];
                    break;
                case "4":
                    AnswerCount[4] += OptionBAnswer[i];
                    break;
                case "5":
                    AnswerCount[5] += OptionBAnswer[i];
                    break;
                case "6":
                    AnswerCount[6] += OptionBAnswer[i];
                    break;
                case "7":
                    AnswerCount[7] += OptionBAnswer[i];
                    break;
                case "8":
                    AnswerCount[8] += OptionBAnswer[i];
                    break;
                default:
                    break;
            }
        }
        StartCoroutine(SaveResult(UserInfo.Username, AnswerCount));
        for(int i = 1; i < 9; i++)
        {
            print(AnswerCount[i]);
        }
        MBTI_Questionnaire.SetActive(false);
        MBTI_Result.SetActive(true);
        IType.GetComponent<Text>().text = "內向型(I) : " + AnswerCount[1].ToString();
        EType.GetComponent<Text>().text = "外向型(E) : " + AnswerCount[2].ToString();
        NType.GetComponent<Text>().text = "直覺型(N) : " + AnswerCount[3].ToString();
        SType.GetComponent<Text>().text = "辨識型(S) : " + AnswerCount[4].ToString();
        TType.GetComponent<Text>().text = "理性(T) : " + AnswerCount[5].ToString();
        FType.GetComponent<Text>().text = "感性(F) : " + AnswerCount[6].ToString();
        PType.GetComponent<Text>().text = "熟思型(P) : " + AnswerCount[7].ToString();
        JType.GetComponent<Text>().text = "果斷型(J) : " + AnswerCount[8].ToString();
    }
    void MBTIAnalysis()
    {
        MBTI_Result.SetActive(false);
        MBTI_Analysis.SetActive(true);
        for (int i = 1; i < 9 ; i ++)
        {
            if (AnswerCount[i] > 18)
            {
                TypeCheck[i] = 1;
            }
            else
            {
                TypeCheck[i] = 0;
            }
        }
        if(TypeCheck[2] == 1 && TypeCheck[4] == 1 && TypeCheck[5] == 1 && TypeCheck[8] == 1)
        {
            PersonalityCheck[0] = 1;
        }
        if(TypeCheck[2] == 1 && TypeCheck[4] == 1 && TypeCheck[5] == 1 && TypeCheck[7] == 1)
        {
            PersonalityCheck[1] = 1;
        }
        if(TypeCheck[2] == 1 && TypeCheck[4] == 1 && TypeCheck[6] == 1 && TypeCheck[8] == 1)
        {
            PersonalityCheck[2] = 1;
        }
        if(TypeCheck[2] == 1 && TypeCheck[4] == 1 && TypeCheck[6] == 1 && TypeCheck[7] == 1)
        {
            PersonalityCheck[3] = 1;
        }
        if(TypeCheck[2] == 1 && TypeCheck[3] == 1 && TypeCheck[5] == 1 && TypeCheck[8] == 1)
        {
            PersonalityCheck[4] = 1;
        }
        if(TypeCheck[2] == 1 && TypeCheck[3] == 1 && TypeCheck[5] == 1 && TypeCheck[7] == 1)
        {
            PersonalityCheck[5] = 1;
        }
        if(TypeCheck[2] == 1 && TypeCheck[3] == 1 && TypeCheck[6] == 1 && TypeCheck[8] == 1)
        {
            PersonalityCheck[6] = 1;
        }
        if(TypeCheck[2] == 1 && TypeCheck[3] == 1 && TypeCheck[6] == 1 && TypeCheck[7] == 1)
        {
            PersonalityCheck[7] = 1;
        }
        if(TypeCheck[1] == 1 && TypeCheck[4] == 1 && TypeCheck[5] == 1 && TypeCheck[8] == 1)
        {
            PersonalityCheck[8] = 1;
        }
        if(TypeCheck[1] == 1 && TypeCheck[4] == 1 && TypeCheck[5] == 1 && TypeCheck[7] == 1)
        {
            PersonalityCheck[9] = 1;
        }
        if(TypeCheck[1] == 1 && TypeCheck[4] == 1 && TypeCheck[6] == 1 && TypeCheck[8] == 1)
        {
            PersonalityCheck[10] = 1;
        }
        if(TypeCheck[1] == 1 && TypeCheck[4] == 1 && TypeCheck[6] == 1 && TypeCheck[7] == 1)
        {
            PersonalityCheck[11] = 1;
        }
        if(TypeCheck[1] == 1 && TypeCheck[3] == 1 && TypeCheck[5] == 1 && TypeCheck[8] == 1)
        {
            PersonalityCheck[12] = 1;
        }
        if(TypeCheck[1] == 1 && TypeCheck[3] == 1 && TypeCheck[5] == 1 && TypeCheck[7] == 1)
        {
            PersonalityCheck[13] = 1;
        }
        if(TypeCheck[1] == 1 && TypeCheck[3] == 1 && TypeCheck[6] == 1 && TypeCheck[8] == 1)
        {
            PersonalityCheck[14] = 1;
        }
        if(TypeCheck[1] == 1 && TypeCheck[3] == 1 && TypeCheck[6] == 1 && TypeCheck[7] == 1)
        {
            PersonalityCheck[15] = 1;
        }

        MBTIPreviousButton.enabled = false;
        MBTINextButton.enabled = false;
        MBTIFinishButton.enabled = false;
        for (int i = 0; i < PersonalityCheck.Length ; i ++)
        {
            if (PersonalityCheck[i] == 1)
            {
                Personality_Show[PersonalityNum] = Personality[i];
                PersonalityDeptText_Show[PersonalityNum] = PersonalityDeptText[i];
                PersonalityText_Show[PersonalityNum] = PersonalityText[i];
                PersonalityDetailText_Show[PersonalityNum] = PersonalityDetailText[i];
                PersonalityNum ++;
            }
        }
        PersonalityName.GetComponent<Text>().text = Personality_Show[PersonalityShowNum];
        PersonalityDept.GetComponent<Text>().text = "適合學群:\n" + PersonalityDeptText_Show[PersonalityShowNum];
        PersonalityDescription.GetComponent<Text>().text = "適合工作領域:\n" + PersonalityText_Show[PersonalityShowNum];
        personalityDetail.GetComponent<Text>().text = "人格特質:\n" + PersonalityDetailText_Show[PersonalityShowNum];
        if (PersonalityShowNum == 0)
        {
            MBTIPreviousButton.gameObject.SetActive(false); 
        }
        if (PersonalityShowNum > 0)
        {
            MBTIPreviousButton.gameObject.SetActive(true);
            MBTIPreviousButton.enabled = true;
        }
        if (PersonalityShowNum < PersonalityNum - 1)
        {
            MBTINextButton.enabled = true;
            MBTINextButton.gameObject.SetActive(true);
            MBTIFinishButton.gameObject.SetActive(false);
        }
        if(PersonalityShowNum + 1 == PersonalityNum)
        {
            MBTINextButton.enabled = false;
            MBTIFinishButton.enabled = true;
            MBTINextButton.gameObject.SetActive(false);
            MBTIFinishButton.gameObject.SetActive(true);
        }
    }
    void PersonalityChange(int PersonalityShowNum)
    {
        PersonalityName.GetComponent<Text>().text = Personality_Show[PersonalityShowNum];
        PersonalityDept.GetComponent<Text>().text = "適合學群:\n" + PersonalityDeptText_Show[PersonalityShowNum];
        PersonalityDescription.GetComponent<Text>().text = "適合工作領域:\n" + PersonalityText_Show[PersonalityShowNum];
        personalityDetail.GetComponent<Text>().text = "人格特質:\n" + PersonalityDetailText_Show[PersonalityShowNum];
        if (PersonalityShowNum > 0)
        {
            MBTIPreviousButton.enabled = true;
            MBTIPreviousButton.gameObject.SetActive(true);
        }
        else
        {
            MBTIPreviousButton.enabled = false;
            MBTIPreviousButton.gameObject.SetActive(false);
        }
        if (PersonalityShowNum < PersonalityNum - 1)
        {
            MBTINextButton.enabled = true;
            MBTINextButton.gameObject.SetActive(true);
            MBTIFinishButton.gameObject.SetActive(false);
        }
        if(PersonalityShowNum + 1 == PersonalityNum)
        {
            MBTINextButton.enabled = false;
            MBTIFinishButton.enabled = true;
            MBTINextButton.gameObject.SetActive(false);
            MBTIFinishButton.gameObject.SetActive(true);
        }
    }
    void MBTIFinish()
    {
        MBTI_Analysis.SetActive(false);
    }
}
