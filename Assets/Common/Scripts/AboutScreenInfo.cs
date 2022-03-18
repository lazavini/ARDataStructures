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
           
            { "GroundPlane", "Ground Plane" }
           
        };

        // Init our Common Cache Strings

        string vuforiaVersion = Vuforia.VuforiaUnity.GetVuforiaLibraryVersion();
        string unityVersion = UnityEngine.Application.unityVersion;
        UnityEngine.Debug.Log("Vuforia Engine " + vuforiaVersion + "\nUnity " + unityVersion);

        var vuforia = Vuforia.VuforiaRuntime.Instance.InitializationState != Vuforia.VuforiaRuntime.InitState.NOT_INITIALIZED
                                ? "<#23B200>Yes</color>"
                                : "<color=red>No</color>";

        string description = "\n<size=26>Description:</size>";
        string keyFunctionality = "<size=26>Key Functionality:</size>";
        string targets = "<size=26>Targets:</size>";
        string instructions = "<size=26>Instructions:</size>";
        string footer = "<size=26>Build Version Info:</size>";
        // Init our Description Strings

        // Ground Plane

        descriptions.Add(
            "Ar Structure in AR",
            description +
            "\nThe Ground Plane sample demonstrates how to place " +
            "content on surfaces and in mid-air using anchor points." +
            "\n\n" +
            keyFunctionality +
            "\n• Hit testing places the DataStructure on an intersecting plane in " +
            "the environment. Try this mode by pressing the type of Structure." +
            "at a fixed distance relative to the user. Select this mode by " +
            "pressing the Drone button.???" +
            "\n\n" +
            targets +
            "\n• None required" +
            "\n\n" +
            instructions +
            "\n• Launch the app and view your environment" +
            "\n• Look around until the indicator shows that you have found a surface" +
            "\n• Tap to place Data on the ground" +
            "\n• Drag with one finger to move Data along ground" +
            "\n• Touch and hold with two fingers to rotate Structure" +
            "\n• Select Ground Plane mode" +
            "\n• Tap to place Datas on the ground" +
            "\n• Tap again to move Structure to second point" +
            "\n\n" +
            footer + "\n");
       
    }

    #endregion // CONSTRUCTOR

}

internal class Dictionary
{
}