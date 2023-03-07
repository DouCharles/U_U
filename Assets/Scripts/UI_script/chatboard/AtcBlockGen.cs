using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text.RegularExpressions;

public class AtcBlockGen : MonoBehaviour
{
    public GameObject ForumLobby;
    public GameObject ForumPost;
    public GameObject Postshow;

    public Dropdown School;
    public Dropdown Department;
    public Button PostButton;

    public GameObject Content;
    public GameObject AtcBlock;

    // ���o�峹��ƨåͦ��峹���
    IEnumerator GetPostData(string school, string department)
    {
        WWWForm form = new WWWForm();
        //POST
        form.AddField("School", school);
        form.AddField("Department", department);

        string strUrl = "http://localhost/ProjectV1/ForumLobby.php";
        using (UnityWebRequest www = UnityWebRequest.Post(strUrl, form))
        {
            yield return www.SendWebRequest();

            // �o�Ϳ��~
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string res = www.downloadHandler.text;
                Debug.Log(res);

                var rec_data = Regex.Split(res, "</next>");
                //print(rec_data.Length);
                int datanum = (rec_data.Length-1)/8;
                
                Debug.Log("dataNum = " + datanum.ToString());                     

                GameObject[] newAtcBlock = new GameObject[datanum];
                Vector3 BlockPos = new Vector3(0f, - 70, 0f);
                GameObject[] Info = new GameObject[8];      //School, Department, Date, Title, Author, Likes, Comments, id;
                if (datanum > 4)
                {
                    Content.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 105 * datanum + 30);
                    Content.GetComponent<RectTransform>().localPosition = new Vector3(0, -105 * datanum / 2, 0);
                }
                for (int i = 0; i < datanum; i++)
                {
                    newAtcBlock[i] = Instantiate(AtcBlock, BlockPos, Quaternion.identity) as GameObject;
                    newAtcBlock[i].transform.SetParent(Content.transform, false);
                    for (int j = 0; j <  7; j++)
                    {                      
                        Info[j] = newAtcBlock[i].transform.GetChild(j).gameObject;    //��� Prefab ArticleBlock[i] ����j�Ӥl���� Text
                        Info[j].GetComponent<Text>().text += " " + rec_data[i*8+j];                        
                    }
                    newAtcBlock[i].name = rec_data[i * 8 + 7].ToString();
                    BlockPos -= new Vector3(0f, 105f, 0f);
                }                
            }
        }
    }

    // �ͦ��峹���
    public void Generate()
    {
        string school_val = School.options[School.value].text;
        string department_val = Department.options[Department.value].text;
        StartCoroutine(GetPostData(school_val, department_val));
    }

    void Start()
    {
        // ��}�l�I�s
        Generate();

        // ���U�o��Button�A���o�夶��
        PostButton.onClick.AddListener(() =>
        {
            ForumLobby.SetActive(false);
            ForumPost.SetActive(true);            
        });

        // School dropdown ���ܥͦ��峹���
        School.onValueChanged.AddListener(delegate {
            foreach (Transform child in Content.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            Postshow.SetActive(true);
            Content.GetComponent<RectTransform>().offsetMax = new Vector2(Content.GetComponent<RectTransform>().offsetMax.x, 0);    //top = 0
            Generate();
        });

        // Department dropdown ���ܥͦ��峹���
        Department.onValueChanged.AddListener(delegate {
            foreach (Transform child in Content.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            Postshow.SetActive(true);
            Content.GetComponent<RectTransform>().offsetMax = new Vector2(Content.GetComponent<RectTransform>().offsetMax.x, 0);    //top = 0
            Generate();
        });
    }

    // Update is called once per frame
    void Update()
    {
        // ���s����峹��ƨåͦ����
        if(Postshow.GetComponent<ShowPost>().regen == 1 || ForumPost.GetComponent<Post>().regen == 1)
        {
            foreach (Transform child in Content.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            Postshow.SetActive(true);
            Content.GetComponent<RectTransform>().offsetMax = new Vector2(Content.GetComponent<RectTransform>().offsetMax.x, 0);    //top = 0
            Generate();
            Postshow.GetComponent<ShowPost>().regen = 0;
            ForumPost.GetComponent<Post>().regen = 0;
        }
    }
}


