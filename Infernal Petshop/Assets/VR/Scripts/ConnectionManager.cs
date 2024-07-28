using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionManager : MonoBehaviour
{
    public static ConnectionManager Instance;
    public Connection[] connections;
    public float connectionDistance = 0.05f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RefreshConnections()
    {
        connections = FindObjectsOfType<Connection>();
    }
}
