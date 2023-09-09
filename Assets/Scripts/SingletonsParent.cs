using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Objects with this script won't be destroyed on load
public class SingletonsParent : MonoBehaviour
{
    public static SingletonsParent sp;

    void Start()
    {
        if(!sp)
        {
            sp = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
