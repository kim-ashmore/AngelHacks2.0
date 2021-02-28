using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class coord
{
    public int x;
    public int y;
    public int z;
}

public class SpawnFace : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject spawnee;

    

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<10; i++) {
            coord myObject = new coord();
            myObject.x = i; myObject.y = i; myObject.z = i;
            Instantiate(spawnee, new Vector3(i,i,i), spawnPos.rotation);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

/*
    private landmarks: [
            {
              "type": "LEFT_EYE",
              "position": {
                "x": 1368.748,
                "y": 739.0957,
                "z": 0.0024604797
              }
            },
            {
              "type": "RIGHT_EYE",
              "position": {
                "x": 1660.6105,
                "y": 751.5844,
                "z": -117.06496
              }
            },
            {
              "type": "LEFT_OF_LEFT_EYEBROW",
              "position": {
                "x": 1284.3208,
                "y": 666.61487,
                "z": 63.41506
              }
            },
            {
              "type": "RIGHT_OF_LEFT_EYEBROW",
              "position": {
                "x": 1418.9249,
                "y": 671.49414,
                "z": -83.82396
              }
            },
            {
              "type": "LEFT_OF_RIGHT_EYEBROW",
              "position": {
                "x": 1556.9579,
                "y": 672.2199,
                "z": -139.39935
              }
            },
            {
              "type": "RIGHT_OF_RIGHT_EYEBROW",
              "position": {
                "x": 1771.4799,
                "y": 682.65845,
                "z": -131.66716
              }
            },
            {
              "type": "MIDPOINT_BETWEEN_EYES",
              "position": {
                "x": 1479.6194,
                "y": 741.87305,
                "z": -114.84635
              }
            },
            {
              "type": "NOSE_TIP",
              "position": {
                "x": 1443.3151,
                "y": 917.5109,
                "z": -194.49301
              }
            },
            {
              "type": "UPPER_LIP",
              "position": {
                "x": 1466.7897,
                "y": 1025.3483,
                "z": -130.1202
              }
            },
            {
              "type": "LOWER_LIP",
              "position": {
                "x": 1467.2588,
                "y": 1147.0403,
                "z": -109.24505
              }
            },
            {
              "type": "MOUTH_LEFT",
              "position": {
                "x": 1376.8649,
                "y": 1066.0856,
                "z": -6.8136826
              }
            },
            {
              "type": "MOUTH_RIGHT",
              "position": {
                "x": 1652,
                "y": 1079.3108,
                "z": -106.93649
              }
            },
            {
              "type": "MOUTH_CENTER",
              "position": {
                "x": 1485.5554,
                "y": 1087.2388,
                "z": -110.68126
              }
            },
            {
              "type": "NOSE_BOTTOM_RIGHT",
              "position": {
                "x": 1571.9475,
                "y": 944.9213,
                "z": -124.11806
              }
            },
            {
              "type": "NOSE_BOTTOM_LEFT",
              "position": {
                "x": 1395.2339,
                "y": 938.12787,
                "z": -58.072197
              }
            },
            {
              "type": "NOSE_BOTTOM_CENTER",
              "position": {
                "x": 1468.4205,
                "y": 968.8732,
                "z": -132.09975
              }
            },
            {
              "type": "LEFT_EYE_TOP_BOUNDARY",
              "position": {
                "x": 1357.8658,
                "y": 711.2427,
                "z": -14.618992
              }
            },
            {
              "type": "LEFT_EYE_RIGHT_CORNER",
              "position": {
                "x": 1423.6936,
                "y": 750.4164,
                "z": -23.540215
              }
            },
            {
              "type": "LEFT_EYE_BOTTOM_BOUNDARY",
              "position": {
                "x": 1360.5627,
                "y": 762.87415,
                "z": -1.2607727
              }
            },
            {
              "type": "LEFT_EYE_LEFT_CORNER",
              "position": {
                "x": 1313.72,
                "y": 739.443,
                "z": 50.216393
              }
            },
            {
              "type": "RIGHT_EYE_TOP_BOUNDARY",
              "position": {
                "x": 1661.6622,
                "y": 718.6839,
                "z": -134.17404
              }
            },
            {
              "type": "RIGHT_EYE_RIGHT_CORNER",
              "position": {
                "x": 1730.0901,
                "y": 763.57104,
                "z": -116.365845
              }
            },
            {
              "type": "RIGHT_EYE_BOTTOM_BOUNDARY",
              "position": {
                "x": 1660.8823,
                "y": 777.3474,
                "z": -120.8635
              }
            },
            {
              "type": "RIGHT_EYE_LEFT_CORNER",
              "position": {
                "x": 1590.8903,
                "y": 753.5044,
                "z": -91.84842
              }
            },
            {
              "type": "LEFT_EYEBROW_UPPER_MIDPOINT",
              "position": {
                "x": 1345.7522,
                "y": 640.18243,
                "z": -27.887913
              }
            },
            {
              "type": "RIGHT_EYEBROW_UPPER_MIDPOINT",
              "position": {
                "x": 1660.5848,
                "y": 648.36145,
                "z": -153.73691
              }
            },
            {
              "type": "LEFT_EAR_TRAGION",
              "position": {
                "x": 1274.1006,
                "y": 826.2645,
                "z": 422.6642
              }
            },
            {
              "type": "RIGHT_EAR_TRAGION",
              "position": {
                "x": 2014.8041,
                "y": 908.56537,
                "z": 149.61232
              }
            },
            {
              "type": "FOREHEAD_GLABELLA",
              "position": {
                "x": 1476.2395,
                "y": 669.9625,
                "z": -120.59111
              }
            },
            {
              "type": "CHIN_GNATHION",
              "position": {
                "x": 1477.3256,
                "y": 1269.3269,
                "z": -67.748795
              }
            },
            {
              "type": "CHIN_LEFT_GONION",
              "position": {
                "x": 1336.8848,
                "y": 1096.2242,
                "z": 286.73004
              }
            },
            {
              "type": "CHIN_RIGHT_GONION",
              "position": {
                "x": 1863.2197,
                "y": 1128.6213,
                "z": 68.90431
              }
            },
            {
              "type": "LEFT_CHEEK_CENTER",
              "position": {
                "x": 1317.8549,
                "y": 940.8025,
                "z": 50.863163
              }
            },
            {
              "type": "RIGHT_CHEEK_CENTER",
              "position": {
                "x": 1733.4912,
                "y": 964.073,
                "z": -112.43947
              }
            }
    ]
    */
}
