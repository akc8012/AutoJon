using System.IO;
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

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			ToggleableMenu.SetActive(!ToggleableMenu.activeSelf);
	}

	public void OnClickTrelloPathButton(Text fileText)
	{
		var path = StandaloneFileBrowser.
			OpenFilePanel(title: "Open File", directory: "", extension: "", multiselect: false)[0];

		var topics = new Topics(path);
		TopicTextUI.Topics = topics;

		var filename = path.Split(Path.DirectorySeparatorChar).Last();
		fileText.text = filename;
	}
}
