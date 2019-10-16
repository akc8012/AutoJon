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

	string Path;
	string ListName;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			ToggleableMenu.SetActive(!ToggleableMenu.activeSelf);
	}

	public void OnClickTrelloPathButton(Text fileText)
	{
		var path = StandaloneFileBrowser.
			OpenFilePanel(title: "Open File", directory: "", extension: "", multiselect: false)[0];

		Path = path;

		var filename = path.Split(System.IO.Path.DirectorySeparatorChar).Last();
		fileText.text = filename;
	}

	public void OnTrelloListNameEndEdit(InputField inputField)
	{
		ListName = inputField.text;
	}

	public void OnLoadTopicsButtonClick()
	{
		var topics = new Topics(Path, ListName);
		TopicTextUI.Topics = topics;

		if (!TopicTextUI.gameObject.activeSelf)
			TopicTextUI.gameObject.SetActive(true);
	}
}
