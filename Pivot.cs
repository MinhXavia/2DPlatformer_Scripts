using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{    
    public GameObject myPlayer;

    void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //                                                                        the position of the Arm pivot

        difference.Normalize(); //make it's both between zero and one

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // calculate the angle (radians)                            convert to degrees  

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);   //returns a rotatio
        //https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html   


        if (rotationZ < -90 || rotationZ > 90)    //the Arm is other side of the body
        {
            if (myPlayer.transform.eulerAngles.y == 0)  //the player is still facing to the right
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ); //flip the Arm on the x-axis(180)
            }
            else if (myPlayer.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, rotationZ);
            }
        }                                                        
    }  
}
