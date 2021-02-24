using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//classe IA
public class HexAI : MonoBehaviour
{
	int nbCases = 12;

	public void IaPlay()
	{
		int i, j;
		string[] newname;

		if(HexGameManager.firstTurn)
		{
			PlayInFirstCol();
		}
		else
		{
			newname = HexGameManager.lastPlayed.name.Split('-');
			i = int.Parse(newname[0]); j = int.Parse(newname[1]);
			string choice = "";
			// Calcul des choix possibles
			if ((i + 1 < (nbCases + 1)) && (j - 1 > 0) && 
				GameObject.Find((i + 1) + "-" + (j - 1)).GetComponent<HexCase>().etat == 0)
			{
				choice = (i + 1) + "-" + (j - 1);
			}
			else if ((i + 1 < (nbCases + 1))
				&& GameObject.Find((i + 1) + "-" + j).GetComponent<HexCase>().etat == 0)
			{
				choice = (i + 1) + "-" + j;
			}
			else if ((j + 1 < (nbCases + 1)) && 
				GameObject.Find(i + "-" + (j + 1)).GetComponent<HexCase>().etat == 0)
			{
				choice = i + "-" + (j + 1);
			}
			else if ((j - 1 > 1) && GameObject.Find(i + "-" + (j - 1)).GetComponent<HexCase>().etat == 0)
			{
				choice = i + "-" + (j - 1);
			}
			else
			{
				bool ok = false;
				while(!ok)
				{
					choice = Random.Range(2, (nbCases - 1)) + "-" + Random.Range(2, (nbCases - 1));
					HexCase laCase = GameObject.Find(choice).GetComponent<HexCase>();
					if(laCase.etat == 0)
					{
						ok = true;
					}
				}
			}
			SetPlayedCase(choice);
		}
		CheckIfAIWon();
	}

	public void SetPlayedCase(string choice)
	{
		HexGameManager.lastPlayed = GameObject.Find(choice);
		HexGameManager.lastPlayed.GetComponent<SpriteRenderer>().color = Color.red;
		HexGameManager.lastPlayed.GetComponent<HexCase>().etat = 2;
		HexGameManager.player = 1;
	}

	public void PlayInFirstCol()
	{
		bool ok = false;
		string name = "";
		while(!ok)
		{
			name = "1-" + Random.Range(1, nbCases);
			if(GameObject.Find(name).GetComponent<HexCase>().etat == 0)
			{
				ok = true;
			}
		}
		GameObject go = GameObject.Find(name);
		HexGameManager.firstTurn = false;
		HexGameManager.lastPlayed = go;
		go.GetComponent<SpriteRenderer>().color = Color.red;
		go.GetComponent<HexCase>().etat = 2;
		HexGameManager.player = 1;
	}

	public void CheckIfAIWon()
	{
		string[] newname = HexGameManager.lastPlayed.name.Split('-');
		if (int.Parse(newname[0]) == nbCases)
		{
			print("IA WIN");
			HexGameManager.end = true;
		}
	}
}
