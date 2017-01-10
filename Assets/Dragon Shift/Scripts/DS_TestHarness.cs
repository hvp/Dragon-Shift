using UnityEngine;
using System.Collections;

public class DS_TestHarness : MonoBehaviour {

    Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        bool jump = Input.GetButtonDown("Jump");
        float forward = Input.GetAxis("Vertical");


        if (jump)
        {
            animator.SetTrigger("Jump");
            
        }

        animator.SetFloat("Speed", forward);

        transform.Translate(Vector3.forward * forward * Time.deltaTime);
    }
}
