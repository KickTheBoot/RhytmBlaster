using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SaapasJalka/BeatKeeper/Song", fileName = "New Song")]
public class Song : ScriptableObject
{
    [Tooltip("The file containing the song")]
    public AudioClip clip;

    [Tooltip("How many beats per minute is the song")]
    public float tempo = 120;

    [Tooltip("How many beats per meaure does the song have")]
    public int beatsPerMeasure = 4;
    
    //the length of a single beat.
    public float beatLength
    {
        get
        {
            return 60/tempo;
        }
    }

}
