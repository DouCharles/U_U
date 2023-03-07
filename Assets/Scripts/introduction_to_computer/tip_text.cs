using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class tip_text : MonoBehaviour
{
    [SerializeField] public string txt;
    private TMP_Text txt_show;
    // Start is called before the first frame update
    void Start()
    {
        txt_show = GetComponentInChildren<TMP_Text>();
        txt = txt.Replace("\\n", "\n");
        txt_show.text = txt;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SmallRoom")
        {
            txt_show = GetComponentInChildren<TMP_Text>();
            txt = txt.Replace("\\n", "\n");
            txt_show.text = txt;
        }
        // 65:A | 66:B | 67:C | 68:D | 69:E
    }
}
