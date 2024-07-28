using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class BodyPart : MonoBehaviour 
{
    public Connection.ConnectionType bodyPartType;
    private Connection myConnection;
    public Connection.AnimalType animalType;

    private CharacterJoint characterJoint;
    public int myValue;
    private bool selected;

    private void Start()
    {
        FindObjectOfType<Connect>().bodyParts.Add(this);
    }
    public void DisconnectJoint()
    {
        Debug.Log("Disconnecting");
        if (myConnection != null)
        {
            Debug.Log('2');
            Destroy(characterJoint);
            myConnection.Disconnect(this);
            myConnection = null;
        }
    }
    public void ConnectJoint()
    {
        if (!selected) return;

        Debug.Log("connecting");
        if (myConnection == null)
        {
            Debug.Log('2');
            foreach (Connection con in ConnectionManager.Instance.connections)
            {
                if (Vector3.Distance(con.transform.position, transform.position) <= ConnectionManager.Instance.connectionDistance)
                {
                    Debug.Log('4');
                    if (con.MyConnector == null)
                    {
                        Debug.Log('5');
                        characterJoint = gameObject.AddComponent(typeof(CharacterJoint)) as CharacterJoint;

                        characterJoint.connectedBody = con.gameObject.GetComponent<Rigidbody>();
                        transform.position = con.transform.position;
                        con.Connect(this);
                        myConnection = con;
                    }

                }
            }
        }
    }
    public void Selected(bool condition)
    {
        selected = condition;
    }
}
