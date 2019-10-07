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

	public IEnumerable<JToken> GetCards(string json, string listName)
	{
		var contents = JObject.Parse(json);

		var lists = contents["lists"];
		var idList = lists.First(list => list["name"].Value<string>().Equals(listName))["id"].Value<string>();

		var cards = contents["cards"];
		return cards.Where(card => card["idList"].Value<string>().Equals(idList));
	}
}
