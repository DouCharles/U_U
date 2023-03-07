using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawer_clicked : MonoBehaviour
{
    // Start is called before the first frame update
    
    private bool isopen = false;
    private void OnMouseDown()
    {
        GameObject draged_item = GameObject.FindGameObjectWithTag("drawer_drag");
        if (!isopen)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.6f);
            draged_item.transform.position = new Vector3(draged_item.transform.position.x, draged_item.transform.position.y, draged_item.transform.position.z + 0.6f);
            isopen = true;

        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.6f);
            draged_item.transform.position = new Vector3(draged_item.transform.position.x, draged_item.transform.position.y, draged_item.transform.position.z - 0.6f);
            isopen = false;
        }
        
        
        //Debug.Log("clicked" + transform.name);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
