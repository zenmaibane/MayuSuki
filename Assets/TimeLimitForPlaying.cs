using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimitForPlaying : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    var datetimeStr = System.DateTime.Now;
	    var timeLimit = new DateTime(2017, 9, 14, 00, 00, 00);
        if (datetimeStr > timeLimit)
	    {
	        Application.Quit();
	    }
    }
}
