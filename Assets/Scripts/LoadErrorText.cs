using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LoadErrorText : MonoBehaviour
{
	Text Text;

	void Awake() => Text = GetComponent<Text>();
}
