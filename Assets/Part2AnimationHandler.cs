using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Part2AnimationHandler : MonoBehaviour
{
    Animator animator;
    Rigidbody rigbody;
    Animation mocap;
    //public Animation jump;

    public float moveSpeed = 3f;
    public float rotationSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigbody = GetComponent<Rigidbody>();
        mocap = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        //controls rotation
        if (Input.GetKey(KeyCode.Q))
        {
            Rotation(-1);
        }
        if (Input.GetKey(KeyCode.E))
        {
            Rotation(1);
        }

        //calls the movement function
        Movement();

        //fires the gun when LMB is held
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("Shoot", true);
        } else
        {
            animator.SetBool("Shoot", false);
        }

        //controls the jump animation
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetLayerWeight(2, 1);
            //jump.Play();
        }
        else
        {
            animator.SetLayerWeight(2, 0);
        }

        //Press M to play the Mocap Animation
        if (Input.GetKeyDown(KeyCode.M))
        {

            animator.SetLayerWeight(4, 1);
            animator.applyRootMotion = true;
            animator.SetTrigger("Mocap");
        }

    }

    //moves the character
    void Movement()
    {
        float walkDir = Input.GetAxis("Vertical") * moveSpeed;
        float strafeDir = Input.GetAxis("Horizontal") * moveSpeed;

        animator.SetFloat("Forward", Input.GetAxis("Vertical"));
        animator.SetFloat("Strafe", Input.GetAxis("Horizontal"));

        walkDir *= Time.deltaTime;
        strafeDir *= Time.deltaTime;

        transform.Translate(strafeDir, 0, walkDir);

    }
    //rotates the character
    void Rotation(float strength)
    {
        float rotation = strength * rotationSpeed;

        rotation *= Time.deltaTime;

        transform.Rotate(0, rotation, 0);
        //rigbody.rotation.Set(rigbody.rotation.x, rotation, rigbody.rotation.z, rigbody.rotation.w);
    }


}
