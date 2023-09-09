using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class signExtension
{
    public static float sign(this float value)
    {
        return value >= 0 ? 1 : -1;
    }
}
