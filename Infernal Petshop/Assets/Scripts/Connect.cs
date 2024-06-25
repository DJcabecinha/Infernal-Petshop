using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class Connect : MonoBehaviour
{
    public GameObject instantiat;
  
    public List<BodyPart> bodyParts = new List<BodyPart>();
    public InputActionReference connectInput;
    public InputActionReference disconnectInput;
    void Update()
    {

        if (connectInput.ToInputAction().triggered)
        {
            Debug.Log("PRESSED 1");
            //Instantiate(instantiat, transform.position, Quaternion.identity);
            
            foreach (BodyPart part in bodyParts)
            {
                part.ConnectJoint();
            }
        }
        
         
        if (disconnectInput.ToInputAction().triggered)
        {
            Debug.Log("PRESSED 2");

            //Instantiate(instantiat, transform.position, Quaternion.identity);
            
            foreach (BodyPart part in bodyParts)
            {
                part.DisconnectJoint();
            }
        }
    }
}
