using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeCoBuildDoor : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject DisableUI;
    [SerializeField] private GameObject Longterm_UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void  OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            UI.SetActive(true);
            other.GetComponentInChildren<PlayerPerspective>().mouseSensitivity = 1f;
            Longterm_UI.SetActive(false);
        }
            
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UI.SetActive(false);
            other.GetComponentInChildren<PlayerPerspective>().mouseSensitivity = 100f;
            Longterm_UI.SetActive(true);
            DisableUI.SetActive(false);
        }    
    }
}
