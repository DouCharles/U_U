using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisiondetect : MonoBehaviour
{
    public bool Iscollide = false;
    public Vector3 collided_pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.transform.name);
        if (SceneManager.GetActiveScene().name == "SmallRoom")
        {
            Iscollide = true;
            collided_pos = transform.position;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (SceneManager.GetActiveScene().name == "SmallRoom")
        {
            Iscollide = false;
        }
    }
}
