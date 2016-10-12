using UnityEngine;
using System.Collections;

public class TutorialState : State {


    public override void Enable()
    {
        base.Enable();
        CDAnalytics.Event(AnalyticsEvent.Tutorial);
    }
}
