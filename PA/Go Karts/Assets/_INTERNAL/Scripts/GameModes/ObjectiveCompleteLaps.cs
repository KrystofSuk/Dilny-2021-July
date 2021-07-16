using System.Collections;
using System.Collections.Generic;
using KartGame.KartSystems;
using KartGame.Track;
using UnityEngine;

public class ObjectiveCompleteLaps : Objective
{
    [Tooltip("How many laps should the player complete before the game is over?")]
    public int lapsToComplete;

    [Header("Notification")]
    [Tooltip("Start sending notification about remaining laps when this amount of laps is left")]
    public int notificationLapsRemainingThreshold = 1;

    public ArcadeKart playerKart;

    public static ArcadeKart gamePlayerKart;

    public static Dictionary<ArcadeKart, int> kartsScore = new Dictionary<ArcadeKart, int>();
    public static int gameLapsToComplete = 1;

    public static void AddLap(ArcadeKart kart)
    {
        if (kart == null || !kartsScore.ContainsKey(kart)) return;
        kartsScore[kart] += 1;

        Debug.Log("ADDING LAP", kart);
    }

    public static bool KartWon(ArcadeKart kart)
    {
        return ObjectiveCompleteLaps.kartsScore[kart] >= gameLapsToComplete;
    }

    void InitScore()
    {
        var karts = FindObjectsOfType<ArcadeKart>();

        // LAP SCRIPT
        foreach (var kart in karts)
        {
            if (kartsScore.ContainsKey(kart))
                continue;

            kartsScore.Add(kart, 0);
        }

        gameLapsToComplete = lapsToComplete;
    }


    public int currentLap { get; private set; }

    void Awake()
    {
        currentLap = 0;

        InitScore();

        // set a title and description specific for this type of objective, if it hasn't one
        if (string.IsNullOrEmpty(title))
            title = $"Complete {lapsToComplete} {targetName}s";
    }

    IEnumerator Start()
    {
        gamePlayerKart = this.playerKart;

        TimeManager.OnSetTime(totalTimeInSecs, isTimed, gameMode);
        TimeDisplay.OnSetLaps(lapsToComplete);
        yield return new WaitForEndOfFrame();
        Register();
    }

    protected override void ReachCheckpoint(int remaining)
    {
        if (isCompleted)
            return;

        currentLap++;

        int targetRemaining = lapsToComplete - currentLap;

        // update the objective text according to how many enemies remain to kill
        if (targetRemaining == 0)
        {
            CompleteObjective(string.Empty, GetUpdatedCounterAmount(),
                "Objective complete: " + title);
        }
        else if (targetRemaining == 1)
        {
            string notificationText = notificationLapsRemainingThreshold >= targetRemaining
                ? "One " + targetName + " left"
                : string.Empty;
            UpdateObjective(string.Empty, GetUpdatedCounterAmount(), notificationText);
        }
        else if (targetRemaining > 1)
        {
            // create a notification text if needed, if it stays empty, the notification will not be created
            string notificationText = notificationLapsRemainingThreshold >= targetRemaining
                ? targetRemaining + " " + targetName + "s to collect left"
                : string.Empty;

            UpdateObjective(string.Empty, GetUpdatedCounterAmount(), notificationText);
        }
    }

    public override string GetUpdatedCounterAmount()
    {
        return currentLap + " / " + lapsToComplete;
    }
}
