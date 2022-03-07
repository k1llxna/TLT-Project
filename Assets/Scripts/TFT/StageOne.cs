using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageOne : Stage
{
    void Start()
    {
        currentRound = 1;
        maxRound = 3;

        currentStage = 1;
    }

    // only to be called via phase manager (in tandem with ienumerator)
    public override void NextRound()
    {
        if (currentStage < MAX_STAGE)
        {
            // increment round
            if (currentRound >= maxRound)
            {
                currentRound++;
            }
            else //increment stage
            {
                if (currentStage < MAX_STAGE)
                    currentStage++;

                currentRound = 1;
            }

            GameObject.Find(currentStage.ToString() + currentRound.ToString()).SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
