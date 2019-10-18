using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LoadErrorText : MonoBehaviour
{
	public string Text
	{
		get => GetComponent<Text>().text;
		set => GetComponent<Text>().text = value;
	}

	void Start() => Text = "";
}
