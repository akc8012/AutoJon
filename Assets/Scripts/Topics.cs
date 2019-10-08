using System.Collections.Generic;
using System.Linq;

public class Topics
{
	int Index = 0;
	List<string> TopicList = new List<string>();
	System.Random RandomGenerator = new System.Random();

	public Topics()
	{
		var trelloData = new TrelloData();
		trelloData.Load("Data/trello-data-10-7.json");

		TopicList = trelloData.GetTopics("Topics 10/11/19").ToList();
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
