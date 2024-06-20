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
    public Connection myConnection;
    public Connection.AnimalType animalType;

    public CharacterJoint characterJoint;
    public int myValue;

    public void DisconnectJoint()
    {
        if (myConnection != null)
        {
            Destroy(characterJoint);
            myConnection.Disconnect(this);
            myConnection = null;
        }
    }
    public void ConnectJoint()
    {
        if (myConnection == null)
        {
            foreach (Connection con in ConnectionManager.Instance.connections)
            {
                if (Vector3.Distance(con.transform.position, transform.position) <= ConnectionManager.Instance.connectionDistance)
                {
                    if (con.myConnector == null)
                    {
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
}
