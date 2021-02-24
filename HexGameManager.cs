using UnityEngine;
using System.Collections;

public class HexGameManager : MonoBehaviour {

	//avec static en aura accée à la varaible dans unity sans affecter le script a un objet 
	public static int player =1;//Au tour du joueur 1 , 2 le tour du 2éme  joueur 
	public static GameObject lastPlayed;//Dérnier coup jouer 
	public static bool firstTurn ; //premier tour 
	public static bool end ;// si on as atteind la fin du jeux 

	public void newGame(){
		Application.LoadLevel (Application.loadedLevel );
	}

}
