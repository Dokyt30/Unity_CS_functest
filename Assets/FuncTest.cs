using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FuncTest : MonoBehaviour {
    [SerializeField]
    Text ftext;

    Func<bool> waiter = null;

    // Use this for initialization
    void Start () {
        updateExecFunc();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void updateExecFunc()
    {
        dlog("main s");
        dlog("main (waiter == null)=" + (waiter == null));
        waiter = null;
        while (waiter == null)
        {
            StartCoroutine("waitercall");

            System.Threading.Thread.Sleep(1);
            waiter = () =>
            {
                return false;
            };
            dlog("waiter()=" + waiter());
        }
        dlog("main e");
    }
    private void OnGUI()
    {
        
    }
    IEnumerator waitercall()
    {
        yield return new WaitForSeconds(0);

        try
        {
            dlog("waitercall " + waiter());

        }
        catch (Exception e)
        {
            dlog(e.Message);
        }
    }
    void dlog(string msg)
    {
        ftext.text += msg+"\n";
        Debug.Log(msg);
        Console.WriteLine(msg);
    }
}
