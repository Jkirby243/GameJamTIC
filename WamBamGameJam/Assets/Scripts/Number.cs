using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Number : MonoBehaviour
{

    public int value;
    public TMP_Text text;
    private Vector3 endpos;
    private float movespeed = 1f;
    private float lifespan = 4f;
    private float timetaken;
    // Start is called before the first frame update
    void Start()
    {
        //text = GetComponentInChildren<TMP_Text>();
        //move the damage number a bit forward
        transform.position += (-transform.forward * .3f);
        //
        endpos = text.transform.position + Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        timetaken += Time.deltaTime;
        float percentage = timetaken / lifespan;

        text.transform.position = Vector3.Lerp(text.transform.position, endpos, percentage);
        if(text.transform.position == endpos)
        {
            Destroy(gameObject);
        }
    }

    //public void SetText()
    //{
    //    text.text = value.ToString();
    //}
}
