using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TopicTextUI : MonoBehaviour
{
	Text Text;
	Topics Topics;

	void Awake()
	{
		Text = GetComponent<Text>();
		Topics = new Topics();
	}

	void OnEnable() => StartCoroutine(nameof(SetTopicAfterSeconds));
	void OnDisable() => StopCoroutine(nameof(SetTopicAfterSeconds));

	IEnumerator SetTopicAfterSeconds()
	{
		const int waitSeconds = 3;

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
