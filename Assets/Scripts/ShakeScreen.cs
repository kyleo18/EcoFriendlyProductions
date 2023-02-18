using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScreen : MonoBehaviour
{

    public bool start = false;
    public AnimationCurve shakeCurve;
    public float duration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shake());
        }
    }

    IEnumerator Shake()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float Strength = shakeCurve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * Strength;
        }

        transform.position = startPosition;
        return null;
    }
}
