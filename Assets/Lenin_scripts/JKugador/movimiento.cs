using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour {


   


    private float forwardSpeed = 2.5f;
    private float runSpeed = 7.0f;
    private float TimeToMove = 0.2f;
    private float Timer = 0.0f;
    private float rotationLeft = 180.0f;
    private float rotationRight = 90.0f;
    private float rotationDuration = 0.05f;
    private bool CanJump = false;
    private bool CanRun = false;
    private bool CanMove = true;
    private bool startTimer = false;
    private bool finishRotation = true;
    private Vector3 jump = new Vector3(0.0f, 5.0f, 0.0f);
    private Ray Grounded;
    public RaycastHit hit;
    private Rigidbody rig;
    private Quaternion lookingRight = Quaternion.Euler(0.0f, 90.0f, 0.0f);
    private Quaternion lookingLeft = Quaternion.Euler(0.0f, 270.0f, 0.0f);


    // Use this for initialization
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Grounded = new Ray(transform.position, Vector3.down);

        if (startTimer == true)
        {
            Timer += Time.deltaTime;
        }
        if (Timer >= TimeToMove)
        {
            Timer = 0;
            startTimer = false;
        }


        if (Input.GetKey(KeyCode.D) && startTimer == false && CanMove == true)
        {
            if (transform.rotation.y != rotationRight)
            {
                StartCoroutine(RotateRightOverSeconds(rotationDuration));
                finishRotation = true;

            }
            Move();

        }
        //Left
        else if (Input.GetKey(KeyCode.A) && startTimer == false && CanMove == true)
        {

            if (transform.rotation.y != rotationLeft)
            {
                StartCoroutine(RotateLeftOverSeconds(rotationDuration));
                finishRotation = true;

            }
            Move();
        }

        //Run
        if (Input.GetKey(KeyCode.LeftArrow) && CanMove == true)
        {
            CanRun = true;
        }
        else
        {
            CanRun = false;
        }
        //Jump
        if (Physics.Raycast(Grounded, out hit, .6f))
        {
            CanJump = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && CanJump == true && startTimer == false && CanMove == true)
        {
            rig.velocity = jump;
            CanJump = false;
        }

    }
    //MoveOverTime
    public IEnumerator MoveOverSeconds(Vector3 end, float duration)
    {
        float elapsedTime = 0.0f;

        Vector3 startingPos = gameObject.transform.position;
        while (elapsedTime < duration)
        {
            transform.position = Vector3.Slerp(startingPos, end, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }
    //RotateRight
    public IEnumerator RotateRightOverSeconds(float duration)
    {
        finishRotation = false;
        Quaternion startingRot = transform.rotation;
        float elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(startingRot, lookingRight, (elapsedTime / duration));
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Round(transform.position.z));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.rotation = lookingRight;

    }
    //RotateLeft
    public IEnumerator RotateLeftOverSeconds(float duration)
    {
        finishRotation = false;
        float elapsedTime = 0.0f;
        Quaternion startingRot = transform.rotation;
        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(startingRot, lookingLeft, (elapsedTime / duration));
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Round(transform.position.z));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.rotation = lookingLeft;

    }
    //Move
    public void Move()
    {
        if (CanRun == false && finishRotation == true)
        {
            transform.Translate(new Vector3(0.0f, 0.0f, forwardSpeed) * Time.deltaTime);

        }
        else if (CanRun == true && finishRotation == true)
        {
            transform.Translate(new Vector3(0.0f, 0.0f, runSpeed) * Time.deltaTime);

        }
    }



}