using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Topics
{
	int Index = 0;
	readonly List<string> TopicList;
	readonly System.Random RandomGenerator = new System.Random();

	public Topics(string path, string listName)
	{
		var trelloData = new TrelloData();
		trelloData.Load(path);

		TopicList = trelloData.GetTopics(listName).ToList();
		TopicList = ShuffleList(TopicList);
		SetTopic(Index);
	}

	public void NextTopic() => SetTopic(Index + 1);
	public void PreviousTopic() => SetTopic(Index - 1);
	public string CurrentTopic => TopicList[Index];

	void SetTopic(int index)
	{
		if (index >= TopicList.Count)
			index = 0;
		else if (index < 0)
			index = TopicList.Count - 1;

		Index = index;
	}

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
