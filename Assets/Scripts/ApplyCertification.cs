using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
//blockchain
using Nethereum.JsonRpc.UnityClient;
//using Htdocs.Contracts.certificate.ContractDefinition;
using System;
using Contract_code_new4.Contracts.certificate.ContractDefinition;
using Nethereum.Web3;
using System.IO;

public class ApplyCertification : MonoBehaviour
{

    public Dropdown School;
    public Dropdown Department;

    public Button ApplyButton;
    public Text ApplyBtnText;

    public Text Msg;

    public Button SuccessfulButton;
    public GameObject ApplyUI;
    public GameObject SuccessfulUI;
    public GameObject ContentText;
    public GameObject DateText;
    public GameObject CertificateIDText;
    string[] CertificateInfo = new string[6];

    string privatekey = "8a54894ebd43e948be8ff7991ac9b88cf977a0bcfe0ca1d0f625d208f4d730be";
    string url = "https://rinkeby.infura.io/v3/ac4428b25beb43bbb7fff640f877c654";
    string fromAddress = "0x85df66a2361b7d10610935ccca5069c70f686fc2";
    string contractAddress = "0x9Cf4dD713f234aeDb10d9cd975111A0d01478030";
    public IEnumerator DropdownCheck(string username, string school, string department)
    {
        WWWForm form = new WWWForm();
        // POST
        form.AddField("Username", username);
        form.AddField("School", school);
        form.AddField("Department", department);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ProjectV1/CheckCerti.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                    if(www.downloadHandler.text == "0")
                    {
                        ApplyButton.enabled = false;
                        ApplyBtnText.text = "無該系所證書申請資格";
                    }
                    else
                    {
                        ApplyButton.enabled = true;
                        ApplyBtnText.text = "申請證書";
                    }
                }
            }
        }
    }

    public IEnumerator Apply(string username, string school, string department)
    {
        WWWForm form = new WWWForm();
        // POST
        form.AddField("Username", username);
        form.AddField("School", school);
        form.AddField("Department", department);

        // �`�N: ���}�n��http�A�����https�_�h�|�X��
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ProjectV1/Certification.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
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
    }

    void check()
    {
        string school_val = School.options[School.value].text;
        string department_val = Department.options[Department.value].text;
        StartCoroutine(DropdownCheck(UserInfo.Username, school_val, department_val));
    }

    // Start is called before the first frame update
    void Start()
    {
        SuccessfulButton.onClick.AddListener(CloseCertificate);
        SuccessfulUI.SetActive(false);
        ApplyButton.onClick.AddListener(() =>
        {
            string school_val = School.options[School.value].text;
            string department_val = Department.options[Department.value].text;
            //StartCoroutine(Apply(UserInfo.Username, school_val, department_val));
            StartCoroutine(apply_blockchain(school_val, department_val, UserInfo.RealName));
            Msg.text = "**申請成功**";
            
            ApplyUI.SetActive(false);
        });

        // School dropdown 
        School.onValueChanged.AddListener(delegate {
            check();
            Msg.text = "";
        });

        // Department dropdown 
        Department.onValueChanged.AddListener(delegate {
            check();
            Msg.text = "";
        });

        ApplyButton.enabled = false;
        check();

       // StartCoroutine(GetBlockNumber());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetCertificate()
    {
        ContentText.GetComponent<Text>().text = "恭喜 " + CertificateInfo[0] + " 參加本平台 " +  "\n" + CertificateInfo[1] + "  " + CertificateInfo[2] + "\n" + " 密室逃脫體驗遊戲\n" + "並取得" + CertificateInfo[3] + " 分的成績\n" + "頒此證書 以茲證明";
        DateText.GetComponent<Text>().text = "發證日期 : " + CertificateInfo[4];
        CertificateIDText.GetComponent<Text>().text = "證書編號 : " + CertificateInfo[5]; 
    }
    void CloseCertificate()
    {
        SuccessfulUI.SetActive(false);
        ApplyUI.SetActive(true);
    }
    string temp="";
    IEnumerator apply_blockchain(string school, string department, string RealName)
    {
        string date = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();

        var hash = new Hash128();
        hash.Append((int)Mathf.Round(UserInfo.score_2[1]));
        hash.Append(UserInfo.RealName);
        hash.Append(date);
        hash.Append(school);
        hash.Append(department);
        hash.Append(DateTime.Now.Hour);
        hash.Append(DateTime.Now.Minute);
        hash.Append(DateTime.Now.Second);
        print("hash = " + hash);
        var transactionTransferRequest = new TransactionSignedUnityRequest(url, privatekey);
        var transactionMessage = new StoreMemberFunction
        {
            FromAddress = fromAddress,
            Hash = hash.ToString(),
            Score = 85,//(int)Mathf.Round(UserInfo.score_2[1]), //UserInfo.score_2[1];
            RealName = UserInfo.RealName, //startcoroutine(get real name from database)
            Date = date, // DATefunction
            InputSchool = school, // 
            InputDepartment = department,
        };
        
        yield return transactionTransferRequest.SignAndSendTransaction(transactionMessage, contractAddress);
        CertificateInfo[0] = UserInfo.RealName;
        CertificateInfo[1] = "國立成功大學";
        CertificateInfo[2] = "資訊工程學系";
        CertificateInfo[3] = "85";//UserInfo.score_2[1].ToString();
        CertificateInfo[4] = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
        CertificateInfo[5] = hash.ToString();
        SetCertificate();
        string datestamp = DateTime.Now.Year.ToString()+ DateTime.Now.Month.ToString()+ DateTime.Now.Day.ToString()+ DateTime.Now.Hour.ToString()+ DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
        print(datestamp);
        string path = Application.persistentDataPath + "/NCKU_CSIE"+datestamp;
        if(!Directory.Exists(path))
            Directory.CreateDirectory(Application.persistentDataPath + "/NCKU_CSIE"+datestamp);
        Debug.Log(path);
        string certificatepath = path + "/Certificatehash.txt";
        StreamWriter writer = new StreamWriter(certificatepath, true);
        writer.WriteLine(hash);
        writer.Close();
        
        SuccessfulUI.SetActive(true);
        string pic_name = path + "/Certificate.png";
        StartCoroutine(CaptureByUI(SuccessfulUI.GetComponent<RectTransform>(), pic_name));
        //StartCoroutine(GetBlockNumber(transactionTransferRequest.Result));
        print("hash? = " + transactionTransferRequest);
        print("result = " + transactionTransferRequest.Result);
        
    }
    private IEnumerator GetBlockNumber(string blocknumber)
    {
       
        var blockNumberRequest = new EthBlockNumberUnityRequest(url);
        yield return blockNumberRequest.SendRequest();

        var blocknum = blockNumberRequest.Result;
        //print(blockNumberRequest.Result);
        print("blockNUm = " + blocknum);
        CertificateInfo[0] = UserInfo.RealName;
        CertificateInfo[1] = "國立成功大學";
        CertificateInfo[2] = "資訊工程學系";
        CertificateInfo[3] = UserInfo.score_2[1].ToString();
        CertificateInfo[4] = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString();
        CertificateInfo[5] = blocknum.ToString();
        SetCertificate();
        SuccessfulUI.SetActive(true);
    }

    /*IEnumerator search_certificate()
    {
        var queryRequest = new QueryUnityRequest<GetAccountDetailFunction, GetAccountDetailOutputDTO>(url, privatekey);
        yield return queryRequest.Query(new GetAccountDetailFunction() { FromAddress = fromAddress,AccountName = "charles" }, contractAddress);
    */

    public IEnumerator CaptureByUI(RectTransform UIRect, string mFileName)
    {
        //等待幀畫面渲染結束
        yield return new WaitForEndOfFrame();

        int width = (int)(UIRect.rect.width)+16;
        int height = (int)(UIRect.rect.height)+16;

        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);

        //左下角爲原點（0, 0）
        float leftBtmX = UIRect.transform.position.x + UIRect.rect.xMin - 8;
        float leftBtmY = UIRect.transform.position.y + UIRect.rect.yMin - 8;

        //從屏幕讀取像素, leftBtmX/leftBtnY 是讀取的初始位置,width、height是讀取像素的寬度和高度
        tex.ReadPixels(new Rect(leftBtmX, leftBtmY, width, height), 0, 0);
        //執行讀取操作
        tex.Apply();
        byte[] bytes = tex.EncodeToPNG();
        //保存
        System.IO.File.WriteAllBytes(mFileName, bytes);
    }
}
