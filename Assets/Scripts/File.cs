using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class File
{
	public string Read(string path)
	{
		try
		{
			using (StreamReader sr = new StreamReader(path))
			{
				String line = sr.ReadToEnd();
				return line;
			}
		}
		catch (IOException e)
		{
			Debug.LogError($"The file could not be read: {e.Message}");
		}

		return "";
	}

	public JToken GetCards(string json)
	{
		var data = JObject.Parse(json);
		return data["cards"];
	}

	public IEnumerable<JToken> GetCards(string json, string listName)
	{
		string idList = "";
		foreach (var list in JObject.Parse(json)["lists"])
		{
			if (list["name"].Value<string>() == listName)
			{
				idList = list["id"].Value<string>();
				Debug.Log("got it: " + idList);
				break;
			}
		}

		var cards = GetCards(json);
		return cards.Where(card => card["idList"].Value<string>() == idList);


		// foreach (var card in cards)
		// {
		// 	if (card["idList"].Value<string>() == idList)
		// 		return card;
		// }

		// throw new Exception("u fucked up");
	}
}
