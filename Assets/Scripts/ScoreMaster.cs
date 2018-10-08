using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {

	public static List<int> ScoreCumulative(List<int> rolls){
		List<int> cumulativeScores = new List<int> ();
		int runningTotal = 0;

		foreach (int frameScore in ScoreFrames(rolls)) {
			runningTotal += frameScore;
			cumulativeScores.Add (runningTotal);
		}

		return cumulativeScores;

	}


	public static List<int> ScoreFrames(List<int> rolls){
		List<int> frames = new List<int> ();

		for (int i = 1; i < rolls.Count; i += 2) {
			if (rolls [1] + rolls [i - 1] < 10) {
				frames.Add (rolls [i - 1] + rolls [i]);
			}
		}


		return frames;
	}
}
