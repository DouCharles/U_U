using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class click_show_code: MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject code;

    void Start()
    {

        //code = GameObject.Find("treasure code");
        if (SceneManager.GetActiveScene().name != "SmallRoom" && SceneManager.GetActiveScene().name != "MediumRoom" && SceneManager.GetActiveScene().name != "BigRoom")
        {
            code.SetActive(false);
        }
        else
        {
            code.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Input.GetMouseButtonDown(0)&&Physics.Raycast(ray,out hit))
        {
            ishit = true;
            Debug.Log(hit.transform.name);
            chest_open.SetActive(true);
            chest_close.SetActive(false);
            ishit = false;
        }*/
        
    }
    private void OnMouseDown()
    {
        if (SceneManager.GetActiveScene().name != "SmallRoom" && SceneManager.GetActiveScene().name != "MediumRoom" && SceneManager.GetActiveScene().name != "BigRoom")
        {
            code.SetActive(true);
            if (name.Contains("CHEST"))
            {
                code.transform.GetChild(8).gameObject.SetActive(false);
                code.transform.GetChild(9).gameObject.SetActive(false);
            }
        }
    }
}
