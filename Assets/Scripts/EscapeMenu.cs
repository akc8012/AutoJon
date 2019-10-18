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

	[SerializeField]
	LoadSuccessText LoadSuccessText = default;

	string Path, ListName;

	string GetFileName(string path) => path.Split(System.IO.Path.DirectorySeparatorChar).Last();

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

	public void OnTopicIntervalFieldEndEdit(InputField inputField) =>
		TopicTextUI.TopicInterval = float.Parse(inputField.text);

	public void OnClickTrelloPathButton(Text fileText)
	{
		var path = StandaloneFileBrowser.
			OpenFilePanel(title: "Open File", directory: "", extension: "", multiselect: false)[0];

		Path = path;
		fileText.text = GetFileName(Path);
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

			LoadErrorText.Text = "";
			LoadSuccessText.SetSuccessText($"Successfully loaded '{GetFileName(Path)}' with list '{ListName}'!");
		}
		catch (Exception e)
		{
			LoadErrorText.Text = e.Message;
			return;
		}
	}
}
