
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float Sprintspeed = 10;
    private GameObject obj_;
    private Rigidbody rb;
    private Vector2 camturn;
    public Camera cam;

    private CharacterController controller;
    public LayerMask groundMask;
    private float groundDistance = .4f;
    public Transform groundCheck;

    Vector3 velocity;
    bool isGrounded;

    public float Gravity;
    public float jumpHeight;

    private float slidespeed;
    private float slidedecrease;

    bool slide = false;
    float turnboundsR;
    float turnboundsL;

    [SerializeField]
    private WeaponsManager weaponsManager;


    private SpecialMoves SM;

    public float dashspeed;
    private bool dash;
    private Vector3 dashend;
    private Vector3 dashstart;
    private float timetaken;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        dash = false;
        Cursor.lockState = CursorLockMode.Locked;
        obj_ = GetComponent<GameObject>();
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        controller = GetComponent<CharacterController>();
        SM = GetComponent<SpecialMoves>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonUp("Crouch"))
        //{
        //    slide = false;
        //}
        if (dash)
        {
            return;
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -3f;
        }

        if (Input.GetButton("Fire1") && weaponsManager.ActiveGun != null)
        {
            print("Fire button has been hit AND there is an activeGun");
            weaponsManager.ActiveGun.Fire();
        }

        //Basic Camera stuff
        camturn.x -= Input.GetAxisRaw("Mouse Y"); //Fuck ass unity stuff on backend but it will work line normal
        camturn.y += Input.GetAxisRaw("Mouse X");
        //This makes it so y doesnt go exponential
        
        //if(camturn.y > 360f && Input.GetButton("Crouch") == false)
        //{
        //    camturn.y -= 360f;
        //}
        //if(camturn.y < -360)
        //{
        //    camturn.y += 360;
        //}
        camturn.x = Mathf.Clamp(camturn.x, -75, 75);
        
        //if (Input.GetButton("Crouch") == false)
        //{
        //    cam.transform.eulerAngles = new Vector3(camturn.x, camturn.y, 0);
        //    transform.localRotation = Quaternion.Euler(camturn.y * Vector3.up);
        //}
        //else
        //{
            //Debug.Log("Cam.y: " + camturn.y);

            //if (!slide)
            //{
            //    turnboundsR = camturn.y + 60;
            //    turnboundsL = camturn.y - 60;
            //    slide = true;
            //}

            //camturn.x = Mathf.Clamp(camturn.x, -75, 75);
            //camturn.y = Mathf.Clamp(camturn.y, turnboundsL, turnboundsR);
            //cam.transform.eulerAngles = new Vector3(camturn.x, camturn.y, 0);
            //Debug.Log("crouching");
        //}
        //if (Input.GetButtonUp("Crouch"))
        //{
            camturn.y += Input.GetAxisRaw("Mouse X");
            camturn.x = Mathf.Clamp(camturn.x, -75, 75);
            cam.transform.eulerAngles = new Vector3(camturn.x, camturn.y, 0);
            transform.localRotation = Quaternion.Euler(camturn.y * Vector3.up);
        //}
        ////////
        //if (dash)
        //{
        //    float t = timetaken / duration;
        //    transform.position = Vector3.Lerp(dashstart, dashend, t);
        //    timetaken += Time.deltaTime;
        //    if (timetaken > duration)
        //    {
        //        timetaken = 0;
        //        controller.enabled = true;
        //        dash = false;
        //    }
        //}
        //else
        //{
            //Player movement
            //Vars that make stuff easier to read and cause brakeys did in the tutorial and its become habit for me
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            //if (Input.GetButton("Sprint"))
            //{
            //    controller.Move(move * Sprintspeed * Time.deltaTime);
            //    cam.fieldOfView = 70;
            //    Debug.Log("sprinting");
            //}
            //else if(Input.GetButton("Crouch"))
            //{
            //    cam.transform.localPosition = Vector3.up * 0.735f;
            //    Vector3 slide = (transform.forward * Sprintspeed) + (transform.right * x * .1f);
            //    //cam.transform.localPosition = Vector3.up * -0.4f;
            //    controller.Move(slide * Time.deltaTime);
            //}
            //else
            //{
            controller.Move(move * speed * Time.deltaTime);
            cam.fieldOfView = 60;
            //}

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                Debug.Log("Jump");
                velocity.y += Mathf.Sqrt(jumpHeight * -2f * Gravity);
            }
            if (SM.sword)
            {
                if (Input.GetButtonDown("Dash"))
                {
                    Debug.Log("DASH!");
                    controller.enabled = false;
                //dashstart = transform.position;
                //dashend = move * dashspeed + transform.position;
                    StartCoroutine(SwordDash(x,z));
                    dash = true;
                    Debug.DrawRay(transform.position, dashend, Color.red, 5f);
                    dash = true;
                    //controller.Move(move * dashspeed);
                }
            }

            velocity.y += Gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        //}
    }

    private IEnumerator SwordDash(float x, float z)
    {

        rb.velocity = (transform.right * x + transform.forward * z) * dashspeed;

        yield return new WaitForSeconds(duration);
        dash = false;
        controller.enabled = true;
    }
}
