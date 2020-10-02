using UnityEngine;
using System.Collections;

public static class FloatUtils
{
    public static float Lerp(float from, float to, float lerp)
    {
        return (to - from) * lerp + from;
    }
}