using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {

	public static CamControl instance;

    Vector3 startPos;

    public float minIntensity;
    public float maxIntensity;

    public float capIntensity;

    public float currIntensity;
    public float shakeDuration;
    Coroutine shakeEffect;

	public float shakeReturn;
	// Use this for initialization
	void Start () {
		instance = this;
        startPos = transform.position;
        currIntensity = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void AddShake(float intensityModifer){
        Debug.Log("Shook AF");
        if(shakeEffect != null) { StopCoroutine(shakeEffect); }
		shakeEffect = StartCoroutine(shakeCamera(intensityModifer));
	}

	IEnumerator shakeCamera(float intensityMod)
    {
        float startTime = Time.time;
        currIntensity += Random.Range(minIntensity, maxIntensity);
        if(currIntensity < capIntensity) { currIntensity = capIntensity; }
		float startIntensity = currIntensity + intensityMod;
        while(Time.time - startTime < shakeDuration) {
            transform.position = startPos + (Vector3)(Random.insideUnitCircle * currIntensity);
            currIntensity = (1f - ((Time.time - startTime) / shakeDuration)) * startIntensity;
            yield return new WaitForEndOfFrame();
        }
        currIntensity = 0f;
        Camera.main.transform.position = startPos;
        shakeEffect = null;
    }
}
