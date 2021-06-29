using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ParallaxQualityLibrary;
using UnityEngine;

[assembly: KSPAssembly("Parallax", 1, 0)]
[assembly: KSPAssemblyDependency("ParallaxSubdivisionMod", 1, 0)]
[assembly: KSPAssemblyDependency("ParallaxQualityLibrary", 1, 0)]
namespace Parallax
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    public class ShaderHolder : MonoBehaviour
    {
        public static Dictionary<string, Shader> shaders = new Dictionary<string, Shader>();
        public void Awake()
        {
            string filePath = Path.Combine(KSPUtil.ApplicationRootPath + "GameData/" + "Parallax/Shaders/Parallax");
            if (Application.platform == RuntimePlatform.LinuxPlayer || (Application.platform == RuntimePlatform.WindowsPlayer && SystemInfo.graphicsDeviceVersion.StartsWith("OpenGL")))
            {
                filePath = (filePath + "-linux.unity3d");
            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                filePath = (filePath + "-windows.unity3d");
            }
            if (Application.platform == RuntimePlatform.OSXPlayer)
            {
                filePath = (filePath + "-macosx.unity3d");
            }
            var assetBundle = AssetBundle.LoadFromFile(filePath);
            Debug.Log("Loaded bundle");
            if (assetBundle == null)
            {
                Debug.Log("Failed to load bundle at");
                Debug.Log("Path: " + filePath);
            }
            else
            {
                Shader[] theseShaders = assetBundle.LoadAllAssets<Shader>();
                Debug.Log("Loaded all shaders");
                foreach (Shader thisShader in theseShaders)
                {
                    shaders.Add(thisShader.name, thisShader);
                    Debug.Log("Loaded shader: " + thisShader.name);
                }
            }



            filePath = Path.Combine(KSPUtil.ApplicationRootPath + "GameData/" + "Parallax/Shaders/Wireframe");
            if (Application.platform == RuntimePlatform.LinuxPlayer || (Application.platform == RuntimePlatform.WindowsPlayer && SystemInfo.graphicsDeviceVersion.StartsWith("OpenGL")))
            {
                filePath = (filePath + "-linux.unity3d");
            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer)
            {
                filePath = (filePath + "-windows.unity3d");
            }
            if (Application.platform == RuntimePlatform.OSXPlayer)
            {
                filePath = (filePath + "-macosx.unity3d");
            }
            var assetBundle2 = AssetBundle.LoadFromFile(filePath);
            Debug.Log("Loaded bundle");
            if (assetBundle2 == null)
            {
                Debug.Log("Failed to load bundle at");
                Debug.Log("Path: " + filePath);
            }
            else
            {
                Shader[] theseShaders = assetBundle2.LoadAllAssets<Shader>();
                Debug.Log("Loaded all shaders");
                foreach (Shader thisShader in theseShaders)
                {
                    shaders.Add(thisShader.name, thisShader);
                    Debug.Log("Loaded shader: " + thisShader.name);
                }
            }

        }
        public static Shader GetShader(string name)
        {
            Debug.Log("Returning shader: " + shaders[name] + " // " + name + " // " + shaders[name].name);
            return shaders[name];
        }
    }
    
    //public class Parallax
    //{
    //    public string name;
    //    public string[] shaderVars;
    //    public string[] globalVars;
    //    public static Parallax DetermineVersion(bool scaled, bool part, int quality)
    //    {
    //        if (scaled == true)
    //        {
    //            if (quality == 3)
    //            {
    //                return new ParallaxScaled();
    //            }
    //            else
    //            {
    //                return new ParallaxScaledLow();
    //            }
    //
    //        }
    //        if (part == true)
    //        {
    //            if (quality == 3)
    //            {
    //                return new ParallaxPartUltra();
    //            }
    //            else
    //            {
    //                return new ParallaxPartLow();
    //            }
    //        }
    //        if (scaled == false && part == false)
    //        {
    //            if (quality == 0)
    //            {
    //                return new ParallaxLow();
    //            }
    //            if (quality == 1 || quality == 2)
    //            {
    //                return new ParallaxMed();
    //            }
    //            if (quality == 3)
    //            {
    //                return new ParallaxUltra();
    //            }
    //        }
    //        ParallaxLog.Log("Unable to determine shader quality - Automatically setting shader quality to low");
    //        return new ParallaxLow();
    //    }
    //}
    //public class ParallaxLow : Parallax
    //{
    //    public ParallaxLow()
    //    {
    //        name = "Custom/ParallaxLow";
    //        shaderVars = new string[]
    //        {
    //            "_SurfaceTexture",
    //            "_SurfaceTextureScale",
    //            "_BumpMap",
    //            "_InfluenceMap",
    //            "_Metallic",
    //            "_MetallicTint",
    //            "_NormalSpecularInfluence",
    //            "_Hapke",
    //            "zoom1",
    //            "zoom2",
    //            "zoom3",
    //            "zoom4",
    //            "zoom5",
    //            "zoom6",
    //            "zoom7",
    //        };
    //        globalVars = new string[0];
    //        ParallaxLog.Log("Using Parallax (Low)");
    //    }
    //}
    //public class ParallaxMed : Parallax
    //{
    //    //Shader Variables
    //    public ParallaxMed()
    //    {
    //        name = "Custom/ParallaxMedium";
    //        shaderVars = new string[]
    //        {
    //            "_SurfaceTexture",
    //            "_SurfaceTextureScale",
    //            "_BumpMap",
    //            "_InfluenceMap",
    //            "_Metallic",
    //            "_MetallicTint",
    //            "_NormalSpecularInfluence",
    //            "_Hapke",
    //            "zoom1",
    //            "zoom2",
    //            "zoom3",
    //            "zoom4",
    //            "zoom5",
    //            "zoom6",
    //            "zoom7",
    //        };
    //        globalVars = new string[0];
    //        ParallaxLog.Log("Using Parallax (Med)");
    //    }
    //}
    //public class ParallaxUltra : Parallax
    //{
    //    //Shader Variables
    //    public ParallaxUltra()
    //    {
    //        name = "Custom/Parallax";
    //        shaderVars = new string[]
    //        {
    //            "_SurfaceTexture",
    //            "_SurfaceTextureScale",
    //            "_SteepTex",
    //            "_BumpMap",
    //            "_BumpMapSteep",
    //            "_DispTex",
    //            "_InfluenceMap",
    //            "_Metallic",
    //            "_MetallicTint",
    //            "_NormalSpecularInfluence",
    //            "_SteepPower",
    //            "_displacement_scale",
    //            "_displacement_offset",
    //            "_Hapke",
    //            "zoom1",
    //            "zoom2",
    //            "zoom3",
    //            "zoom4",
    //            "zoom5",
    //            "zoom6",
    //            "zoom7",
    //        };
    //        globalVars = new string[]
    //        {
    //            "_TessellationEdgeLength",
    //            "_TessellationRange",
    //            "_MaxTessellation"
    //        };
    //        ParallaxLog.Log("Using Parallax (Ultra)");
    //    }
    //}
    //public class ParallaxPartUltra : Parallax
    //{
    //    public ParallaxPartUltra()
    //    {
    //        name = "Custom/ParallaxAsteroid";
    //        shaderVars = new string[]
    //        {
    //            "_SurfaceTexture",
    //            "_SurfaceTextureScale",
    //            "_BumpMap",
    //            "_DispTex",
    //            "_InfluenceMap",
    //            "_Metallic",
    //            "_MetallicTint",
    //            "_NormalSpecularInfluence",
    //            "_displacement_scale",
    //            "_displacement_offset",
    //            "_Hapke",
    //            "zoom1",
    //            "zoom2",
    //            "zoom3",
    //            "zoom4",
    //            "zoom5",
    //            "zoom6",
    //            "zoom7",
    //        };
    //        globalVars = new string[]
    //        {
    //            "_TessellationEdgeLength",
    //            "_TessellationRange",
    //            "_MaxTessellation"
    //        };
    //        ParallaxLog.Log("Using ParallaxPart (Ultra)");
    //    }
    //}
    //public class ParallaxPartLow : Parallax
    //{
    //    public ParallaxPartLow()
    //    {
    //        name = "Custom/ParallaxAsteroidLow";
    //        shaderVars = new string[]
    //        {
    //            "_SurfaceTexture",
    //            "_SurfaceTextureScale",
    //            "_BumpMap",
    //            "_InfluenceMap",
    //            "_Metallic",
    //            "_MetallicTint",
    //            "_NormalSpecularInfluence",
    //            "_Hapke",
    //            "zoom1",
    //            "zoom2",
    //            "zoom3",
    //            "zoom4",
    //            "zoom5",
    //            "zoom6",
    //            "zoom7",
    //        };
    //        globalVars = new string[]
    //        {
    //            //No tessellation for the low stuff
    //        };
    //        ParallaxLog.Log("Using ParallaxPart (Low)");
    //    }
    //}
    //public class ParallaxScaled : Parallax
    //{
    //    public ParallaxScaled()
    //    {
    //        name = "Custom/ParallaxScaled";
    //        shaderVars = new string[]
    //        {
    //            "_ColorMap",
    //            "_NormalMap",
    //            "_HeightMap",
    //            "_InfluenceMap",
    //            "_SurfaceTexture",
    //            "_BumpMap",
    //            "_SurfaceTextureScale",
    //            "_Metallic",
    //            "_MetallicTint",
    //            "_NormalSpecularInfluence",
    //            "_displacement_scale",
    //            "_displacement_offset",
    //            "_Hapke",
    //        };
    //        globalVars = new string[]
    //        {
    //            "_TessellationEdgeLength",
    //            "_TessellationRange",
    //            "_MaxTessellation"
    //        };
    //        ParallaxLog.Log("Using ParallaxScaled (Ultra)");
    //    }
    //}
    //public class ParallaxScaledLow : Parallax
    //{
    //    public ParallaxScaledLow()
    //    {
    //        name = "Custom/ParallaxScaledLow";
    //        shaderVars = new string[]
    //        {
    //            "_ColorMap",
    //            "_NormalMap",
    //            "_HeightMap",
    //            "_InfluenceMap",
    //            "_SurfaceTexture",
    //            "_BumpMap",
    //            "_SurfaceTextureScale",
    //            "_Metallic",
    //            "_MetallicTint",
    //            "_NormalSpecularInfluence",
    //            "_displacement_scale",
    //            "_displacement_offset",
    //            "_Hapke",
    //        };
    //        globalVars = new string[]
    //        {
    //            //No tessellation for the low stuff
    //        };
    //        ParallaxLog.Log("Using ParallaxScaled (Low)");
    //    }
    //}
    public class ParallaxBodies
    {
        public static Dictionary<string, ParallaxBody> parallaxBodies = new Dictionary<string, ParallaxBody>();
    }
    //public class ParallaxBody
    //{
    //    public string bodyName;
    //    public ParallaxQualityLibrary.Parallax shaderVars;
    //    public ParallaxBodyMaterial properties;
    //    public ParallaxBody()
    //    {
    //
    //    }
    //    public ParallaxBody(string name)
    //    {
    //        bodyName = name;
    //        properties = new ParallaxPlanetMaterial();
    //        ParallaxLog.SubLog("Created body: " + bodyName);
    //    }
    //}
    //public class ScaledParallaxBody : ParallaxBody
    //{
    //    public GameObject scaledBody;
    //    public GameObject localBody;
    //    public float localFadeStart;
    //    public float localFadeEnd;
    //    public float scaledFadeStart;
    //    public float scaledFadeEnd;
    //    public ScaledParallaxBody(string name)
    //    {
    //        bodyName = name;
    //        properties = new ScaledParallaxBodyMaterial();
    //        ParallaxLog.SubLog("Created scaled body: " + bodyName);
    //    }
    //    public void SetScaledValues(ConfigNode node)
    //    {
    //        localFadeStart = float.Parse(node.GetValue("fadeStart"));
    //        localFadeEnd = float.Parse(node.GetValue("fadeEnd"));
    //
    //        scaledFadeStart = float.Parse(node.GetValue("trueScaledFadeStart"));
    //        scaledFadeEnd = float.Parse(node.GetValue("trueScaledFadeEnd"));
    //    }
    //}
    //public class PartParallaxBody : ParallaxBody
    //{
    //    public PartParallaxBody(string name)
    //    {
    //        bodyName = name;
    //        properties = new PartParallaxMaterial();
    //        ParallaxLog.SubLog("Created part: " + bodyName);
    //    }
    //}
    public class ParallaxBodyMaterial
    {
        public Material material;

        public Vector2 _SurfaceTextureScale { get; set; }

        public string _SurfaceTexture { get; set; }


        
        
    }
    [KSPAddon(KSPAddon.Startup.PSystemSpawn, true)]
    public class Loader : MonoBehaviour
    {
        public UrlDir.UrlConfig[] globalNodes;
        public UrlDir.UrlConfig[] globalPlanetManagerNodes;
        public void Start()
        {
            globalPlanetManagerNodes = FetchGlobalNodes("ParallaxBodyManager");
            globalNodes = FetchGlobalNodes("Parallax");
            DetermineParallaxType();
            LoadAllNodes();
        }
        public void DetermineParallaxType()
        {
            int terrainShaderQuality = GameSettings.TERRAIN_SHADER_QUALITY;
            for (int i = 0; i < globalPlanetManagerNodes.Length; i++)   //ParallaxBodyManager
            {
                ConfigNode[] nodes = globalPlanetManagerNodes[i].config.GetNodes("Planet");
                for (int b = 0; b < nodes.Length; b++)  //For every planet, determine quality and assign appropriate variables
                {
                    string name = nodes[b].GetValue("name");
                    ParallaxBody body = new ParallaxBody(name, terrainShaderQuality);
                    //body.shaderVars = Parallax.DetermineVersion(false, false, GameSettings.TERRAIN_SHADER_QUALITY);
                    ParallaxBodies.parallaxBodies.Add(name, body);
                }
            }
        }
        public static UrlDir.UrlConfig[] FetchGlobalNodes(string configName)
        {
            return GameDatabase.Instance.GetConfigs(configName);
        }
        public void LoadAllNodes()
        {
            for (int i = 0; i < globalNodes.Length; i++)
            {
                for (int b = 0; b < globalNodes[i].config.nodes.Count; b++)
                {
                    ConfigNode rootNode = globalNodes[i].config;
                    string bodyName = rootNode.nodes[b].GetValue("name");
                    ParallaxLog.Log("Parsing " + bodyName);
                    ParallaxBody body = new ParallaxBody(bodyName, GameSettings.TERRAIN_SHADER_QUALITY);
                    ParallaxBodies.parallaxBodies.Add(bodyName, body);
                    ConfigNode bodyNode = rootNode.nodes[b].GetNode("Textures");
                    ParseNewBody(bodyNode, bodyName);
                }
            }
        }
        public void ParseNewBody(ConfigNode node, string name)
        {
            ParallaxBody body = ParallaxBodies.parallaxBodies[name];           //This can be a standard, scaled or part body
            body.singleLow.parallaxMaterial = new Material(ShaderHolder.GetShader(body.singleLow.shaderName));
            body.singleMid.parallaxMaterial = new Material(ShaderHolder.GetShader(body.singleMid.shaderName));
            body.singleHigh.parallaxMaterial = new Material(ShaderHolder.GetShader(body.singleHigh.shaderName));

            body.singleSteepLow.parallaxMaterial = new Material(ShaderHolder.GetShader(body.singleSteepLow.shaderName));
            body.singleSteepMid.parallaxMaterial = new Material(ShaderHolder.GetShader(body.singleSteepMid.shaderName));
            body.singleSteepHigh.parallaxMaterial = new Material(ShaderHolder.GetShader(body.singleSteepHigh.shaderName));

            body.doubleLow.parallaxMaterial = new Material(ShaderHolder.GetShader(body.doubleLow.shaderName));
            body.doubleHigh.parallaxMaterial = new Material(ShaderHolder.GetShader(body.doubleHigh.shaderName));
            body.full.parallaxMaterial = new Material(ShaderHolder.GetShader(body.full.shaderName));

            //Iterate through all materials

            foreach(PropertyInfo property in body.GetType().GetProperties()) //get all shader properties
            {
                ParallaxLog.SubLog("Parsing " + property.Name + property.GetValue(body));
                if (property.PropertyType != typeof(ParallaxQualityLibrary.Parallax))
                {
                    //Now start setting the variables
                    object materialValue = ParseType(property.Name, node.GetValue(property.Name));
                    PropertyInfo materialType = body.GetType().GetProperty(property.Name);
                    ConvertAndSetType(materialType, materialValue, body);
                }
            }
            

        }
        public void ConvertAndSetType(PropertyInfo property, object value, ParallaxBody body)
        {
            Debug.Log("Property type: " + property.PropertyType);
            if (property.PropertyType == typeof(Vector2))
            {
                ParallaxLog.SubLog("Setting " + property.Name + " to " + value);
                body.GetType().GetProperty(property.Name).SetValue(body, (Vector2)value);
            }
            if (property.PropertyType == typeof(float))
            {
                ParallaxLog.SubLog("Setting " + property.Name + " to " + value);
                body.GetType().GetProperty(property.Name).SetValue(body, (float)value);
            }
            if (property.PropertyType == typeof(Color))
            {
                ParallaxLog.SubLog("Setting " + property.Name + " to " + value);
                body.GetType().GetProperty(property.Name).SetValue(body, (Color)value);
            }
            if (property.PropertyType == typeof(string))
            {
                ParallaxLog.SubLog("Setting " + property.Name + " to " + value);
                body.GetType().GetProperty(property.Name).SetValue(body, (string)value);
            }
        }
        public static object ParseType(string name, string value)
        {
            //Vector2, string, float, color
            //if (name.Contains("TextureScale"))
            //{
            //    string[] vectorComponents = value.Replace(" ", string.Empty).Split(',');
            //    return new Vector2(float.Parse(vectorComponents[0]), float.Parse(vectorComponents[1]));
            //}
            if (value.Contains("/"))
            {
                return value;
            }
            if (name == "_MetallicTint")
            {
                string[] vectorComponents = value.Replace(" ", string.Empty).Split(',');
                return new Color(float.Parse(vectorComponents[0]), float.Parse(vectorComponents[1]), float.Parse(vectorComponents[2]));
            }
            return float.Parse(value);
        }
        
    }
    public class TextureLoader
    {
        public static Texture2D LoadTexture(string name)
        {
            Debug.Log("Loading Parallax Texture: " + name);
            Texture2D output;
            string filePath = KSPUtil.ApplicationRootPath + "GameData/" + name;
            if (name.EndsWith(".dds"))
            {
                output = TextureLoader.LoadDDSTexture(filePath);
            }
            else
            {
                output = TextureLoader.LoadPNGTexture(filePath);
            }
            return output;
        }
        public static Texture2D LoadPNGTexture(string url)
        {
            Texture2D tex;
            tex = new Texture2D(2, 2);
            tex.LoadRawTextureData(File.ReadAllBytes(url));
            tex.Apply();
            return tex;
        }
        public static Texture2D LoadDDSTexture(string url)
        {
            byte[] data = File.ReadAllBytes(url);
            byte ddsSizeCheck = data[4];
            if (ddsSizeCheck != 124)
            {
                Debug.Log("This DDS texture is invalid - Unable to read the size check value from the header.");
            }


            int height = data[13] * 256 + data[12];
            int width = data[17] * 256 + data[16];


            int DDS_HEADER_SIZE = 128;
            byte[] dxtBytes = new byte[data.Length - DDS_HEADER_SIZE];
            Buffer.BlockCopy(data, DDS_HEADER_SIZE, dxtBytes, 0, data.Length - DDS_HEADER_SIZE);
            int mipMapCount = (data[28]) | (data[29] << 8) | (data[30] << 16) | (data[31] << 24);

            TextureFormat format = TextureFormat.DXT1;
            if (data[84] == 'D')
            {

                if (data[87] == 49) //Also char '1'
                {
                    format = TextureFormat.DXT1;
                }
                else if (data[87] == 53)    //Also char '5'
                {
                    format = TextureFormat.DXT5;
                }
                else
                {
                    Debug.Log("Texture is not a DXT 1 or DXT5");
                }
            }
            Texture2D texture;
            if (mipMapCount == 1)
            {
                texture = new Texture2D(width, height, format, false);
            }
            else
            {
                texture = new Texture2D(width, height, format, true);
            }
            try
            {
                texture.LoadRawTextureData(dxtBytes);
            }
            catch
            {
                Debug.Log("CRITICAL ERROR: Parallax has halted the OnDemand loading process because texture.LoadRawTextureData(dxtBytes) would have resulted in overread");
                Debug.Log("Please check the format for this texture and refer to the wiki if you're unsure:");
            }
            texture.Apply();

            return (texture);
        }
    }
    [KSPAddon(KSPAddon.Startup.FlightAndKSC, false)]
    public class ParallaxInFlightOperations : MonoBehaviour
    {
        string previousBody = "undefinedparallaxbody";
        public Dictionary<string, Texture2D> activeTextures = new Dictionary<string, Texture2D>();
        public void Start()
        {
            QualitySettings.shadowDistance = 10000;
            QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
            QualitySettings.shadowProjection = ShadowProjection.StableFit;
            QualitySettings.shadows = ShadowQuality.All;
            QualitySettings.shadowCascade4Split = new Vector3(0.002f, 0.022f, 0.178f);
            Camera.main.nearClipPlane = 0.1f;
            Camera.current.nearClipPlane = 0.1f;
        }
        public void Update()
        {
            string currentBody = FlightGlobals.currentMainBody.name;
            if (ParallaxBodies.parallaxBodies.ContainsKey(currentBody) && !MapView.MapIsEnabled)
            {
                CheckIfBodySwitched(currentBody);
                //We need to set the following varaibles:
                //_PlanetOpacity, _SurfaceTextureUVs, _PlanetOrigin
                float planetOpacity = FlightGlobals.currentMainBody.pqsController.surfaceMaterial.GetFloat("_PlanetOpacity");
                ParallaxBodies.parallaxBodies[currentBody].singleLow.parallaxMaterial.SetFloat("_PlanetOpacity", planetOpacity);
                ParallaxBodies.parallaxBodies[currentBody].singleMid.parallaxMaterial.SetFloat("_PlanetOpacity", planetOpacity);
                ParallaxBodies.parallaxBodies[currentBody].singleHigh.parallaxMaterial.SetFloat("_PlanetOpacity", planetOpacity);
                ParallaxBodies.parallaxBodies[currentBody].singleSteepLow.parallaxMaterial.SetFloat("_PlanetOpacity", planetOpacity);
                ParallaxBodies.parallaxBodies[currentBody].singleSteepMid.parallaxMaterial.SetFloat("_PlanetOpacity", planetOpacity);
                ParallaxBodies.parallaxBodies[currentBody].singleSteepHigh.parallaxMaterial.SetFloat("_PlanetOpacity", planetOpacity);
                ParallaxBodies.parallaxBodies[currentBody].doubleLow.parallaxMaterial.SetFloat("_PlanetOpacity", planetOpacity);
                ParallaxBodies.parallaxBodies[currentBody].doubleHigh.parallaxMaterial.SetFloat("_PlanetOpacity", planetOpacity);
                ParallaxBodies.parallaxBodies[currentBody].full.parallaxMaterial.SetFloat("_PlanetOpacity", planetOpacity);
                

                Vector3d accuratePlanetPosition = FlightGlobals.currentMainBody.position;   //Double precision planet origin
                double surfaceTexture_ST = ParallaxBodies.parallaxBodies[FlightGlobals.currentMainBody.name]._SurfaceTextureScale;    //Scale of surface texture
                Vector3d UV = accuratePlanetPosition * surfaceTexture_ST;
                float cameraAltitude = GetHeightFromTerrain(Camera.allCameras.FirstOrDefault(_cam => _cam.name == "Camera 00").transform);
                UV = new Vector3d(Clamp(UV.x, cameraAltitude), Clamp(UV.y, cameraAltitude), Clamp(UV.z, cameraAltitude));
                Vector3 floatUV = new Vector3((float)UV.x, (float)UV.y, (float)UV.z);


                ParallaxBodies.parallaxBodies[currentBody].singleLow.parallaxMaterial.SetVector("_SurfaceTextureUVs", floatUV);
                ParallaxBodies.parallaxBodies[currentBody].singleMid.parallaxMaterial.SetVector("_SurfaceTextureUVs", floatUV);
                ParallaxBodies.parallaxBodies[currentBody].singleHigh.parallaxMaterial.SetVector("_SurfaceTextureUVs", floatUV);
                ParallaxBodies.parallaxBodies[currentBody].singleSteepLow.parallaxMaterial.SetVector("_SurfaceTextureUVs", floatUV);
                ParallaxBodies.parallaxBodies[currentBody].singleSteepMid.parallaxMaterial.SetVector("_SurfaceTextureUVs", floatUV);
                ParallaxBodies.parallaxBodies[currentBody].singleSteepHigh.parallaxMaterial.SetVector("_SurfaceTextureUVs", floatUV);
                ParallaxBodies.parallaxBodies[currentBody].doubleLow.parallaxMaterial.SetVector("_SurfaceTextureUVs", floatUV);
                ParallaxBodies.parallaxBodies[currentBody].doubleHigh.parallaxMaterial.SetVector("_SurfaceTextureUVs", floatUV);
                ParallaxBodies.parallaxBodies[currentBody].full.parallaxMaterial.SetVector("_SurfaceTextureUVs", floatUV);

                Vector3 planetOrigin = FlightGlobals.currentMainBody.transform.position;

                ParallaxBodies.parallaxBodies[currentBody].singleLow.parallaxMaterial.SetVector("_PlanetOrigin", planetOrigin);
                ParallaxBodies.parallaxBodies[currentBody].singleMid.parallaxMaterial.SetVector("_PlanetOrigin", planetOrigin);
                ParallaxBodies.parallaxBodies[currentBody].singleHigh.parallaxMaterial.SetVector("_PlanetOrigin", planetOrigin);
                ParallaxBodies.parallaxBodies[currentBody].singleSteepLow.parallaxMaterial.SetVector("_PlanetOrigin", planetOrigin);
                ParallaxBodies.parallaxBodies[currentBody].singleSteepMid.parallaxMaterial.SetVector("_PlanetOrigin", planetOrigin);
                ParallaxBodies.parallaxBodies[currentBody].singleSteepHigh.parallaxMaterial.SetVector("_PlanetOrigin", planetOrigin);
                ParallaxBodies.parallaxBodies[currentBody].doubleLow.parallaxMaterial.SetVector("_PlanetOrigin", planetOrigin);
                ParallaxBodies.parallaxBodies[currentBody].doubleHigh.parallaxMaterial.SetVector("_PlanetOrigin", planetOrigin);
                ParallaxBodies.parallaxBodies[currentBody].full.parallaxMaterial.SetVector("_PlanetOrigin", planetOrigin);
            }
        }
        public void CheckIfBodySwitched(string bodyName)
        {
            if (bodyName != previousBody)
            {
                UnloadTextures(bodyName);
                activeTextures.Clear();
                previousBody = bodyName;
                ParallaxBody thisBody = ParallaxBodies.parallaxBodies[bodyName];
                float planetRadius = (float)FlightGlobals.currentMainBody.Radius;
                thisBody.singleLow.parallaxMaterial.SetFloat("_PlanetRadius", planetRadius);
                thisBody.singleMid.parallaxMaterial.SetFloat("_PlanetRadius", planetRadius);
                thisBody.singleHigh.parallaxMaterial.SetFloat("_PlanetRadius", planetRadius);
                thisBody.singleSteepLow.parallaxMaterial.SetFloat("_PlanetRadius", planetRadius);
                thisBody.singleSteepMid.parallaxMaterial.SetFloat("_PlanetRadius", planetRadius);
                thisBody.singleSteepHigh.parallaxMaterial.SetFloat("_PlanetRadius", planetRadius);
                thisBody.doubleLow.parallaxMaterial.SetFloat("_PlanetRadius", planetRadius);
                thisBody.doubleHigh.parallaxMaterial.SetFloat("_PlanetRadius", planetRadius);
                thisBody.full.parallaxMaterial.SetFloat("_PlanetRadius", planetRadius);

                
                //Gotta start loading on demand - Destroy the previous textures then determine the textures that need loading now
                //Basically create all the materials for a planet
                //foreach (PropertyInfo planetValue in ParallaxBodies.parallaxBodies[bodyName].GetType().GetProperties())
                //{
                //
                //}
                foreach (PropertyInfo shader in thisBody.GetType().GetProperties())
                {
                    ParallaxLog.SubLog("Parsing shader " + shader);
                    if (shader.PropertyType == typeof(ParallaxQualityLibrary.Parallax))
                    {
                        ParallaxQualityLibrary.Parallax physicalShader = (ParallaxQualityLibrary.Parallax)shader.GetValue(thisBody);
                        foreach (string shaderVar in physicalShader.shaderVars)
                        {
                            string valueToReplaceWith = shaderVar;
                            if (physicalShader.specificVars.ContainsKey(shaderVar))
                            {
                                valueToReplaceWith = (physicalShader.specificVars[shaderVar]);
                            }
                            //Set shaderVar to valueToReplaceWith
                            ParallaxLog.SubLog("Parsing shaderVar " + shaderVar + " which will be replaced with " + valueToReplaceWith);
                            //Debug.Log("Value is actually " + thisBody._SurfaceTexture);
                            Debug.Log("Retreived value as: " + thisBody.GetType().GetProperty(valueToReplaceWith).GetValue(thisBody).ToString());
                            object storedVar = thisBody.GetType().GetProperty(valueToReplaceWith).GetValue(thisBody);
                            ParallaxLog.SubLog("StoredVar: " + storedVar);
                            Debug.Log("Shader instance name is " + shader.Name);
                            ParallaxQualityLibrary.Parallax thisShaderInstance = (ParallaxQualityLibrary.Parallax)thisBody.GetType().GetProperty(shader.Name).GetValue(thisBody);
                            Debug.Log("Shader instance is " + thisShaderInstance);
                            Material shaderMat = (Material)thisShaderInstance.GetType().GetProperty("parallaxMaterial").GetValue(thisShaderInstance);
                            Debug.Log("Shadermat: " + shaderMat);
                            Type propertyType = thisBody.GetType().GetProperty(shaderVar).GetType();
                            Debug.Log(shaderVar + " is a " + propertyType);
                            ConvertAndSetMaterialType(shaderMat, storedVar, propertyType, shaderVar);
                            //Now set the values in the shader's material
                            //((ParallaxQualityLibrary.Parallax)shader.GetValue(thisBody)).parallaxMaterial
                        }
                    }
                }
            }
        }
        public void UnloadTextures(string bodyName)
        {
            
            foreach (ParallaxBody body in ParallaxBodies.parallaxBodies.Values)
            {
                if (body.bodyName != bodyName)
                {
                    Debug.Log("Unloading textures for " + body.bodyName);
                    //Unload for everything except this planet
                    Destroy(body.singleLow.parallaxMaterial.GetTexture("_SurfaceTexture"));
                    Destroy(body.singleLow.parallaxMaterial.GetTexture("_BumpMap"));
                    Destroy(body.singleLow.parallaxMaterial.GetTexture("_InfluenceMap"));
                    Destroy(body.singleLow.parallaxMaterial.GetTexture("_DispTex"));

                    Destroy(body.singleMid.parallaxMaterial.GetTexture("_SurfaceTexture"));
                    Destroy(body.singleMid.parallaxMaterial.GetTexture("_BumpMap"));
                    Destroy(body.singleMid.parallaxMaterial.GetTexture("_InfluenceMap"));
                    Destroy(body.singleMid.parallaxMaterial.GetTexture("_DispTex"));

                    Destroy(body.singleHigh.parallaxMaterial.GetTexture("_SurfaceTexture"));
                    Destroy(body.singleHigh.parallaxMaterial.GetTexture("_BumpMap"));
                    Destroy(body.singleHigh.parallaxMaterial.GetTexture("_InfluenceMap"));
                    Destroy(body.singleHigh.parallaxMaterial.GetTexture("_DispTex"));

                    Destroy(body.singleSteepLow.parallaxMaterial.GetTexture("_SurfaceTexture"));
                    Destroy(body.singleSteepLow.parallaxMaterial.GetTexture("_SteepTex"));
                    Destroy(body.singleSteepLow.parallaxMaterial.GetTexture("_BumpMap"));
                    Destroy(body.singleSteepLow.parallaxMaterial.GetTexture("_BumpMapSteep"));
                    Destroy(body.singleSteepLow.parallaxMaterial.GetTexture("_InfluenceMap"));
                    Destroy(body.singleSteepLow.parallaxMaterial.GetTexture("_DispTex"));

                    Destroy(body.singleSteepMid.parallaxMaterial.GetTexture("_SurfaceTexture"));
                    Destroy(body.singleSteepMid.parallaxMaterial.GetTexture("_SteepTex"));
                    Destroy(body.singleSteepMid.parallaxMaterial.GetTexture("_BumpMap"));
                    Destroy(body.singleSteepMid.parallaxMaterial.GetTexture("_BumpMapSteep"));
                    Destroy(body.singleSteepMid.parallaxMaterial.GetTexture("_InfluenceMap"));
                    Destroy(body.singleSteepMid.parallaxMaterial.GetTexture("_DispTex"));

                    Destroy(body.singleSteepHigh.parallaxMaterial.GetTexture("_SurfaceTexture"));
                    Destroy(body.singleSteepHigh.parallaxMaterial.GetTexture("_SteepTex"));
                    Destroy(body.singleSteepHigh.parallaxMaterial.GetTexture("_BumpMap"));
                    Destroy(body.singleSteepHigh.parallaxMaterial.GetTexture("_BumpMapSteep"));
                    Destroy(body.singleSteepHigh.parallaxMaterial.GetTexture("_InfluenceMap"));
                    Destroy(body.singleSteepHigh.parallaxMaterial.GetTexture("_DispTex"));

                    Destroy(body.doubleLow.parallaxMaterial.GetTexture("_SurfaceTexture"));
                    Destroy(body.doubleLow.parallaxMaterial.GetTexture("_SurfaceTextureMid"));
                    Destroy(body.doubleLow.parallaxMaterial.GetTexture("_SteepTex"));
                    Destroy(body.doubleLow.parallaxMaterial.GetTexture("_BumpMap"));
                    Destroy(body.doubleLow.parallaxMaterial.GetTexture("_BumpMapMid"));
                    Destroy(body.doubleLow.parallaxMaterial.GetTexture("_BumpMapSteep"));
                    Destroy(body.doubleLow.parallaxMaterial.GetTexture("_InfluenceMap"));
                    Destroy(body.doubleLow.parallaxMaterial.GetTexture("_DispTex"));

                    Destroy(body.doubleHigh.parallaxMaterial.GetTexture("_SurfaceTextureMid"));
                    Destroy(body.doubleHigh.parallaxMaterial.GetTexture("_SurfaceTextureHigh"));
                    Destroy(body.doubleHigh.parallaxMaterial.GetTexture("_SteepTex"));
                    Destroy(body.doubleHigh.parallaxMaterial.GetTexture("_BumpMapMid"));
                    Destroy(body.doubleHigh.parallaxMaterial.GetTexture("_BumpMapHigh"));
                    Destroy(body.doubleHigh.parallaxMaterial.GetTexture("_BumpMapSteep"));
                    Destroy(body.doubleHigh.parallaxMaterial.GetTexture("_InfluenceMap"));
                    Destroy(body.doubleHigh.parallaxMaterial.GetTexture("_DispTex"));

                    Destroy(body.full.parallaxMaterial.GetTexture("_SurfaceTexture"));
                    Destroy(body.full.parallaxMaterial.GetTexture("_SurfaceTextureMid"));
                    Destroy(body.full.parallaxMaterial.GetTexture("_SurfaceTextureHigh"));
                    Destroy(body.full.parallaxMaterial.GetTexture("_SteepTex"));
                    Destroy(body.full.parallaxMaterial.GetTexture("_BumpMap"));
                    Destroy(body.full.parallaxMaterial.GetTexture("_BumpMapMid"));
                    Destroy(body.full.parallaxMaterial.GetTexture("_BumpMapHigh"));
                    Destroy(body.full.parallaxMaterial.GetTexture("_BumpMapSteep"));
                    Destroy(body.full.parallaxMaterial.GetTexture("_InfluenceMap"));
                    Destroy(body.full.parallaxMaterial.GetTexture("_DispTex"));
                }
            }

            

            Debug.Log("Completed texture unload");

        }
        public void ConvertAndSetMaterialType(Material shaderMat, object value, Type property, string name)
        {
            Debug.Log("Property type: " + property);
            //if (value is Vector2)
            //{
            //    ParallaxLog.SubLog("Setting " + property.Name + " to " + value);
            //    shaderMat.SetTextureScale(name, (Vector2)value);
            //}
            if (value is float)
            {
                if (name.Contains("TextureScale"))
                {
                    ParallaxLog.SubLog("Setting texture scale " + name + " to " + (float)value);
                    if (shaderMat.shader.name.Contains("DOUBLEHIGH"))
                    {
                        ParallaxLog.SubLog("Doublehigh detected");
                        name = "_SurfaceTextureMidScale";
                    }
                    shaderMat.SetTextureScale(name.Remove(name.Length - 5, 5), new Vector2((float)value, (float)value));
                    return;
                }
                ParallaxLog.SubLog("Setting " + property.Name + " to " + value);
                shaderMat.SetFloat(name, (float)value);
            }
            if (value is Color)
            {
                ParallaxLog.SubLog("Setting " + property.Name + " to " + value);
                shaderMat.SetColor(name, (Color)value);
            }
            if (value is string)
            {
                if (activeTextures.ContainsKey((string)value))
                {
                    //Texture is already loaded from a previous shader, we don't need to load it again!!!
                    shaderMat.SetTexture(name, activeTextures[(string)value]);
                    Debug.Log("We're not loading a texture!!!!");
                    return;
                }
                Debug.Log("We're loading a texture!!!!");
                ParallaxLog.SubLog("Setting " + property.Name + " to " + value);
                activeTextures.Add((string)value, TextureLoader.LoadTexture((string)value));
                shaderMat.SetTexture(name, activeTextures[(string)value]);
            }
        }
        public double Clamp(double input, float cameraAltitude)
        {
            if (cameraAltitude < 250 && cameraAltitude != 0)
            {
                return input % 256;  //When close to the ground, 
            }
            if (cameraAltitude == 0)  //Outside ray dir
            {
                return input % 65536;
            }
            return input % 65536;
        }
        public float GetHeightFromTerrain(Transform pos)    //Use fancy raycasting to achieve fancy things
        {
            float heightFromTerrain = 0;
            Vector3 vector = FlightGlobals.getUpAxis(FlightGlobals.currentMainBody, pos.position);
            float num = FlightGlobals.getAltitudeAtPos(pos.position, FlightGlobals.currentMainBody);
            if (num < 0f)
            {
                //Camera is underwater 
            }
            num += 600f;
            RaycastHit heightFromTerrainHit;
            if (Physics.Raycast(pos.position, -vector, out heightFromTerrainHit, num, 32768, QueryTriggerInteraction.Ignore))
            {
                heightFromTerrain = heightFromTerrainHit.distance;
                //this.objectUnderVessel = heightFromTerrainHit.collider.gameObject;
            }
            return heightFromTerrain;
        }
    }
    public class MakeWireframe : MonoBehaviour
    {
        // Start is called before the first frame update
        void OnPreRender()
        {
            //GL.wireframe = true;
        }

        // Update is called once per frame
        void OnPostRender()
        {
           // GL.wireframe = false;
        }
    }
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class StartWireframe : MonoBehaviour
    {
        public void Start()
        {
            Camera.allCameras.FirstOrDefault(_cam => _cam.name == "Camera 00").gameObject.AddComponent<MakeWireframe>();
            Debug.Log("Wireframe started");
        }
    }

    //public class ModuleParallax : PartModule
    //{
    //    private MeshRenderer partMeshRenderer;
    //    [KSPField] public string partName = null;
    //    public override void OnAwake()
    //    {
    //        if (HighLogic.LoadedScene == GameScenes.FLIGHT)
    //        {
    //            ParallaxLog.Log("OnAwake: " + partName);
    //            if (HighLogic.LoadedScene == GameScenes.FLIGHT)
    //            { 
    //                //Change to partname when I figure out partmodules properly
    //                partMeshRenderer = part.gameObject.GetComponentsInChildren<MeshRenderer>()[0];
    //                partMeshRenderer.material = ParallaxBodies.parallaxBodies["Dimorphos"].properties.material;
    //                partMeshRenderer.sharedMaterial = ParallaxBodies.parallaxBodies["Dimorphos"].properties.material;
    //                partMeshRenderer.material = Instantiate(ParallaxBodies.parallaxBodies["Dimorphos"].properties.material);
    //                partMeshRenderer.material.SetFloat("_PlanetOpacity", 0f);
    //                partMeshRenderer.material.SetFloat("_TessellationRange", 200f);
    //                partMeshRenderer.material.SetFloat("_TessellationMax", 64f);
    //                partMeshRenderer.material.SetFloat("_TessellationEdgeLength", 16f);
    //                //The values are set but since the part is not a body, its textures cannot be loaded.
    //                //We need to load its textures ourselves via the part module
    //            }
    //        }
    //
    //    }
    //}
}