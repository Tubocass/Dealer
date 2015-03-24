using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
[System.Serializable]

public class StringEvent: UnityEvent<string>
{
}

public class SaveLoad : MonoBehaviour {
	public RectTransform panel;
	StringEvent stEV;
	public float cash;
	public float health;
	public int experience;
	public int reputation;
	//public GameObject player;
	public LevelingSystem data;
	public bool pauseflag;

	public void Start () {
		pauseflag = true;
	}

	public void Update ()
		{
		if (Input.GetKeyDown(KeyCode.P))
				{
					if (pauseflag)
						{
							panel.gameObject.SetActive (!panel.gameObject.activeSelf);
							Time.timeScale = 0;
							pauseflag = false;
						}
					else 
						{	
							panel.gameObject.SetActive( false);
							Time.timeScale = 1;
							pauseflag = true;
						}
					}
	}
	
	public void Save () {

		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/playerSave.dat");
		PlayerData data = new PlayerData();
		data.health = health;
		data.cash = cash;
		data.experience = experience;
		//data.player = player;
		data.reputation = reputation;
		bf.Serialize(file, data);
		file.Close();
		panel.gameObject.SetActive(false);

		}

	public void Load () {
		if(File.Exists(Application.persistentDataPath + "/playerSave.dat"))
		   {
			FileStream file = File.Open (Application.persistentDataPath + "/playerSave.dat" , FileMode.Open);
			file.Close();
			panel.gameObject.SetActive(false);
										
		}
	
	}

	public void Exit() {
	
		Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ");

	}

}

[Serializable]
class PlayerData
{
	LevelingSystem stats = new LevelingSystem();
	public float health;
	public int experience;
	public float cash;
	public int reputation;
	//public GameObject player;
}
