using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TopicTextUI : MonoBehaviour
{
	Text Text;
	public Topics Topics { private get; set; }

	void Awake() => Text = GetComponent<Text>();

	void OnEnable()
	{
		StartCoroutine(nameof(SetTopicAfterSeconds));
	}

	void OnDisable() => StopCoroutine(nameof(SetTopicAfterSeconds));

	IEnumerator SetTopicAfterSeconds()
	{
		const int waitSeconds = 3;
		Debug.Log("start yah boi");

		while (true)
		{
			yield return new WaitForSeconds(waitSeconds);
			Topics.NextTopic();
		}
	}

	void Update()
	{
		HandleKeyboardInput();

		if (Text.text != Topics.CurrentTopic)
			SetText();
	}

	void HandleKeyboardInput()
	{
		if (Input.GetKeyDown("right") || Input.GetKeyDown("space"))
			Topics.NextTopic();
		else if (Input.GetKeyDown("left"))
			Topics.PreviousTopic();
	}

	void SetText() => Text.text = Topics.CurrentTopic;
}
