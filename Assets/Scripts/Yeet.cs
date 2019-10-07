using UnityEngine;

public class Yeet : MonoBehaviour
{
	void Awake()
	{
		Debug.Log(typeof(string).Assembly.ImageRuntimeVersion);
	}
}
