using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection : MonoBehaviour
{
    public enum ConnectionType
    {
        legs,
        arms,
        head,
        tail,
        wings,
    }
    public ConnectionType connectionType;
    public BodyPart myConnector;

    public void Connect(BodyPart connector)
    {
        myConnector = connector;
    }
    public void Disconnect(BodyPart connector)
    {
        if (myConnector == connector) myConnector = null;
    }

}
