using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Connect : MonoBehaviour
{
    private BodyPart bodyPart;
    public GameObject shopButton;

    // Update is called once per frame
    void Update()
    {
        bodyPart = GetComponent<BodyPart>();
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            shopButton.SetActive(false);
            bodyPart.ConnectJoint();
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            shopButton.SetActive(true);
            bodyPart.DisconnectJoint();
        }
    }
}
