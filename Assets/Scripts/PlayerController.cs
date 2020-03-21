using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : MonoBehaviour
{

    Rigidbody playerBody;
    public Transform batController;
    public float degreesPerSecond;
    float swingTime;
    float curSwingTime = 0f;

    // Start is called before the first frame update
    void Start()
    {    
        //swingTime = 360/degreesPerSecond;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            //initial swing
            //curSwingTime = swingTime;
            swingBat();
        }
        else if (Input.GetMouseButton(1)) {
            //continue swing
            swingBat(true);
        }
    }

    void swingBat(bool counter=false){
        //curSwingTime -= Time.deltaTime;
        if (counter) {
            batController.Rotate(0, -degreesPerSecond*Time.deltaTime, 0);
        }
        else{
            batController.Rotate(0, degreesPerSecond*Time.deltaTime, 0);
        }
    }
}
