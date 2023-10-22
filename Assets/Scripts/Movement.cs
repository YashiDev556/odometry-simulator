using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Movement : MonoBehaviour
{


    public Transform robot;

    public float movementSpeed = 0.1f;

    public float rotationSpeed = 20f;

    float x, y, z;

    float speed;

    public TextMeshProUGUI actualInformation;

    public float rotationRadians;
    float rot;


    void Update()
    {

        x = robot.position.x;
        y = robot.position.y;
        z = robot.position.z;


        rot = robot.rotation.eulerAngles.y;

        rotationRadians = rot * (Mathf.PI/180);


        speed = movementSpeed*Time.deltaTime;
        
    

        if (Input.GetKey(KeyCode.W))
        { 
            robot.position = new Vector3(x+speed*Mathf.Sin(rotationRadians), y, z+speed*Mathf.Cos(rotationRadians));
        }
        if (Input.GetKey(KeyCode.A))
        { 
            robot.position = new Vector3(x-speed*Mathf.Cos(rotationRadians), y, z+speed*Mathf.Sin(rotationRadians));
        }
        if (Input.GetKey(KeyCode.S))
        { 
            robot.position = new Vector3(x-speed*Mathf.Sin(rotationRadians), y, z-speed*Mathf.Cos(rotationRadians));
        }
        if (Input.GetKey(KeyCode.D))
        { 
            robot.position = new Vector3(x+speed*Mathf.Cos(rotationRadians), y, z-speed*Mathf.Sin(rotationRadians));
        }

        if (Input.GetKey(KeyCode.R))
        {
            robot.Rotate(0, rotationSpeed*Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.L))
        {
            robot.Rotate(0, -rotationSpeed*Time.deltaTime, 0);
        }


        actualInformation.text = "Actual Information: \n X: " + x + "\n Z: " + z + "\n Theta: " + rot;


    }
}
