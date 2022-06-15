using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 4, target.transform.position.z - 6);
        transform.rotation = Quaternion.Euler(30, target.transform.eulerAngles.y, target.transform.eulerAngles.z);
        //transform.rotation = newRotation;
    }
}
