using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingBG : MonoBehaviour
{
    RawImage _bg;
    [SerializeField] float xSpeed = 0.05f, ySpeed = 0.01f;

    private void OnEnable()
    {
        _bg = GetComponent<RawImage>();
    }

    private void Update()
    {
        // Caching the transform position for reducing calls to the C++ backend of unity.
        Rect cache = _bg.uvRect;
        cache = new Rect(cache.x + xSpeed * Time.deltaTime, cache.y + ySpeed * Time.deltaTime, cache.width, cache.height);
        _bg.uvRect = cache;
    }
}
