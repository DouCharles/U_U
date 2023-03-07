using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlanchor 
{
    // Start is called before the first frame update
    public static void topLeft(RectTransform uitransform)
    {
         //= uiObject.GetComponent<RectTransform>();

        uitransform.anchorMin = new Vector2(0, 1);
        uitransform.anchorMax = new Vector2(0, 1);
        uitransform.pivot = new Vector2(0, 1);
    }

    public static void topMiddle(RectTransform uitransform)
    {
        //RectTransform uitransform = uiObject.GetComponent<RectTransform>();

        uitransform.anchorMin = new Vector2(0.5f, 1);
        uitransform.anchorMax = new Vector2(0.5f, 1);
        uitransform.pivot = new Vector2(0.5f, 1);
    }


    public static void topRight(RectTransform uitransform)
    {
        //RectTransform uitransform = uiObject.GetComponent<RectTransform>();

        uitransform.anchorMin = new Vector2(1, 1);
        uitransform.anchorMax = new Vector2(1, 1);
        uitransform.pivot = new Vector2(1, 1);
    }

    //------------Middle-------------------
    public static void middleLeft(RectTransform uitransform)
    {
        //RectTransform uitransform = uiObject.GetComponent<RectTransform>();

        uitransform.anchorMin = new Vector2(0, 0.5f);
        uitransform.anchorMax = new Vector2(0, 0.5f);
        uitransform.pivot = new Vector2(0, 0.5f);
    }

    public static void middle(RectTransform uitransform)
    {
        //RectTransform uitransform = uiObject.GetComponent<RectTransform>();

        uitransform.anchorMin = new Vector2(0.5f, 0.5f);
        uitransform.anchorMax = new Vector2(0.5f, 0.5f);
        uitransform.pivot = new Vector2(0.5f, 0.5f);
    }

    public static void middleRight(RectTransform uitransform)
    {
        //RectTransform uitransform = uiObject.GetComponent<RectTransform>();

        uitransform.anchorMin = new Vector2(1, 0.5f);
        uitransform.anchorMax = new Vector2(1, 0.5f);
        uitransform.pivot = new Vector2(1, 0.5f);
    }

    //------------Bottom-------------------
    public static void bottomLeft(RectTransform uitransform)
    {
        //RectTransform uitransform = uiObject.GetComponent<RectTransform>();

        uitransform.anchorMin = new Vector2(0, 0);
        uitransform.anchorMax = new Vector2(0, 0);
        uitransform.pivot = new Vector2(0, 0);
    }

    public static void bottomMiddle(RectTransform uitransform)
    {
        //RectTransform uitransform = uiObject.GetComponent<RectTransform>();

        uitransform.anchorMin = new Vector2(0.5f, 0);
        uitransform.anchorMax = new Vector2(0.5f, 0);
        uitransform.pivot = new Vector2(0.5f, 0);
    }

    public static void bottomRight(RectTransform uitransform)
    {
        //RectTransform uitransform = uiObject.GetComponent<RectTransform>();

        uitransform.anchorMin = new Vector2(1, 0);
        uitransform.anchorMax = new Vector2(1, 0);
        uitransform.pivot = new Vector2(1, 0);
    }
}
