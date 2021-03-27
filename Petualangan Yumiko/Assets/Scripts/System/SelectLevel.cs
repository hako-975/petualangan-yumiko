using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
	public Button[] levelButtons;

	// Start is called before the first frame update
	void Start()
	{
		int levelAt = PlayerPrefs.GetInt("LevelAt", 1);

		for (int i = 0; i < levelButtons.Length; i++)
		{
			levelButtons[i].interactable = false;
		}

		for (int j = 0; j < levelAt; j++)
		{
			levelButtons[j].interactable = true;
		}
	}

	public void Level_1()
	{
		PlayerPrefsManager.instance.SetNextScene("Level 1");
	}

	public void Level_2()
	{
		PlayerPrefsManager.instance.SetNextScene("Level 2");
	}

	public void Level_3()
	{
		PlayerPrefsManager.instance.SetNextScene("Level 3");
	}

	public void Level_4()
	{
		PlayerPrefsManager.instance.SetNextScene("Level 4");
	}

	public void Level_5()
	{
		PlayerPrefsManager.instance.SetNextScene("Level 5");
	}

	public void Level_6()
	{
		PlayerPrefsManager.instance.SetNextScene("Level 6");
	}

	public void Level_7()
	{
		PlayerPrefsManager.instance.SetNextScene("Level 7");
	}

	public void Level_8()
	{
		PlayerPrefsManager.instance.SetNextScene("Level 8");
	}

	public void Level_9()
	{
		PlayerPrefsManager.instance.SetNextScene("Level 9");
	}

}
