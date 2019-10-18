using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TopicTextUI : MonoBehaviour
{
	public Topics Topics { get; set; }

	void OnEnable() => StartCoroutine(nameof(SetTopicAfterSeconds));
	void OnDisable() => StopCoroutine(nameof(SetTopicAfterSeconds));

	IEnumerator SetTopicAfterSeconds()
	{
		SetText();

		const int waitSeconds = 3;
		while (true)
		{
			yield return new WaitForSeconds(waitSeconds);

			Topics.NextTopic();
			SetText();
		}
	}

	void Update() => HandleKeyboardInput();

	void HandleKeyboardInput()
	{
		if (Input.GetKeyDown("right") || Input.GetKeyDown("space"))
		{
			Topics.NextTopic();
			SetText();
		}
		else if (Input.GetKeyDown("left"))
		{
			Topics.PreviousTopic();
			SetText();
		}
	}

	void SetText() => GetComponent<Text>().text = Topics.CurrentTopic;
}
