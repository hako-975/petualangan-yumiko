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

        if (levelAt > levelButtons.Length)
        {
			levelAt -= 1;
        }

		for (int j = 0; j < levelAt; j++)
		{
			levelButtons[j].interactable = true;
		}

        for (int k = 0; k < levelAt; k++)
        {
			int l = k;
			levelButtons[k].onClick.AddListener(delegate { Level(l + 1); });
		}

	}

	public void Level(int level)
    {
		PlayerPrefsManager.instance.SetNextScene("Level " + level);
	}

}
