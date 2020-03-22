using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update

    public float maxBallSpeed = 5.0f;

    Rigidbody playerBody;

    void Start()
    {
        playerBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bounceIt();
    }

    void bounceIt()
    {
        if (Mathf.Abs(playerBody.velocity[1]) > maxBallSpeed)
        {
            if (playerBody.velocity[1] > 0)
            {
                playerBody.velocity = new Vector3(playerBody.velocity[0], maxBallSpeed, playerBody.velocity[2]);
            }
            else
            {
                playerBody.velocity = new Vector3(playerBody.velocity[0], -maxBallSpeed, playerBody.velocity[2]);
            }
        }
    }
}
