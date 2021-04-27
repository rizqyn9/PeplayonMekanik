using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStartButton : MonoBehaviour
{
    public float CountDown;
    public float DefaultCountDown;
    public float TweenTime;

    private void Start()
    {
        DefaultCountDown = CountDown;
    }

    private IEnumerator Tween()
    {
        LeanTween.scale(gameObject, new Vector3(1.2f, 1.2f, 1), TweenTime)
        .setEasePunch();
        yield return new WaitForSeconds(TweenTime);
    }

    private void Update()
    {
        CountDown -= Time.deltaTime;
        if (CountDown <= 0)
        {
            StartCoroutine(Tween());
            CountDown = DefaultCountDown;
        }
    }
}