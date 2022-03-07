using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [Header("Track Current & Max Round")]
    public static int currentRound;
    public static int maxRound;

    [Header("Track Current & Max Stage")]
    public static int currentStage;
    public const int MAX_STAGE = 7;

    public virtual void NextRound(){}
}
