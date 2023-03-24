using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float movingSpeed = 6f;
    [SerializeField] private float rotatingSize = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a")){ // move left
            transform.position += Vector3.left * movingSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d")){ // move right
            transform.position += -Vector3.left * movingSpeed * Time.deltaTime;
        }
        if (Input.GetKey("w")){ // move forward
            transform.position += Vector3.forward * movingSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s")){ // move backward
            transform.position += -Vector3.forward * movingSpeed * Time.deltaTime;
        }
        if (Input.GetKey("r")){ // rotate left based on z
            transform.Rotate(0,0,-rotatingSize * Time.deltaTime);
        }
        if (Input.GetKey("t")){ // rotate right based on z
            transform.Rotate(0,0,rotatingSize * Time.deltaTime);
        }
        if (Input.GetKey("f")){ // rotate front
            transform.Rotate(rotatingSize * Time.deltaTime,0,0);
        }
        if (Input.GetKey("g")){ // rotate back
            transform.Rotate(-rotatingSize * Time.deltaTime,0,0);
        }
        if (Input.GetKey("v")){ // rotate left based on y
            transform.Rotate(0,-rotatingSize * Time.deltaTime,0);
        }
        if (Input.GetKey("b")){ // rotate right based on y
            transform.Rotate(0,rotatingSize * Time.deltaTime,0);
        }
    }
}
