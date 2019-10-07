using Newtonsoft.Json.Linq;
using UnityEngine;

public class Yeet : MonoBehaviour
{
	void Awake()
	{
		var json = JObject.Parse("{\"message\": \"waddup\"}");
		Debug.Log(json["message"].Value<string>());

		var file = new File();
		var contents = file.Read("Data/trello-data-10-7.json");

		foreach (var card in file.GetCards(contents, "Topics 10/11/19"))
		{
			var name = card["name"].Value<string>();
			Debug.Log(name);
		}
	}
}
