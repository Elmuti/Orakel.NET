using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Reflection;
using System.Resources;
using IniParser;
using IniParser.Model;

namespace Orakel
{
    public enum Material
    {
        Air,
        Acid,
        Flesh,
        Rock,
        Concrete,
        Wood,
        WoodPlanks,
        Plastic,
        Cardboard,
        Grass,
        Ground,
        Mud,
        Water,
        Snow,
        Ice,
        Glass,
        GlassPane,
        Metal,
        MetalGrate,
        Sand,
        Fabric
    }

    public enum MaterialSound
    {
        ImpactSoft,
        ImpactMed,
        ImpactHard,
        ImpactBullet,
        Break,
        Scrape
    }

    /// <summary>
    /// Contains the physical properties of a material
    /// </summary>
    public struct MaterialData
    {
        private static Dictionary<Material, MaterialData> _materialAttributes;
        private float _density;
        private float _friction;
        private float _elasticity;

        /// <summary>
        /// Density of the material. Determines mass and buoyancy.
        /// </summary>
        public float Density    { get { return _density; } }

        /// <summary>
        /// Friction of the material.
        /// </summary>
        public float Friction   { get { return _friction; } }

        /// <summary>
        /// Determines the bounciness of the material.
        /// </summary>
        public float Elasticity { get { return _elasticity; } }

        /// <summary>
        /// Reads material physical properties from an .ini -file
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Dictionary<Material, MaterialData> ReadFromFile(string file)
        {
            Dictionary<Material, MaterialData> matAtt = new Dictionary<Material, MaterialData>();
            var parser = new FileIniDataParser();
            IniData data = parser.ReadData(Utils.GenerateStreamFromString(file));


            foreach (string mat in Enum.GetNames(typeof(Material)))
            {
                try { 
                    float d, f, e;

                    string ds = data[mat]["Density"];
                    string fs = data[mat]["Friction"];
                    string es = data[mat]["Elasticity"];

                    d = float.Parse(ds, CultureInfo.InvariantCulture.NumberFormat);
                    f = float.Parse(fs, CultureInfo.InvariantCulture.NumberFormat);
                    e = float.Parse(es, CultureInfo.InvariantCulture.NumberFormat);

                    Material curMat = (Material)Enum.Parse(typeof(Material), mat, true);
                    matAtt.Add(curMat, new MaterialData(d, f, e));
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("Error reading from {0}. Message = {1}", file, e.Message);
                }
            }
            return matAtt;
        }


        public static Dictionary<Material, MaterialData> Attributes
        {
            get
            {
                if (_materialAttributes != null)
                    return _materialAttributes;
                else
                {
                    _materialAttributes = ReadFromFile(Orakel.Properties.Resources.Materials);
                    return _materialAttributes;
                }
            }
        }

        public MaterialData(float d, float f, float e)
        {
            _density = d;
            _friction = f;
            _elasticity = e;
        }
    }
}
