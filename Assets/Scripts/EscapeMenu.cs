using System;
using System.Linq;
using SFB;
using UnityEngine;
using UnityEngine.UI;

public class EscapeMenu : MonoBehaviour
{
	[SerializeField]
	GameObject ToggleableMenu = default;

	[SerializeField]
	TopicTextUI TopicTextUI = default;

	[SerializeField]
	LoadErrorText LoadErrorText = default;

	string Path, ListName;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			TogglePauseMenu(!ToggleableMenu.activeSelf);
	}

	void TogglePauseMenu(bool pause)
	{
		if (!pause && TopicTextUI.Topics == null)
			return;

		ToggleableMenu.SetActive(pause);
		TopicTextUI.enabled = !pause;
	}

	public void OnClickTrelloPathButton(Text fileText)
	{
		var path = StandaloneFileBrowser.
			OpenFilePanel(title: "Open File", directory: "", extension: "", multiselect: false)[0];

		Path = path;

		var filename = path.Split(System.IO.Path.DirectorySeparatorChar).Last();
		fileText.text = filename;
	}

	public void OnTrelloListNameEndEdit(InputField inputField) =>
		ListName = inputField.text;

	public void OnLoadTopicsButtonClick() =>
		LoadTopics();

	void LoadTopics()
	{
		var topics = new Topics();

		try
		{
			topics.Load(Path, ListName);
			TopicTextUI.Topics = topics;
		}
		catch (Exception e)
		{
			LoadErrorText.GetComponent<Text>().text = e.Message;
			return;
		}
	}
}
