using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster{

	private int bowl=1;

	public enum Action{Tidy, Reset, EndTurn, EndGame}; 

	public Action Bowl(int pins){
		
		if (pins < 0 || pins > 10) {throw new UnityException ("Invalid pins");}

		if (pins == 10) {
			bowl += 2;
			return Action.EndTurn;

		}

		if (bowl % 2 != 0) {
			bowl += 1;
			return Action.Tidy;

		}

		throw new UnityException ("Not Sure");
	}

}
