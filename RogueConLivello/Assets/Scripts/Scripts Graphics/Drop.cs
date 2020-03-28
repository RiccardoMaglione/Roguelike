using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private Vector2 scrollViewVector = Vector2.zero;
    public Rect dropDownRect = new Rect(125, 50, 125, 300);
    public static string[] list = {""};

    int indexNumber;
    bool show = false;
    void OnGUI()
    {
        if (GUI.Button(new Rect((dropDownRect.x - 100), dropDownRect.y, dropDownRect.width, 25), ""))
        {
            if (!show)
            {
                show = true;
            }
            else
            {
                show = false;
            }
        }



        if (ResolutionManager.Instance == null) return;

        ResolutionManager resolutionManager = ResolutionManager.Instance;

        int i = 0;


        if (show)
        {
            scrollViewVector = GUI.BeginScrollView(new Rect((dropDownRect.x - 100), (dropDownRect.y + 25), dropDownRect.width, dropDownRect.height), scrollViewVector, new Rect(0, 0, dropDownRect.width, Mathf.Max(dropDownRect.height, (list.Length * 25))));

            GUI.Box(new Rect(0, 0, dropDownRect.width, Mathf.Max(dropDownRect.height, (list.Length * 25))), "");

            for (int index = 0; index < list.Length; index++)
            {

                //if (GUI.Button(new Rect(0, (index * 25), dropDownRect.height, 25), ""))
                //{
                //    show = false;
                //    indexNumber = index;
                //}
                
                GUI.Label(new Rect(5, (index * 25), dropDownRect.height, 25), list[index]);
                
                foreach (Vector2 r in Screen.fullScreen ? resolutionManager.FullscreenResolutions : resolutionManager.WindowedResolutions)
                {
                    string label = r.x + "x" + r.y;
                    if (r.x == Screen.width && r.y == Screen.height) label += "*";
                    if (r.x == resolutionManager.DisplayResolution.width && r.y == resolutionManager.DisplayResolution.height) label += " (native)";
                
                    if (GUILayout.Button(label))
                        resolutionManager.SetResolution(i, Screen.fullScreen);
                
                    i++;
                }
                
            }

            GUI.EndScrollView();
        }
        else
        {
            GUI.Label(new Rect((dropDownRect.x - 95), dropDownRect.y, 300, 25), list[indexNumber]);
        }





    }
}



