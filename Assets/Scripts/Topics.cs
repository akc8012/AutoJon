using System.Linq;
using System.Collections.Generic;

public class Topics
{
	int Index = 0;
	List<string> TopicList;

	public void Load(string path, string listName)
	{
		var trelloData = new TrelloData();
		trelloData.Load(path);

		TopicList = trelloData.GetTopics(listName).ToList();

		var shuffleBox = new ShuffleBox();
		TopicList = shuffleBox.Shuffle(TopicList);
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
}
