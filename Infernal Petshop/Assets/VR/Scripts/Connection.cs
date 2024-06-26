using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Connection : MonoBehaviour
{
    private GameObject bloodEffect;
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

    private BodyPart myConnector;
    private MainBody myBody;
  
    public BodyPart MyConnector { get { return myConnector; } }   

    private void Start()
    {
        myBody = GetComponentInParent<MainBody>();
        bloodEffect = Resources.Load("Blood").GameObject();
    }
    public void Connect(BodyPart connector)
    {
        myConnector = connector;
        myBody.Add(connector);
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        AudioManager.instance.PlaySFX("Flesh", null);


        if (connector.bodyPartType == Connection.ConnectionType.head)
        {
            if (animalType == Connection.AnimalType.cat)
            {

            }
            if (animalType == Connection.AnimalType.reptile)
            {

            }
        }
                        
    }
    public void Disconnect(BodyPart connector)
    {
        if (myConnector == connector)
        {
            myConnector = null;
            myBody.Remove(connector);
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
            AudioManager.instance.PlaySFX("Flesh", null);


            if (connector.bodyPartType == Connection.ConnectionType.head)
            {
                if (animalType == Connection.AnimalType.cat)
                {

                }
                if (animalType == Connection.AnimalType.reptile)
                {

                }
            }

        }
    }

}
