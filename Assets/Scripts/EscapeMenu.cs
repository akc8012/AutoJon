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

	public void OnSetTrelloPath(InputField pathInput)
	{
		Debug.Log($"Loaded TrelloPath: {pathInput.text}");

		var topics = new Topics(pathInput.text);
		TopicTextUI.Topics = topics;
	}

	public void OnClickTrelloPathButton()
	{
		var path = StandaloneFileBrowser.
			OpenFilePanel(title: "Open File", directory: "", extension: "", multiselect: false)[0];

		Debug.Log(path);
	}
}
