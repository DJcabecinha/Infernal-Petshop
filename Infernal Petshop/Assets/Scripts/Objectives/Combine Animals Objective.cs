using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineAnimalsObjective : Objective
{
    public Connection.AnimalType firstType;
    public Connection.AnimalType secondType;

    private bool firstTypeDone;
    private bool secondTypeDone;

    public override bool CheckObjective(int currency, Connection.AnimalType[] presentAnimals, Connection.ConnectionType[] presentParts)
    {
        foreach(Connection.AnimalType type in presentAnimals)
        {
            if (type == firstType) firstTypeDone = true;
            if (type == secondType) secondTypeDone = true;
        }
        if(firstTypeDone && secondTypeDone)
        {
            return true;
        }

        else
        {
            firstTypeDone = false;
            secondTypeDone = false;
            return false;
        }
    }

}
