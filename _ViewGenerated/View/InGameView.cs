using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


//
// !!!This class have been generated from tools
//


public class InGameView : View
{


    #region  UNITY
    private void Start()
    {
    }

    // private void Update()
    // {
    // }
    #endregion



    #region STATE
    public override void StartState()
    {
        base.StartState();
        StartView();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        UpdateView();
    }

    public override void EndState()
    {
        base.EndState();
        EndView();
    }
    #endregion


    private void StartView() { }
    private void UpdateView() { }
    private void EndView() { }


}