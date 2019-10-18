using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LoadSuccessText : MonoBehaviour
{
	string Text
	{
		get => GetComponent<Text>().text;
		set => GetComponent<Text>().text = value;
	}

	void Start() => Text = "";

	public void SetSuccessText(string text)
	{
		Text = text;
		StartCoroutine(nameof(ClearTextAfterSeconds));
	}

	IEnumerator ClearTextAfterSeconds()
	{
		yield return new WaitForSeconds(seconds: 5);
		Text = "";
	}
}
