using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class CoBuildUIController : MonoBehaviour
{
    [SerializeField] private Image BigRoom;
    [SerializeField] private Image SmallRoom;

    [SerializeField] private Image ChoosenBackground;
    [SerializeField] private Button LoadSceneButton;

    [SerializeField] private int mode = 1;
    [SerializeField] private GameObject DisableUI;
    int size = 0;
    // Start is called before the first frame update
    void Start()
    {
        BigRoom.GetComponent<Button>().onClick.AddListener(()=> ChooseSize(1));
        SmallRoom.GetComponent<Button>().onClick.AddListener(()=> ChooseSize(2)); 
        LoadSceneButton.onClick.AddListener(LoadScene);
        StartCoroutine(check_identity());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ChooseSize(int num)
    {
        UserInfo.room_type = num;
        if (num == 1)
        {//big one
            Transform Big_T = BigRoom.gameObject.GetComponent<Transform>();
            size = 7;//need to modify
            ChoosenBackground.gameObject.SetActive(true);
            Transform Big = ChoosenBackground.gameObject.GetComponentInChildren<Transform>();
            Big.position = new Vector3(Big_T.position.x, Big_T.position.y, Big_T.position.z);
            UserInfo.room_type = 1;
        }
        if (num == 2)
        {//small one
            Transform Small_T = SmallRoom.gameObject.GetComponentInChildren<Transform>();
            size = 6;
            ChoosenBackground.gameObject.SetActive(true);
            Transform Small = ChoosenBackground.gameObject.GetComponentInChildren<Transform>();
            Small.position = new Vector3(Small_T.position.x, Small_T.position.y, Small_T.position.z);
            UserInfo.room_type = 2;
        }
    }
    void LoadScene()
    {
        if(mode == 1)
        {
            DisableUI.SetActive(true);
        }
        else if(mode == 2)
        {
            
            SceneManager.LoadScene(size);
        }
    }

    IEnumerator check_identity()
    {
        string url = "http://localhost/unity/formal/check_identity.php";
        WWWForm form = new WWWForm();
        form.AddField("username", UserInfo.Username);

        using(UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();
            if(www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text +"/end");
                if(www.downloadHandler.text == "0")
                {
                    mode = 1;
                }
                else
                {
                    mode = 2;
                }
            }
        }

    }
}
