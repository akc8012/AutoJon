using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class TrelloData
{
	JToken Contents;

	public void Load(string path)
	{
		var json = ReadJsonFromFile(path);
		Contents = JObject.Parse(json);
	}

	string ReadJsonFromFile(string path)
	{
		using (StreamReader sr = new StreamReader(path))
			return sr.ReadToEnd();
	}

	public IEnumerable<string> GetTopics(string listName)
	{
		if (Contents == null)
			throw new Exception("You forgot to load!");

		var lists = Contents["lists"];
		var idList = lists.First(list => list["name"].Value<string>().Equals(listName))["id"].Value<string>();

		var cards = Contents["cards"];
		return cards.
			Where(card => card["idList"].Value<string>().Equals(idList)).
			Select(card => card["name"].Value<string>());
	}
}
