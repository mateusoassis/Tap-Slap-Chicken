﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkinSwipeScreen : MonoBehaviour, IDragHandler, IEndDragHandler {
    private Vector3 panelLocation;
    public float threshold = 0.2f;
    public float easing = 0.5f;
    int currentChild = 0;

    // Start is called before the first frame update
    void Start()
    {
        panelLocation = transform.position;
    }

    public void OnDrag(PointerEventData data)
    {
        float difference = data.pressPosition.x - data.position.x;
        transform.position = panelLocation - new Vector3(difference, 0, 0);
    }

    public void OnEndDrag(PointerEventData data)
    {
        float percentage = (data.pressPosition.x - data.position.x) / threshold;
        if(Mathf.Abs(percentage ) >= threshold)
        {
            Vector3 nextLocation = panelLocation;
            if(percentage > 0 && currentChild < 2)
            {
                nextLocation += new Vector3(-Screen.width, 0, 0);
                currentChild++;
            } else if (percentage < 0 && currentChild > 0)
            {
                nextLocation += new Vector3(Screen.width, 0, 0);
                currentChild--;
            }
            StartCoroutine(SmoothMove(transform.position, nextLocation, easing));
            panelLocation = nextLocation;

        } else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
    }

    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while(t <= 1.0f)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null; 
        }
    }
}
