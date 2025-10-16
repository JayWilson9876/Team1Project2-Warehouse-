using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public float openTarget;
    public float closeTarget = 0f;

    public void MoveDoor(float target)
    {
        StartCoroutine(SmoothRotateCoroutine(target)); 
    }

    IEnumerator SmoothRotateCoroutine(float target)
    {
        float timeElapsed = 0f;
        while (timeElapsed < 1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, target, 0), timeElapsed);
            timeElapsed += Time.deltaTime * 0.1f;
            yield return null;
        }

        transform.rotation = Quaternion.Euler(0, target, 0);
    }
}
