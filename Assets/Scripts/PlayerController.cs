using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update


    //private Rigidbody transformRigidbody;
    public float moving_speed;

    public float jumpSpeed = 2.0f;
    public float gravity = 19.6f;
    private CharacterController controller;
    private Rigidbody rb;
    private Animator anim;
    public string anim_name;
    public static bool can_move = true;
    private float Speed;
    //public Vector3 forceDirection;
    //public float forceAmount;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if (anim_name != null)
        {
            if (anim_name == "AnimationPar")
            {
                if ((Input.GetKey("w") || Input.GetKey("s")) ) 
                {
                    anim.SetInteger(anim_name, 1);
                }
                else 
                {
                    anim.SetInteger(anim_name, 0);
                }
           }
           else if (anim_name == "Blend")
           {
                Speed = new Vector2(horizontal, vertical).sqrMagnitude;
		        if ((Input.GetKey("w") || Input.GetKey("s")) ) 
		        {
                    anim.SetFloat ("Blend", Speed, 0.3f, Time.deltaTime);
                }
                else 
		        {
                    anim.SetFloat ("Blend", Speed, 0.15f, Time.deltaTime);
                }
           }
        }

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {
            move.y = jumpSpeed;
        }
        else
        {
            move.y = 0;
        }
        move.y -= gravity * Time.deltaTime;
        //if (!Istypeing())
        if(can_move)
        {
            controller.Move(move * moving_speed * Time.deltaTime);
        }
    }


    private static bool Istypeing()
    {
        var g = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        //var g = UnityEngine.EventSystems.EventSystem.current.alreadySelecting;
        //print(g.name);
        if (g)
        {
          //  g = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            var input = g.GetComponentInChildren<UnityEngine.UI.InputField>();
            return input && input.isFocused;
        }
        else
        {

            return false;
        }
    }
}
