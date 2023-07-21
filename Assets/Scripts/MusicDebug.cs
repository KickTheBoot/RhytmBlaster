using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class MusicDebug : MonoBehaviour
{
    [SerializeField]UIDocument doc;
    [SerializeField]AudioSource audioSource;
    DebugElements elements;

    [SerializeField]
    float tempo = 120;
    [SerializeField]
    int beatsPerMeasure;
    float multiplier; 
    // Start is called before the first frame update
    void Start()
    {
        multiplier = tempo/60;
        if(doc)
        {
            elements = new DebugElements()
            {
                sampleLabel = doc.rootVisualElement.Q<Label>(name: "Sample"),
                timeLabel = doc.rootVisualElement.Q<Label>(name:"Time"),
                beatProgress = doc.rootVisualElement.Q<ProgressBar>(name:"Beat")
            };
        }

    }

    // Update is called once per frame
    void Update()
    {
        float timeFromSamples = (float)audioSource.timeSamples/audioSource.clip.frequency;
        if(doc && audioSource)
        {
            elements.sampleLabel.text = $"Samples: {audioSource.timeSamples.ToString()}";
            elements.timeLabel.text = $"Time: {audioSource.time.ToString()},\t {timeFromSamples}";
            float beat = Mathf.Floor(timeFromSamples*multiplier);
            elements.beatProgress.value = (beat%4)+1;
            elements.beatProgress.title = $"Beat: {(beat%4)+1} Bar: {Mathf.Floor(beat/beatsPerMeasure)+1}";
        }
    }
}

public class DebugElements
{
    public Label sampleLabel, timeLabel;
    public ProgressBar beatProgress;
}
