using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolRet : MonoBehaviour
{
    private RectTransform Reticle;
    private bool shooting = false;

    public float basesize;
    public float maxsize;
    public float speed;
    private float currentsize;
    // Start is called before the first frame update
    void Start()
    {
        Reticle = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shooting)
        {
            currentsize = Mathf.Lerp(currentsize, maxsize, Time.deltaTime * speed);

        }
        else
        {
            currentsize = Mathf.Lerp(currentsize, basesize, Time.deltaTime * speed);
        }
        Reticle.sizeDelta = new Vector2 (currentsize, currentsize);
    }

    public void toggleshoot()
    {
         shooting = !shooting;
    }
}
