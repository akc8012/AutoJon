using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
	[SerializeField]
	GameObject ToggleableMenu = null;
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			ToggleableMenu.SetActive(!ToggleableMenu.activeSelf);
	}
}
