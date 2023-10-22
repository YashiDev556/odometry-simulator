using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Odometry : MonoBehaviour
{
    
    public float xcord, zcord, theta, deltaTheta;  //these are going to be the values that the odometry keeps track of.
    public float localX, localZ;
    float averageOrientation, localOrientation, polarR;

    public TextMeshProUGUI odometryInformation;

    public VirtualTrackingWheels virtualTrackingWheels;

    // Update is called once per frame
    void Update()
    {
	
        deltaTheta += (virtualTrackingWheels.deltaL-virtualTrackingWheels.deltaR)/(virtualTrackingWheels.trackingWheelDistanceFromCenter*2);
		averageOrientation = theta + (deltaTheta/2);

		theta += deltaTheta;

         
	
      
        if(deltaTheta == 0) {
	       localX = virtualTrackingWheels.deltaS; 
	       localZ = virtualTrackingWheels.deltaR; 
        } else {

           localX = 2*Mathf.Sin(deltaTheta/2)*((virtualTrackingWheels.deltaS/deltaTheta) + virtualTrackingWheels.trackingWheelDistanceFromCenter);  
       	   localZ = 2*Mathf.Sin(deltaTheta/2)*((virtualTrackingWheels.deltaR/deltaTheta) + virtualTrackingWheels.trackingWheelDistanceFromCenter);

		}	

		if(localX == 0) {

	    
	    	polarR = localZ;
	    	localOrientation = Mathf.PI/2;

		} else {
	
			polarR = Mathf.Sqrt(localX*localX + localZ*localZ);
			if (localX < 0) { 

				polarR = -polarR;
			}
			localOrientation = Mathf.Atan(localZ/localX);

		}

		localOrientation -= averageOrientation;
		xcord += polarR*Mathf.Cos(localOrientation); 
		zcord += polarR*Mathf.Sin(localOrientation);
    	odometryInformation.text = "Odometry Calculated Position: \n Theta: " + theta*(180/Mathf.PI) + "\n x: " + xcord + "\n z: " + zcord;
    	deltaTheta = 0;   
    }
}
