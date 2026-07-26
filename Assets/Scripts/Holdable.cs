using UnityEngine;

[System.Serializable]
public class Holdable
{
	public Holdable() { }

	public Holdable(string id, string readableName, Sprite sprite)
	{
		this.id = id;
		this.readableName = readableName;
		this.sprite = sprite;
	}
	public Holdable(Holdable h)
	{
		id = h.id;
		readableName = h.readableName;
		sprite = h.sprite;
	}

	[field: SerializeField] public string id { get; private set; }
	[field: SerializeField] public string readableName { get; private set; }
	[field: SerializeField] public Sprite sprite { get; private set; }

	public void Reset()
	{
		id = string.Empty;
		readableName = string.Empty;
		sprite = null;
	}
}
