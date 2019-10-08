using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[RequireComponent(typeof(Text))]
public class TopicText : MonoBehaviour
{
	[SerializeField]
	bool ShowIndex = true;

	Text Text;
	List<string> Topics = new List<string>();
	int TopicIndex = 0;

	void Awake()
	{
		Text = GetComponent<Text>();

		var file = new File();
		var contents = file.Read("Data/trello-data-10-7.json");

		foreach (var card in file.GetCards(contents, "Topics 10/11/19"))
		{
			var name = card["name"].Value<string>();
			Topics.Add(name);
		}

		Topics.ForEach(topic => Debug.Log(topic));
		SetTopic(TopicIndex);
	}

	void Update()
	{
		var directionKeyInput = GetDirectionKeyInput();
		if (directionKeyInput != TopicIndex)
			SetTopic(directionKeyInput);
	}

	int GetDirectionKeyInput()
	{
		var index = TopicIndex;
		if (Input.GetKeyDown("right"))
			index++;
		else if (Input.GetKeyDown("left"))
			index--;

		return index;
	}

	void SetTopic(int index)
	{
		if (index >= Topics.Count)
			index = 0;
		else if (index < 0)
			index = Topics.Count - 1;

		TopicIndex = index;
		SetText(ShowIndex ? $"{TopicIndex}: {Topics[TopicIndex]}" : Topics[TopicIndex]);
	}

	void SetText(string text) => Text.text = text;
}
