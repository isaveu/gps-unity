using UnityEngine;
using UnityEngine.UI;

public class GPSView : MonoBehaviour {

    public Text TxtLatitude;
    public Text TxtLongitude;

    /**************************************************/

    #region Update

    private void Update() {
        TxtLatitude.text  = "Latitude: " + GPSManager.Instance.Latitude.ToString();
        TxtLongitude.text = "Longitude: " +  GPSManager.Instance.Longitude.ToString();
    }

    #endregion

}