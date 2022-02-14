/*===============================================================================
Copyright (c) 2019 PTC Inc. All Rights Reserved.

Vuforia is a trademark of PTC Inc., registered in the United States and other
countries.
===============================================================================*/

using System.Collections.Generic;

public class AboutScreenInfo
{
    #region PRIVATE_MEMBERS

    readonly Dictionary<string, string> titles;
    readonly Dictionary<string, string> descriptions;

    #endregion // PRIVATE_MEMBERS


    #region PUBLIC_METHODS

    public string GetTitle(string titleKey)
    {
        return GetValuefromDictionary(this.titles, titleKey);
    }

    public string GetDescription(string descriptionKey)
    {
        return GetValuefromDictionary(this.descriptions, descriptionKey);
    }

    #endregion // PUBLIC_METHODS


    #region PRIVATE_METHODS

    string GetValuefromDictionary(Dictionary<string, string> dictionary, string key)
    {
        if (dictionary.ContainsKey(key))
        {
            string value;
            dictionary.TryGetValue(key, out value);
            return value;
        }

        return "Key not found.";
    }

    #endregion // PRIVATE_METHODS


    #region CONSTRUCTOR

    public AboutScreenInfo()
    {

        // Init our Title Strings

        this.titles = new Dictionary<string, string>()
        {
           
            { "VirtualButtons", "Virtual Buttons" },
            { "GroundPlane", "Ground Plane" }
           
        };

        // Init our Common Cache Strings

        string vuforiaVersion = Vuforia.VuforiaUnity.GetVuforiaLibraryVersion();
        string unityVersion = UnityEngine.Application.unityVersion;
        UnityEngine.Debug.Log("Vuforia Engine " + vuforiaVersion + "\nUnity " + unityVersion);

        string vuforia = Vuforia.VuforiaRuntime.Instance.InitializationState != Vuforia.VuforiaRuntime.InitState.NOT_INITIALIZED
                                ? "<#23B200>Yes</color>"
                                : "<color=red>No</color>";

        string description = "\n<size=26>Description:</size>";
        string keyFunctionality = "<size=26>Key Functionality:</size>";
        string targets = "<size=26>Targets:</size>";
        string instructions = "<size=26>Instructions:</size>";
        string footer =
            "<size=26>Build Version Info:</size>" +
            "\n• Vuforia Engine " + vuforiaVersion +
            "\n• Unity " + unityVersion +
            "\n" +
            "\n<size=26>Project Settings Info:</size>" +
            "\n• Vuforia Engine Enabled: " + vuforia +
            "\n" +
            "\n<size=26>Links:</size>" +
            "\n• <link=https://developer.vuforia.com/legal/vuforia-developer-agreement><color=blue><u>Developer Agreement</u></color></link>" +
            "\n• <link=https://developer.vuforia.com/legal/privacy><color=blue><u>Privacy Policy</u></color></link>" +
            "\n• <link=https://developer.vuforia.com/legal/EULA><color=blue><u>Terms of Use</u></color></link>" +
            "\n• <link=https://developer.vuforia.com/legal/statistics><color=blue><u>Statistics</u></color></link>" +
            "\n\n" +
            "© 2019 PTC Inc. All Rights Reserved." +
            "\n";
        string targetPDFsURL = "<link=https://library.vuforia.com/content/vuforia-library/en/articles/Solution/sample-apps-target-pdfs.html>";

        // Init our Description Strings

        this.descriptions = new Dictionary<string, string>();

       
        // Virtual Buttons

        this.descriptions.Add(
            "VirtualButtons",
            description +
            "\nThe Virtual Buttons sample shows how the developer can define rectangular " +
            "regions on image targets that trigger an event when touched or occluded in " +
            "the camera view. The sample renders a 3D object that changes color when " +
            "one of the virtual buttons is triggered." +
            "\n\n" +
            keyFunctionality +
            "\n• Button occlusion event handling" +
            "\n\n" +
            targets +
            "\n• " + targetPDFsURL +
            "<color=blue><u>Target PDFs</u></color></link>" +
            "\n\n" +
            instructions +
            "\n• Point camera at target to view" +
            "\n• Double tap to focus" +
            "\n\n" +
            footer + "\n");



        // Ground Plane

        this.descriptions.Add(
            "Ar Structure in AR",
            description +
            "\nThe Ground Plane sample demonstrates how to place " +
            "content on surfaces and in mid-air using anchor points." +
            "\n\n" +
            keyFunctionality +
            "\n• Hit testing places the Chair or the Astronaut on an intersecting plane in " +
            "the environment. Try this mode by pressing the Chair or Astronaut buttons." +
            "\n• Mid-Air anchoring places the drone on an anchor point created " +
            "at a fixed distance relative to the user. Select this mode by " +
            "pressing the Drone button." +
            "\n\n" +
            targets +
            "\n• None required" +
            "\n\n" +
            instructions +
            "\n• Launch the app and view your environment" +
            "\n• Look around until the indicator shows that you have found a surface" +
            "\n• Tap to place Chair on the ground" +
            "\n• Drag with one finger to move Chair along ground" +
            "\n• Touch and hold with two fingers to rotate Structure" +
            "\n• Select Ground Plane mode" +
            "\n• Tap to place Datas on the ground" +
            "\n• Tap again to move Structure to second point" +
            "\n\n" +
            footer + "\n");


        





       
    }

    #endregion // CONSTRUCTOR

}
