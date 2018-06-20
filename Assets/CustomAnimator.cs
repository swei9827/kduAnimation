using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomAnimator : MonoBehaviour {

	[SerializeField] int curFrame = 0;
	[SerializeField] int fps = 30;
	[SerializeField] int rowCount = 2;
	[SerializeField] int colCount = 8;

	float spritesWidth = 0f;
	Renderer rend;
	Vector2 offset = Vector2.zero;
	float timeBetweenFrames;
	float currentTime;


	// Use this for initialization
	void Start () {
		rend = this.GetComponent<Renderer> ();

		// Get sprite
		spritesWidth = 1f/(float)colCount;
	}
	
	// Update is called once per frame
	void Update () {

		timeBetweenFrames = 1f / (float)fps;
		if (currentTime < timeBetweenFrames)
			currentTime += Time.deltaTime;
		else 
		{
			currentTime = 0f;
			curFrame++;
		}

		offset.x = curFrame * spritesWidth;

		rend.material.SetTextureOffset ("_MainTex", offset);
	}
}
