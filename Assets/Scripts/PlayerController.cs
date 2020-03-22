using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : MonoBehaviour
{

    Rigidbody playerBody;
    Transform playerTransform;
    public Transform batController;
    public float degreesPerSecond;
    float swingTime;
    public float accelerationRate;
    public float maxSpeed;
    public float deccerlationRate;
    public Camera camera;
    Vector3 prevMousePos;
    public float camSensitivity;

    // Start is called before the first frame update
    void Start()
    {    
        playerBody = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
        prevMousePos = Input.mousePosition;

        // if(!isLocalPlayer)
        // {
        //     camera.enabled = false;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        //bat physics
        if (Input.GetMouseButton(0)) {
            swingBat();
        }
        else if (Input.GetMouseButton(1)) {
            swingBat(true);
        }

        //turning
        turn();

        movement();

        
    }

    void movement(){
        //movement
        Vector3 curSpeed = playerBody.velocity;
        bool keyPressed = false;
        if (Input.GetKey(KeyCode.W)){
            curSpeed = curSpeed + new Vector3(0,0,accelerationRate);
            keyPressed = true;
            Debug.Log(curSpeed);
        }
        if (Input.GetKey(KeyCode.A)){
            curSpeed = curSpeed + new Vector3(-1*accelerationRate,0,0);
            keyPressed = true;
            Debug.Log(curSpeed);
        }
        if (Input.GetKey(KeyCode.D)){
            curSpeed = curSpeed + new Vector3(accelerationRate,0,0);
            keyPressed = true;
            Debug.Log(curSpeed);
        }
        if (Input.GetKey(KeyCode.S)){
            curSpeed = curSpeed + new Vector3(0,0,-1*accelerationRate);
            keyPressed = true;
            Debug.Log(curSpeed);
        }
        if (curSpeed.magnitude > maxSpeed) {
            curSpeed = maxSpeed*curSpeed.normalized;
        }
        if (!keyPressed) {
            curSpeed = curSpeed - deccerlationRate*(curSpeed);
        }
        playerBody.velocity = curSpeed;
    }

    void turn(){
        float deltaCamX = Input.mousePosition.x - prevMousePos.x;
        Debug.Log(deltaCamX);
        // if (deltaCamX > 150) {
            playerTransform.rotation = playerTransform.rotation * Quaternion.Euler(0, deltaCamX*camSensitivity, 0);
        // } 
        prevMousePos = Input.mousePosition;
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
