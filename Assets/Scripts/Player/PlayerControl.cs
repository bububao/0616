using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;
    public float gravity;
    public float maxSpeed;
    Rigidbody rb;
    public GameObject planet;
    private void Awake()
    {
        rb=GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            moveSpeed = 1;
            Input.gyro.enabled = true;
            gravity = 0.2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        if (SystemInfo.supportsGyroscope)
        {
            GyroMoving(Input.gyro.attitude);
            Quaternion phoneGyro = Input.gyro.attitude;
            //transform.rotation = new Quaternion(phoneGyro.x, phoneGyro.z, phoneGyro.y, phoneGyro.w);
            //transform.rotation = new Quaternion(transform.rotation.x, -phoneGyro.z, transform.rotation.z, phoneGyro.w);
            Debug.Log(Input.gyro.attitude);
        }
        else
        {
            CheckMoving();
        }
        CheckGravity();
    }
    void CheckGravity()
    {
        rb.velocity += ((planet.transform.position - transform.position).normalized*gravity);
        transform.rotation = Quaternion.Slerp(transform.rotation
            , Quaternion.FromToRotation(transform.up, (transform.position - planet.transform.position).normalized) * transform.rotation,rotateSpeed * Time.deltaTime);
    }
    void GyroMoving(Quaternion gyro)
    {
        if (rb.velocity.magnitude <= maxSpeed)
        {
            rb.velocity += transform.forward * gyro.x * moveSpeed;
            rb.velocity += transform.right * -gyro.y * moveSpeed;
        }
        else
        {
            rb.velocity -= transform.forward * gyro.x * moveSpeed;
        }
    }
    void CheckMoving()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward*moveSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            rb.velocity -= new Vector3(rb.velocity.x, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = transform.right * -moveSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity -= new Vector3(0, rb.velocity.y, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = transform.forward * -moveSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            rb.velocity -= new Vector3(rb.velocity.x, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * moveSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity -= new Vector3(0, rb.velocity.y, 0);
        }
        //if(!Input.GetKey(KeyCode.A)&& !Input.GetKey(KeyCode.W)&& !Input.GetKey(KeyCode.D)&& !Input.GetKey(KeyCode.S))
        //{
        //    StopMoving();
        //}
    }
    void StopMoving()
    {
        rb.velocity = Vector3.zero;
        Debug.Log("Stop");
    }
}

