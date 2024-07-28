using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public UnityEngine.Object[] sfxList;
    public static AudioManager instance;
    public AudioSource sfxSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        sfxList = Resources.LoadAll("SFXClips", typeof(Sound));
    }

    public void PlaySFX(string name, AudioSource source)
    {
        Sound s = (Sound)Array.Find(sfxList, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            if (s.clip.Length > 1)
            {
                if(source == null) sfxSource.PlayOneShot(s.clip[UnityEngine.Random.Range(0, s.clip.Length)]);
                else source.PlayOneShot(s.clip[UnityEngine.Random.Range(0, s.clip.Length)]);

            }
            else
            {
                if (source == null) sfxSource.PlayOneShot(s.clip[0]);
                else source.PlayOneShot(s.clip[0]);

            }
        }
    }
}
