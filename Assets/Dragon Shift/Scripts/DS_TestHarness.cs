using UnityEngine;
using System.Collections;

public class DS_TestHarness : MonoBehaviour
{

    Animator animator;
    [Range(1f, 5f)]
    public float WalkSpeed;
    [Range(1f, 2f)]
    public float StrafSpeed;
    [Range(70f, 120f)]
    public float roationSpeedX;
    [Range(70f, 120f)]
    public float roationSpeedY;


    private Transform camPiv;
    private Transform groundcheck;
    // Use this for initialization
    void Start()
    {
        camPiv = GameObject.Find("CamPiv").transform;
        groundcheck = GameObject.Find("GroundCheck").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        bool jump = Input.GetButtonDown("Jump");
        bool attack = Input.GetButtonDown("Fire2");

        float defending = Input.GetAxis("LeftTrigger");

        float forward = Input.GetAxis("Vertical");
        float straf = Input.GetAxis("Horizontal");

        float lookX = Input.GetAxis("RightStickX");
        float lookY = Input.GetAxis("RightStickY");

        if (jump)
        {
            Jump();
        }

        if(attack)
        {
            Attack();
        }

        animator.SetFloat("Defending", defending);

        Debug.Log(defending);
           
        animator.SetFloat("Speed", forward * WalkSpeed);

        transform.Translate(Vector3.right * straf * Time.deltaTime);
 
        camPiv.Rotate(Vector3.right * lookY * roationSpeedY * Time.deltaTime);
        transform.Rotate( Vector3.up * lookX * roationSpeedX * Time.deltaTime); // I think i've labbled them wrong.

        if (forward > 0.1f)
        {
            transform.Translate(Vector3.forward * forward * WalkSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * forward *  Time.deltaTime);
        }
    }
     
    void Attack()
    {
        animator.SetTrigger("Attack1");
    }
    void Jump()
    {
        int layerMask = 1 << 8;

        // Does the ray intersect any objects which are in the player layer.
       // var distance = Vector3.Distance(transform.position, groundcheck.position); // can cache this.

     //   if (Physics.Raycast(transform.position, Vector3.up *-1,distance, layerMask))
            animator.SetTrigger("Jump");
        
        
    }
}
