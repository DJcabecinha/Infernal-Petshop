using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BodyPart : MonoBehaviour 
{
    public Connection.ConnectionType myType;
    public Connection myConnection;

    private void Update()
    {
        if (myConnection != null)
        {
            if (Vector3.Distance(myConnection.transform.position, transform.position) > ConnectionManager.Instance.connectionDistance)
            {
                myConnection.Disconnect(this);
                myConnection = null;
            }
            else
            {
                transform.position = myConnection.transform.position;
            }
        }
        else
        {
            foreach (Connection con in ConnectionManager.Instance.connections)
            {
                if (Vector3.Distance(con.transform.position, transform.position) <= ConnectionManager.Instance.connectionDistance)
                {
                    if (con.myConnector == null)
                    {
                        transform.position = con.transform.position;
                        con.Connect(this);
                        myConnection = con;
                    }

                }
            }
        }   
    } 
}
