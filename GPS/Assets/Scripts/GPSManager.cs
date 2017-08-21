using System.Collections;
using UnityEngine;

public class GPSManager : MonoBehaviour {

    #region Singleton Instance

    public static GPSManager Instance { get; set; }

    #endregion

    public float Latitude;  //Enlem
    public float Longitude; // Boylam

    /**************************************************/

    #region Start

    void Start() {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        StartCoroutine(StartLocationService());
    }

    #endregion

    #region LocationService: Start

    private IEnumerator StartLocationService() {
        if (!Input.location.isEnabledByUser) {
            Debug.LogWarning("GPS is not active!");
            yield break;
        }

        Input.location.Start();
        int maxWait = 20;
        bool wait = (Input.location.status == LocationServiceStatus.Initializing && maxWait > 20);
        while (wait) {
            yield return new WaitForSeconds(1f);
            maxWait--;
        }

        if (maxWait <= 0) {
            Debug.LogWarning("Timed Out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed) {
            Debug.LogWarning("Unable to determine device location");
            yield break;
        }

        Latitude = Input.location.lastData.latitude;
        Longitude = Input.location.lastData.longitude;

    }

    #endregion

}