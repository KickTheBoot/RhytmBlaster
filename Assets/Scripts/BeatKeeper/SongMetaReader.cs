using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongMetaReader : MonoBehaviour
{
    public TextAsset songMeta;
    // Start is called before the first frame update
    
    void Start()
    {
        SongMetaList songMetaInJson = JsonUtility.FromJson<SongMetaList>(songMeta.text);

        foreach(SongMeta song in songMetaInJson.songMetas)
        {
            Debug.Log($"Song: {song.SongName}, Tempo: {song.Tempo}, Beats Per Measure: {song.BeatsPerMeasure}");
        }
    }
}
