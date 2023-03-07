using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text.RegularExpressions;

public class AtcClick : MonoBehaviour
{
    // 當討論版大廳的文章方塊被點擊時，取得文章id資料
    GameObject Lobby;
    GameObject Show;
    private int id = 0;
    void Start()
    {
        Lobby = GameObject.Find("ForumLobby");
        Show = GameObject.Find("PostShow");
        Lobby.SetActive(true);
        GetComponent<Button>().onClick.AddListener(() =>
        {
            Debug.Log("click");
            Lobby.SetActive(false);
            Show.SetActive(true);
            id = int.Parse(this.name);
            print("click: "+ id);
            Show.GetComponent<ShowPost>().id_show = id;     
            Show.GetComponent<Comment>().id_show_c = id;
            Show.GetComponent<ShowPost>().isrequest = true;
            Show.GetComponent<Comment>().isrequest = true;
        });
    }
}
