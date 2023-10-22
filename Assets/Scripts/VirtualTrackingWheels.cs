using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class VirtualTrackingWheels : MonoBehaviour
{
    
    public Movement robotMovement;

    public float trackingWheelDistanceFromCenter = 2f;


    public float virtualEncoderL, virtualEncoderR, virtualEncoderS;

    public float deltaL, deltaR, deltaS;

    public TextMeshProUGUI encoderText;
    
    void Update()
    {
		StartCoroutine(encoderLoop());
    }


    IEnumerator encoderLoop()
    {
        
        
    	deltaL = 0;
		deltaR = 0;
		deltaS = 0;
	if (Input.GetKey(KeyCode.W))
	{ 
	    virtualEncoderL += robotMovement.movementSpeed*Time.deltaTime;
	    virtualEncoderR += robotMovement.movementSpeed*Time.deltaTime;
	    deltaL += robotMovement.movementSpeed*Time.deltaTime;
	    deltaR += robotMovement.movementSpeed*Time.deltaTime;

	}

	if (Input.GetKey(KeyCode.S))
	{ 
	    virtualEncoderL -= robotMovement.movementSpeed*Time.deltaTime;
	    virtualEncoderR -= robotMovement.movementSpeed*Time.deltaTime;
	    deltaL += -robotMovement.movementSpeed*Time.deltaTime;
	    deltaR += -robotMovement.movementSpeed*Time.deltaTime;
	}

	if (Input.GetKey(KeyCode.A))
	{ 
	    virtualEncoderS -= robotMovement.movementSpeed*Time.deltaTime;
	    deltaS += -robotMovement.movementSpeed*Time.deltaTime;
	}

	if (Input.GetKey(KeyCode.D))
	{ 
	    virtualEncoderS += robotMovement.movementSpeed*Time.deltaTime;
	    deltaS += robotMovement.movementSpeed*Time.deltaTime;
	}


	if (Input.GetKey(KeyCode.R))
	{
	    virtualEncoderR -= (2*Mathf.PI)*(trackingWheelDistanceFromCenter)*(robotMovement.rotationSpeed/360)*Time.deltaTime;
	    virtualEncoderS -= (2*Mathf.PI)*(trackingWheelDistanceFromCenter)*(robotMovement.rotationSpeed/360)*Time.deltaTime;
	    virtualEncoderL += (2*Mathf.PI)*(trackingWheelDistanceFromCenter)*(robotMovement.rotationSpeed/360)*Time.deltaTime;

	    deltaR += -(2*Mathf.PI)*(trackingWheelDistanceFromCenter)*(robotMovement.rotationSpeed/360)*Time.deltaTime; 
	    deltaS += -(2*Mathf.PI)*(trackingWheelDistanceFromCenter)*(robotMovement.rotationSpeed/360)*Time.deltaTime;
	    deltaL += (2*Mathf.PI)*(trackingWheelDistanceFromCenter)*(robotMovement.rotationSpeed/360)*Time.deltaTime;
	}

	if (Input.GetKey(KeyCode.L))
	{
	    virtualEncoderR += (2*Mathf.PI)*(trackingWheelDistanceFromCenter)*(robotMovement.rotationSpeed/360)*Time.deltaTime;
	    virtualEncoderS += (2*Mathf.PI)*(trackingWheelDistanceFromCenter)*(robotMovement.rotationSpeed/360)*Time.deltaTime;
	    virtualEncoderL -= (2*Mathf.PI)*(trackingWheelDistanceFromCenter)*(robotMovement.rotationSpeed/360)*Time.deltaTime;

	    deltaR += (2*Mathf.PI)*(trackingWheelDistanceFromCenter)*(robotMovement.rotationSpeed/360)*Time.deltaTime;
	    deltaS += (2*Mathf.PI)*(trackingWheelDistanceFromCenter)*(robotMovement.rotationSpeed/360)*Time.deltaTime;
	    deltaL += -(2*Mathf.PI)*(trackingWheelDistanceFromCenter)*(robotMovement.rotationSpeed/360)*Time.deltaTime; 
	}
	encoderText.text = "Encoder Values \n Left: " + virtualEncoderL + "\n Right: " + virtualEncoderR + "\n Back: " + virtualEncoderS;
        yield return null;
    }
}
