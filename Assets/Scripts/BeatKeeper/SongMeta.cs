using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SongMeta
{
    public string SongName;
    public float Tempo;
    public int BeatsPerMeasure;
}

public class SongMetaList
{
    public List<SongMeta> songMetas;
}
