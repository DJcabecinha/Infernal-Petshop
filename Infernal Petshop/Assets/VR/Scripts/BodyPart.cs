using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BodyPart : MonoBehaviour 
{
    public Connection.ConnectionType myType;
    public Connection myConnection;
    public CharacterJoint characterJoint;
    public bool test;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && test)
        {
            DisconnectJoint();
            print("A");
        }
        if (Input.GetKeyDown(KeyCode.S) && test)
        {
            print("S");
            ConnectJoint();
        }
    }
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
        print("1");

        if (myConnection == null)
        {
            print("2");

            foreach (Connection con in ConnectionManager.Instance.connections)
            {
                print("3");

                if (Vector3.Distance(con.transform.position, transform.position) <= ConnectionManager.Instance.connectionDistance)
                {
                    print("4");

                    if (con.myConnector == null)
                    {
                        print("5");

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
