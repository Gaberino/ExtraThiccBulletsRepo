using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

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

	Coroutine bloomEffect;
	public float baseBloom;
	float currBloomIntensity;
	public float bloomBurstDur;
	public float minBloomBurst;
	public float maxBloomBurst;
	public float bloomIntensityCap;

	public PostProcessingProfile startingProfile;
	private PostProcessingProfile myProfile;
	// Use this for initialization
	void Start () {
		myProfile = new PostProcessingProfile();
		myProfile = startingProfile;
		this.GetComponent<PostProcessingBehaviour>().profile = myProfile;
		var tempBloomsets = myProfile.bloom.settings;
		tempBloomsets.bloom.intensity = baseBloom;
		myProfile.bloom.settings = tempBloomsets;
		instance = this;
        startPos = transform.position;
        currIntensity = 0;
		currBloomIntensity = 0f;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void AddShake(float intensityModifer){
        Debug.Log("Shook AF");
        if(shakeEffect != null) { StopCoroutine(shakeEffect); }
		shakeEffect = StartCoroutine(shakeCamera(intensityModifer));
	}

	public void BlastBloom(float intensityModifier){
		Debug.Log("Bloom AF");
		if(bloomEffect != null) { StopCoroutine(bloomEffect); }
		bloomEffect = StartCoroutine(bloomBurst(intensityModifier));
	}

	IEnumerator shakeCamera(float intensityMod)
    {
        float startTime = Time.time;
        currIntensity += Random.Range(minIntensity, maxIntensity);
		currIntensity *= intensityMod;
        if(currIntensity > capIntensity) { currIntensity = capIntensity; }
		float startIntensity = currIntensity;
        while(Time.time - startTime < shakeDuration) {
            transform.position = startPos + (Vector3)(Random.insideUnitCircle * currIntensity);
            currIntensity = (1f - ((Time.time - startTime) / shakeDuration)) * startIntensity;
            yield return new WaitForEndOfFrame();
        }
        currIntensity = 0f;
        Camera.main.transform.position = startPos;
        shakeEffect = null;
    }

	IEnumerator bloomBurst(float intensityMod)
	{
		float startTime = Time.time;
		currBloomIntensity += Random.Range(minBloomBurst, maxBloomBurst);
		currBloomIntensity *= intensityMod;
		if(currBloomIntensity > bloomIntensityCap) { currBloomIntensity = bloomIntensityCap;}
		float startIntensity = currBloomIntensity;
		var bloomSettings = myProfile.bloom.settings;
		bloomSettings.bloom.intensity += startIntensity;
		Debug.Log(intensityMod);
		bool firstFrame = true;
		while(Time.time - startTime < bloomBurstDur) {
			if (firstFrame) {
				firstFrame = false;
			}
			else {
				bloomSettings.bloom.intensity = Mathf.Lerp(bloomSettings.bloom.intensity, baseBloom, (Time.time - startTime) / bloomBurstDur);
			}
			myProfile.bloom.settings = bloomSettings;
			yield return new WaitForEndOfFrame();
		}
		currBloomIntensity = 0f;
		myProfile.bloom.settings = startingProfile.bloom.settings;
		bloomEffect = null;
	}
}
