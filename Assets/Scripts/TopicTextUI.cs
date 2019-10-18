using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TopicTextUI : MonoBehaviour
{
	public Topics Topics { get; set; }
	public float? TopicInterval { get; set; }
	[SerializeField] Color[] Colors = default;
	int ColorIndex = 0;
	Color BackgroundColor { set => Camera.main.backgroundColor = value; }

	void OnEnable() => StartCoroutine(nameof(SetTopicAfterSeconds));
	void OnDisable() => StopCoroutine(nameof(SetTopicAfterSeconds));

	void Awake()
	{
		var shuffleBox = new ShuffleBox();
		var shuffledList = shuffleBox.Shuffle(Colors.ToList());
		Colors = shuffledList.ToArray();
	}

	IEnumerator SetTopicAfterSeconds()
	{
		ChangeTopic(1);

		while (true)
		{
			yield return new WaitForSeconds(seconds: TopicInterval ?? 3);
			ChangeTopic(1);
		}
	}

	void Update() => HandleKeyboardInput();

	void HandleKeyboardInput()
	{
		if (Input.GetKeyDown("right") || Input.GetKeyDown("space"))
			ChangeTopic(1);
		else if (Input.GetKeyDown("left"))
			ChangeTopic(-1);
	}

	void ChangeTopic(int direction)
	{
		if (direction > 0)
			Topics.NextTopic();
		else
			Topics.PreviousTopic();

		GetComponent<Text>().text = Topics.CurrentTopic;
		NextColor();
	}

	void NextColor()
	{
		ColorIndex++;
		if (ColorIndex > Colors.Length - 1)
			ColorIndex = 0;

		BackgroundColor = Colors[ColorIndex];
	}
}
