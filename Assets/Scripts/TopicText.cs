using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[RequireComponent(typeof(Text))]
public class TopicText : MonoBehaviour
{
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
		if (Input.GetKeyDown("right"))
			TopicIndex++;
		else if (Input.GetKeyDown("left"))
			TopicIndex--;

		if (TopicIndex >= Topics.Count)
			TopicIndex = 0;
		else if (TopicIndex < 0)
			TopicIndex = Topics.Count - 1;

		SetTopic(TopicIndex);
	}

	void SetTopic(int index) => SetText($"{TopicIndex}: {Topics[TopicIndex]}");
	void SetText(string text) => Text.text = text;
}
