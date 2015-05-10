using UnityEngine;

public enum MessageType
{
	NONE,
	LevelStart,
	LevelEnd,
	PlayerPosition,
	PointAdded,
	Trade
}

public struct Message
{
	public MessageType Type;
	public string StringValue;
	public int IntValue;
	public float FloatValue;
	public Vector3 Vector3Value;
	public GameObject GameObjectValue;
}