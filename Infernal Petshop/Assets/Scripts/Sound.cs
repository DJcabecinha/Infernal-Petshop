using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sound", menuName = "New Sound")]
public class Sound : ScriptableObject
{
    public AudioClip[] clip;
}
