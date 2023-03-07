using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dragTest : MonoBehaviour
{
    float distanceFromCamera;
    Rigidbody r;
    // Start is called before the first frame update
    void Start()
    {
        
        r = this.transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnMouseEnter()
    {
        distanceFromCamera = Vector3.Distance(this.transform.position, Camera.main.transform.position);
    }
    private void OnMouseDrag()
    {

        if (SceneManager.GetActiveScene().name == "SmallRoom" || SceneManager.GetActiveScene().name == "BigRoom")
        {
            Vector3 pos = Input.mousePosition;
            pos.z = distanceFromCamera;
            pos = Camera.main.ScreenToWorldPoint(pos);
            r.velocity = (pos - this.transform.position) * 10;
        }
    }
    private void OnMouseExit()
    {
        if (SceneManager.GetActiveScene().name == "SmallRoom" || SceneManager.GetActiveScene().name == "BigRoom")
        {
            r.velocity = Vector3.zero;
        }
    }
}
