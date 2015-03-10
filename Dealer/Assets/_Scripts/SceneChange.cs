using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {

	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.3f;
	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1;
	public GameObject player;

	void Start()
	{
		player =GameObject.Find ("Player");
	}

	void OnGUI()
	{
		alpha += fadeDir *fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01(alpha);
		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture( new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
	}

	public float BeginFade(int direction) 
	{
		fadeDir = direction;
		return (fadeSpeed);
	}
	void OnLevelWasLoaded ()
	{
		BeginFade(-1);
	}


	public IEnumerator FadeSceneCoroutine() 
	{
		DontDestroyOnLoad (GameObject.FindGameObjectWithTag("Player"));
		DontDestroyOnLoad(GameObject.FindGameObjectWithTag("InventoryCanvas"));
		DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GameController"));
		yield return new WaitForSeconds(2);
		GameObject.Find("Player").transform.position = new Vector3(-33,33,0);
		Application.LoadLevel ("Scene_High");
		BeginFade (-1);
	}
	public void SceneTimer()
	{
		StartCoroutine(FadeSceneCoroutine());
	}

}