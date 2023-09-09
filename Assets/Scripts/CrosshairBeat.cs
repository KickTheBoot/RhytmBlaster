using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairBeat : MonoBehaviour
{
    float size;
    [SerializeField] float startScale = 0.5f;
    [SerializeField] float endScale = 0.2f;
    // Start is called before the first frame update
    [SerializeField] Color DownBeatColor, BeatColor;
    [SerializeField] Image image;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        size = Mathf.Lerp(startScale,endScale,BeatKeeper.instance.timeInBeats % 1);
        transform.localScale = Vector3.one*size;

        if(BeatKeeper.instance.timeInBeats % BeatKeeper.instance.song.beatsPerMeasure >= BeatKeeper.instance.song.beatsPerMeasure - 1)
        {
            image.color = Color.Lerp(BeatColor, DownBeatColor, BeatKeeper.instance.timeInBeats % 1);
        }
        else
        {
            image.color = BeatColor;
        }

    }
}
