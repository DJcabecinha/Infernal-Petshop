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

    public enum AnimalType
    {
        cat,
        reptile,
    }
    public AnimalType animalType;

    public BodyPart myConnector;
    public MainBody myBody;

    private void Start()
    {
        myBody = GetComponentInParent<MainBody>();
    }
    public void Connect(BodyPart connector)
    {
        myConnector = connector;
        myBody.Add(connector);
    }
    public void Disconnect(BodyPart connector)
    {
        if (myConnector == connector)
        {
            myConnector = null;
            myBody.Remove(connector);
        }
    }

}
