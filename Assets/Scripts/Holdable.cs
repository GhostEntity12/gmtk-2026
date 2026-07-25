using UnityEngine;

[System.Serializable]
public class Holdable
{
	[field: SerializeField]
	public string id { get; private set; }
	[field: SerializeField]
	public string readableName { get; private set; }
	[field: SerializeField]
	public Sprite sprite { get; private set; }
}
