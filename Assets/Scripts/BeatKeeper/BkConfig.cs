using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SaapasJalka/BeatKeeper/Config")]
public class BkConfig : ScriptableObject
{
    public string SongResourcePath = "Sounds/Music";
    public string ListName = "SongList.json";
}
