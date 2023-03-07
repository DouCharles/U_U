using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class LevelButtonIntantiate : MonoBehaviour
{
    [SerializeField] private Button LevelButton, CoCreate_orginal_btn;
    [SerializeField] private GameObject ButtonRect_Cocreate;
    [SerializeField] private GameObject[] ButtonRect_original;
    [SerializeField] private int [] LevelSceneList;
    [SerializeField] private Text[] class_txt;
    bool IsCocreate_room = false;
    // Start is called before the first frame update
    void Start()
    {
        ButtonRect_Cocreate.SetActive(false);
        CoCreate_orginal_btn.GetComponentInChildren<Text>().text = "共創房間";
        for (int j = 0; j < ButtonRect_original.Length; j++)
        {
            for (int i = 0; i < LevelSceneList.Length; i++)
            {
                int SceneId = LevelSceneList[i];
                int level = i + 1;
                Button newButton = Instantiate(LevelButton, new Vector3((73.75f + 85 * i), 267.5f, 0), new Quaternion(0, 0, 0, 0), ButtonRect_original[j].transform);
                newButton.gameObject.GetComponentInChildren<Text>().fontSize = 40;
                newButton.gameObject.GetComponentInChildren<Text>().text = "第" + (i + 1).ToString() + "關";
                newButton.onClick.AddListener(() => { UserInfo.level = level; LevelEntry(SceneId); });
            }
        }
        CoCreate_orginal_btn.onClick.AddListener(() => change_room_content());
        UserInfo.department = "資訊工程學系";
        UserInfo.school = "國立成功大學";
        StartCoroutine(lookfor_allpushedroom());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LevelEntry(int GoToSceneId)
    {
        Debug.Log(GoToSceneId);
        
        SceneManager.LoadScene(GoToSceneId);
    }

    void change_room_content()
    {
        if (IsCocreate_room)
        {
            for (int i = 0; i < ButtonRect_original.Length; i++)
            {
                ButtonRect_original[i].SetActive(true);
            }
            for (int i = 0; i < class_txt.Length; i++)
            {
                class_txt[i].gameObject.SetActive(true);
            }
            ButtonRect_Cocreate.SetActive(false);
            
            CoCreate_orginal_btn.GetComponentInChildren<Text>().text = "共創房間";
        }
        else
        {
            for (int i = 0; i < ButtonRect_original.Length; i++)
            {
                ButtonRect_original[i].SetActive(false);
                
            }
            for (int i = 0; i < class_txt.Length; i++)
            {
                class_txt[i].gameObject.SetActive(false);
            }
            ButtonRect_Cocreate.SetActive(true);
            
            CoCreate_orginal_btn.GetComponentInChildren<Text>().text = "原始房間";
        }
        IsCocreate_room = !IsCocreate_room;
    }

    private IEnumerator lookfor_allpushedroom()
    {
        string url = "http://localhost/unity/formal/all_pushed_room.php";
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                print(www.downloadHandler.text);
                string[] room = www.downloadHandler.text.Split(';');
                for (int i = 0; i < room.Length; i++)
                {
                    string[] room_info = room[i].Split('/');
                    if (room_info.Length != 2)
                        continue;
                    int sceneId = 0;
                    Button newButton = Instantiate(LevelButton, new Vector3((73.75f + 85 * i), 267.5f, 0), new Quaternion(0, 0, 0, 0), ButtonRect_Cocreate.transform);

                    if (room_info[0].Length < 10)
                        newButton.GetComponentInChildren<Text>().fontSize = 25;
                    else if (10 <= room_info[0].Length && room_info[0].Length < 20)
                        newButton.GetComponentInChildren<Text>().fontSize = 20;
                    else
                        newButton.GetComponentInChildren<Text>().fontSize = 15;

                    newButton.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 30);
                    newButton.gameObject.GetComponentInChildren<Text>().text = room_info[0];
                    string room_name = room_info[0];
                    if (room_info[1] == "1")
                    {
                        sceneId = 8;
                    }
                    else if (room_info[1] == "2")
                    {
                        sceneId = 10;
                    }
                    else if (room_info[1] == "3")
                    {
                        sceneId = 8;
                    }
                    int level = 1001 + i;
                    newButton.onClick.AddListener(() => { UserInfo.level = level; StartCoroutine(GetScene(room_name)); });
                    //newButton.onClick.AddListener(() => LevelEntry(sceneId));
                }
            }
        }
    }

    IEnumerator GetScene(string roomname)
    {
        string url = "http://localhost/unity/formal/escapeRoom_co.php";
        WWWForm form = new WWWForm();
        form.AddField("room_name", roomname);
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                print(www.downloadHandler.text);
                UserInfo.room_name = roomname;
                string[] scenenum = www.downloadHandler.text.Split(';');
                print("ESCAPEROOM loadscene :" + scenenum[0]);
                int tempnum = 0;
                if(scenenum[0] == "1")
                {
                    tempnum = 8; // modify to enter right scene   EscapeRoom_small
                }
                else if (scenenum[0] == "2")
                {
                    tempnum = 8;// modify to enter right scene   EscapeRoom_middle
                }
                else if (scenenum[0] == "3")
                {
                    tempnum = 8;// modify to enter right scene   EscapeRoom_big
                }
                SceneManager.LoadScene(tempnum);

            }
        }
    }
}
