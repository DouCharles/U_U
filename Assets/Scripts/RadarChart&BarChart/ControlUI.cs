using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControlUI : MonoBehaviour
{
    [SerializeField] private Button CloseButton;
    [SerializeField] private GameObject Close_UI;
    [SerializeField] private GameObject Open_UI;
    // Start is called before the first frame update
    void Start()
    {

        CloseButton.onClick.AddListener(UIController);         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UIController()
    {
        if (Close_UI != null)
        {
            Close_UI.SetActive(false);
        }
        if (Open_UI != null)
        {
            Open_UI.SetActive(true);
        }
    }
}
