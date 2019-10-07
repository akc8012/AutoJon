using Newtonsoft.Json.Linq;
using UnityEngine;

public class Yeet : MonoBehaviour
{
	void Awake()
	{
		Debug.Log(typeof(string).Assembly.ImageRuntimeVersion);

		var json = JObject.Parse("{\"message\": \"waddup\"}");
		Debug.Log(json["message"].Value<string>());
	}
}
