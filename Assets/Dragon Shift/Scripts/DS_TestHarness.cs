using UnityEngine;
using System.Collections;

public class DS_TestHarness : MonoBehaviour
{

    Animator animator;
    [Range(1f, 2f)]
    public float WalkSpeed;
    [Range(1f, 2f)]
    public float StrafSpeed;
    [Range(70f, 120f)]
    public float roationSpeedX;
    [Range(70f, 120f)]
    public float roationSpeedY;


    private Transform camPiv;
    // Use this for initialization
    void Start()
    {
        camPiv = GameObject.Find("CamPiv").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        bool jump = Input.GetButtonDown("Jump");
        float forward = Input.GetAxis("Vertical");
        float straf = Input.GetAxis("Horizontal");

        float lookX = Input.GetAxis("RightStickX");
        float lookY = Input.GetAxis("RightStickY");

        if (jump)
        {
            animator.SetTrigger("Jump");

        }

        animator.SetFloat("Speed", forward);

        transform.Translate(Vector3.right * straf * Time.deltaTime);
        camPiv.Rotate(Vector3.right * lookY * roationSpeedY * Time.deltaTime);

        Debug.Log(lookX);
        transform.Rotate( Vector3.up * lookX * roationSpeedX * Time.deltaTime);

        if (forward > 0.1f)
        {
            transform.Translate(Vector3.forward * forward * WalkSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * forward *  Time.deltaTime);
        }
    }
}
