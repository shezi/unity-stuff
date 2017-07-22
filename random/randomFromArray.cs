using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomFromArray : MonoBehaviour
{
    public static object getRandomElementBase(object[] ojectArray)
    {
        if (ojectArray.Length == 0)
        {
            return null;
        }
        else if (ojectArray.Length == 1)
        {
            return ojectArray[0];
        }
        return ojectArray[Random.Range(0, ojectArray.Length - 1)];
    }

    public static Vector3 getRandomElement(Vector3[] ojectArray)
    {
        if (ojectArray.Length == 0)
        {
            return Vector3.zero;
        }
        else if (ojectArray.Length == 1)
        {
            return ojectArray[0];
        }
        return ojectArray[Random.Range(0, ojectArray.Length - 1)];
    }

    public static string getRandomElement(string[] ojectArray)
    {
        return (string)getRandomElementBase(ojectArray);
    }

    public static GameObject getRandomElement(GameObject[] ojectArray)
    {
        return (GameObject)getRandomElementBase(ojectArray);
    }

    public static Transform getRandomElement(Transform[] ojectArray)
    {
        return (Transform)getRandomElementBase(ojectArray);
    }

    public static AudioClip getRandomElement(AudioClip[] ojectArray)
    {
        return (AudioClip)getRandomElementBase(ojectArray);
    }

    public static Sprite getRandomElement(Sprite[] ojectArray)
    {
        return (Sprite)getRandomElementBase(ojectArray);
    }
}
