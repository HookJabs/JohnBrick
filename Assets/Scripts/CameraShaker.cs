using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 origPos = transform.position;

        float elapsedShakeTime = 0.0f;
        
        while(elapsedShakeTime < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, origPos.z);

            elapsedShakeTime += Time.deltaTime;

            //before continuing the while loop, wait until next frame is drawn
            yield return null;
        }

        transform.localPosition = origPos;
    }
}
