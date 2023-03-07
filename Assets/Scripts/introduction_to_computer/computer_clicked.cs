using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computer_clicked : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject terminal;
    void Start()
    {

    }

    private void OnMouseDown()
    {
        print("mouse");
        terminal.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
