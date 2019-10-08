using System.Collections.Generic;
using System.Collections;
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
	System.Random RandomGenerator = new System.Random();
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

		Topics = ShuffleList(Topics);
		Topics.ForEach(topic => Debug.Log(topic));

		SetTopic(TopicIndex);
	}

	void OnEnable() => StartCoroutine("SetTopicAfterSeconds");
	void OnDisable() => StopCoroutine("SetTopicAfterSeconds");

	IEnumerator SetTopicAfterSeconds()
	{
		const int waitSeconds = 3;

		while (true)
		{
			yield return new WaitForSeconds(waitSeconds);
			SetTopic(TopicIndex + 1);
		}
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
		if (Input.GetKeyDown("right") || Input.GetKeyDown("space"))
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

	// https://stackoverflow.com/a/1262619
	List<T> ShuffleList<T>(List<T> list)
	{
		int n = list.Count;
		while (n > 1)
		{
			n--;
			int k = RandomGenerator.Next(n + 1);
			var value = list[k];
			list[k] = list[n];
			list[n] = value;
		}
		return list;
	}
}
