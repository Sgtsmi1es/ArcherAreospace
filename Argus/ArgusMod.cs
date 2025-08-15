using UnityEngine;
using KSP;
using ToolbarControl_NS;
using KSP.UI.Screens;
using ClickThroughFix;

namespace Argus
{
    /// <summary>
    /// Registration class for ToolbarControl
    /// </summary>
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class RegisterToolbar : MonoBehaviour
    {
        void Start()
        {
            ToolbarControl.RegisterMod("Argus_NS", "Argus");
        }
    }

    /// <summary>
    /// Main mod class for Argus - KSP Orbital Triad Deployment System (MVP Version)
    /// </summary>
    [KSPAddon(KSPAddon.Startup.Flight, true)]
    public class ArgusMod : MonoBehaviour
    {
        private static ArgusMod instance;
        private ToolbarControl toolbarControl;
        private bool showTestWindow = false;
        
        public static ArgusMod Instance
        {
            get { return instance; }
        }
        
        void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            
            instance = this;
            DontDestroyOnLoad(gameObject);
            
            Log("Argus mod initialized successfully");
        }
        
        void Start()
        {
            // Create toolbar button
            CreateToolbarButton();
        }
        
        private void CreateToolbarButton()
        {
            toolbarControl = gameObject.AddComponent<ToolbarControl>();
            toolbarControl.AddToAllToolbars(OnToolbarClick, OnToolbarClick,
                ApplicationLauncher.AppScenes.FLIGHT,
                "Argus_NS",
                "argusButton",
                "Argus/Icons/argus_icon",
                "Argus/Icons/argus_icon",
                "Argus - Orbital Triad Deployment System"
            );
        }
        
        private void OnToolbarClick()
        {
            showTestWindow = !showTestWindow;
            Log("Toolbar button clicked, window state: " + (showTestWindow ? "open" : "closed"));
        }
        
        void OnGUI()
        {
            // Only show in Flight scene
            if (HighLogic.LoadedScene != GameScenes.FLIGHT)
                return;

            // Draw test window if open
            if (showTestWindow)
            {
                DrawTestWindow();
            }
        }
        
        private void DrawTestWindow()
        {
            // Window dimensions and position
            int windowWidth = 300;
            int windowHeight = 200;
            int x = (Screen.width - windowWidth) / 2;
            int y = (Screen.height - windowHeight) / 2;

            // Draw window using ClickThruBlocker for better click handling
            ClickThruBlocker.GUIWindow(12345, new Rect(x, y, windowWidth, windowHeight), DrawWindowContents, "Argus Test Window");
        }

        private void DrawWindowContents(int windowID)
        {
            GUILayout.BeginVertical();
            GUILayout.Space(20);

            // Title
            GUILayout.Label("Argus Mod Test Interface", GUI.skin.box, GUILayout.ExpandWidth(true));
            GUILayout.Space(20);

            // Test button
            if (GUILayout.Button("Spawn Test Relay in Orbit", GUILayout.Height(40)))
            {
                SpawnTestRelay();
            }

            GUILayout.Space(20);

            // Close button
            if (GUILayout.Button("Close", GUILayout.Height(30)))
            {
                showTestWindow = false;
            }

            GUILayout.EndVertical();
        }

        private void SpawnTestRelay()
        {
            try
            {
                Log("Attempting to spawn test relay...");

                // Check if we're in the right scene for spawning
                if (HighLogic.LoadedScene != GameScenes.FLIGHT)
                {
                    LogWarning("Vessel spawning only works in Flight scene. Current scene: " + HighLogic.LoadedScene);
                    LogWarning("The Argus button should only be visible in Flight scene.");
                    return;
                }

                // Get Kerbin as the target body
                CelestialBody kerbin = FlightGlobals.GetBodyByName("Kerbin");
                if (kerbin == null)
                {
                    LogError("Could not find Kerbin!");
                    return;
                }

                // Calculate orbital parameters
                double altitude = 256000; // 256km in meters
                double inclination = 23.0 * Mathf.Deg2Rad; // Convert to radians
                
                // Calculate semi-major axis (altitude + body radius)
                double semiMajorAxis = altitude + kerbin.Radius;
                
                // Create orbital parameters using the proper constructor
                Orbit orbit = new Orbit(inclination, 0.0, semiMajorAxis, 0.0, 0.0, 0.0, Planetarium.GetUniversalTime(), kerbin);
                
                Log($"Calculated orbit parameters:");
                Log($"- Altitude: {altitude/1000:F1}km");
                Log($"- Inclination: {inclination * Mathf.Rad2Deg:F1}°");
                Log($"- Semi-major axis: {semiMajorAxis/1000:F1}km");
                Log($"- Eccentricity: {orbit.eccentricity:F3}");
                
                // Spawn the vessel using KSP 1.x API
                // Construct path to the current save's Ships/VAB folder
                string savePath = HighLogic.SaveFolder;
                // Use KSP's data path to get the root directory
                string kspRoot = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(Application.dataPath));
                string craftPath = System.IO.Path.Combine(kspRoot, "saves", savePath, "Ships", "VAB", "ZZZ_AA_TESTrelay.craft");
                Log($"Attempting to load craft from: {craftPath}");
                bool success = SpawnVesselFromCraft(craftPath, orbit, kerbin, "Argus Test Relay");
                
                if (success)
                {
                    Log("Test relay spawned successfully!");
                    Log($"Vessel placed in {altitude/1000:F1}km altitude, {inclination * Mathf.Rad2Deg:F1}° inclination orbit around Kerbin");
                }
                else
                {
                    LogError("Failed to spawn test relay vessel");
                }
                
            }
            catch (System.Exception e)
            {
                LogError($"Error in test relay function: {e.Message}");
                LogError($"Stack trace: {e.StackTrace}");
            }
        }
        
        /// <summary>
        /// Spawns a vessel from a craft file at the specified orbital parameters
        /// </summary>
        private bool SpawnVesselFromCraft(string craftPath, Orbit orbit, CelestialBody body, string vesselName)
        {
            try
            {
                Log($"Loading craft file: {craftPath}");
                
                // Load the craft file
                ConfigNode craftNode = ConfigNode.Load(craftPath);
                if (craftNode == null)
                {
                    LogError($"Could not load craft file: {craftPath}");
                    return false;
                }
                
                Log("Craft file loaded successfully, attempting to spawn vessel...");
                
                // Use KSP 1.x vessel spawning method
                try
                {
                    Log("Using KSP 1.x vessel spawning API...");
                    
                    // Create vessel using the basic constructor and manual setup
                    GameObject vesselObject = new GameObject(vesselName);
                    Vessel newVessel = vesselObject.AddComponent<Vessel>();
                    
                    // Set basic vessel properties
                    newVessel.vesselName = vesselName;
                    newVessel.vesselType = VesselType.Probe;
                    
                    // Create and set up the orbit driver
                    OrbitDriver orbitDriver = vesselObject.AddComponent<OrbitDriver>();
                    orbitDriver.orbit = orbit;
                    orbitDriver.referenceBody = body;
                    
                    // Set the vessel's orbit driver (this will handle the orbit)
                    newVessel.orbitDriver = orbitDriver;
                    
                    // Calculate the vessel's position in 3D space based on the orbit
                    Vector3d position = orbit.getPositionAtUT(Planetarium.GetUniversalTime());
                    
                    vesselObject.transform.position = (Vector3)position;
                    
                    // Set the vessel's situation
                    newVessel.situation = Vessel.Situations.ORBITING;
                    
                    // Add the vessel to the game
                    FlightGlobals.Vessels.Add(newVessel);
                    
                    // Force the vessel to go "on rails" which should properly initialize its orbital state
                    newVessel.GoOnRails();
                    
                    Log($"Vessel '{vesselName}' created and added to game");
                    Log($"Vessel Type: {newVessel.vesselType}");
                    Log($"Vessel ID: {newVessel.id}");
                    
                    // Try to set as active vessel
                    try
                    {
                        FlightGlobals.ForceSetActiveVessel(newVessel);
                        Log("Vessel set as active vessel");
                    }
                    catch (System.Exception activeError)
                    {
                        LogWarning($"Could not set as active vessel: {activeError.Message}");
                    }
                    
                    return true;
                    
                }
                catch (System.Exception e)
                {
                    LogError($"Vessel spawning failed: {e.Message}");
                    LogError($"Stack trace: {e.StackTrace}");
                    return false;
                }
                
            }
            catch (System.Exception e)
            {
                LogError($"Error in vessel spawning: {e.Message}");
                LogError($"Stack trace: {e.StackTrace}");
                return false;
            }
        }
        
        void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }
        
        // Logging methods
        private void Log(string message)
        {
            Debug.Log("[Argus] " + message);
        }
        
        private void LogWarning(string message)
        {
            Debug.LogWarning("[Argus] " + message);
        }
        
        private void LogError(string message)
        {
            Debug.LogError("[Argus] " + message);
        }
    }
}
