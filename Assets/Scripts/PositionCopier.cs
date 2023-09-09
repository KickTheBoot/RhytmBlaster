using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCopier : MonoBehaviour
{
    //What to follow
    public GameObject target;

    //On no target/target lost, what tag to search for in the new target
    [SerializeField]string targetTag;
    // Start is called before the first frame update

    float ReTargetTime = 0;
    public float ReTargetInterval = 0.5f;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            transform.localPosition = target.transform.position;
        }
        else Retarget();
    }

    void Retarget()
    {
        if(ReTargetTime >= ReTargetInterval)
        {            
            target = GameObject.FindWithTag(targetTag);
            ReTargetTime = 0;
        }
        else ReTargetTime += Time.deltaTime;
    }
}
