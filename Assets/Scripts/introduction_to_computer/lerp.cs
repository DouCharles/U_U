using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lerp : MonoBehaviour
{
    // Start is called before the first frame update
    public float smooth;
    private Vector3 newPosition;
    private Vector3 newRotation;
    //public Transform target;
    public float offset = 10;
    private bool isclicked = false, islerping = false;
    private Vector3 cam_position, cam_rotation;
    private Vector3 OriginalPosition, OriginalRotation;//= new Vector3(175.4f, 5, 90);
    [SerializeField] private Vector3 offset_rotation;
    [SerializeField] private Vector3 offset_scale = new Vector3(0.7f, 0.7f, 0.7f);
    private Vector3 now_scale;
    
    //[SerializeField] private float offset_rot_x, offset_rot_y, offset_rot_z;
    private float degreePersecond = 20, time;


    private void Awake()
    {
        //newPosition = transform.position;
        //newRotation = transform.rotation.eulerAngles;
        OriginalPosition = transform.position;
        OriginalRotation = transform.eulerAngles;
        now_scale = this.transform.localScale;
        ///newRotation = transform.eulerAngles;
        //target = Camera.main.transform;
    }
    void Start()
    {
        OriginalPosition = transform.position;
        OriginalRotation = transform.eulerAngles;
        now_scale = this.transform.localScale;
        //Debug.Log(this.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Untagged")
        {
            PositionChange();
        }
        
    }

    void PositionChange()
    {
        //cam_position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 2.0f));
        cam_position = Camera.main.transform.position + Camera.main.transform.forward.normalized * 2;
        cam_rotation = Camera.main.transform.eulerAngles + offset_rotation;



        /*Vector3 positionA = Camera.main.transform.position;
        

        
        Vector3 positionB = new Vector3(175.4f, 5, 85);*/

        if (islerping)
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, smooth * Time.deltaTime);
            //transform.Rotate(new Vector3(0, degreePersecond, 0) * Time.deltaTime);
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, newRotation, Time.deltaTime);
            time += Time.deltaTime;
            if (time >= 1f)
            {
                transform.position = newPosition;
                transform.eulerAngles = newRotation;
                if (isclicked)
                    transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, transform.eulerAngles.z);
                time = 0;
                islerping = false;
            }

        }
        //target.position = transform.position + transform.forward * offset;
        //target.rotation = new Quaternion(0.0f, transform.rotation.y, 0.0f, transform.rotation.w);
    }
    private void OnMouseDown()
    {
        if (!islerping && tag == "Untagged") 
        {
            if (isclicked)
            {

                print("ini");
                isclicked = false;
                islerping = true;
                time = 0;
                newPosition = OriginalPosition;
                //transform.localScale = transform.localScale - new Vector3(0.7f, 0.7f, 0.7f);
                if (this.name.Contains("ClipBoard"))
                    transform.localScale = transform.localScale - offset_scale;
                newRotation = OriginalRotation;
                PlayerPerspective.perspective = true;
                PlayerController.can_move = true;
                transform.localScale = now_scale;

            }
            else
            {
                print("23123");
                PlayerController.can_move = false;
                PlayerPerspective.perspective = false;
                isclicked = true;
                islerping = true;
                time = 0;
                newPosition = cam_position;
                newRotation = cam_rotation;
                //transform.localScale = transform.localScale + offset_scale;
                if (this.name.Contains("ClipBoard"))
                    transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                //transform.localScale = transform.localScale + new Vector3(0.7f, 0.7f, 0.7f);
            }
        }


    }
}
    //ACSII CODE: \n 65:A | 69:E | 75:K | 79:O | 84:T | 87:W | 90:Z\n 97:a | 101:e | 105:i | 108:l | 110:n | 111:o | 114:r 
