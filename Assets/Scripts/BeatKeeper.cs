using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class BeatKeeper : MonoBehaviour
{
    public static BeatKeeper instance;
    private AudioSource m_audioSource;
    public Song song;

    public float timeInBeats
    {
        get
        {   
            return m_audioSource.time * (song.tempo/60);
        }
        set
        {
            m_audioSource.time = value * (60/song.tempo);
        }
    }

    public void Play()
    {
        if(m_audioSource)
        {
            if(m_audioSource.clip != song.clip)
            {
                m_audioSource.clip = song.clip;
            }
            m_audioSource.Play();
        }
    }

    void awake()
    {
        if(!instance)
        {
            instance = this;
        }

    }

    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        Play();
    }

    void OnGUI()
    {
        GUILayout.Label(ToString());
    }

    public override string ToString()
    {
        string output = $"Time:\t{m_audioSource.time}\nBeat:\t{timeInBeats}\nMeasure:\t{timeInBeats/song.beatsPerMeasure}";
        return output;
    }

}
