using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake: MonoBehaviour
{
    public bool start = false;
    public AnimationCurve curve;
    public float duration = 1f;
    public GameObject Camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Illusion"))
        {
            StartCoroutine(Shaking());
        }
    }

    public IEnumerator Shaking()
    {
        Vector3 startPosition = Camera.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration) 
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            Camera.transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        Camera.transform.position = startPosition;
    }
}
