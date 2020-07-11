using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
	[Header("Display")]
	public int frameCount;
	public float accumulatedTime;

	[Header("Param")]
	public float refreshFrequency;

	[Header("Config")]
	public TextMeshProUGUI fpsTmp;

	void Update()
	{
		frameCount++;
		accumulatedTime += Time.unscaledDeltaTime;

		if (accumulatedTime < 1f / refreshFrequency)
			return;

		var fps = frameCount / accumulatedTime;
		fpsTmp.SetText($"fps: {fps:0.0}");
		frameCount = 0;
		accumulatedTime = 0f;
	}
}
