using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Orakel
{
    public struct MaterialData
    {
        private static Dictionary<Material, MaterialData> _materialAttributes;


        public float Density;
        public float Friction;
        public float Elasticity;


        public static Dictionary<Material, MaterialData> ReadFromFile(string path)
        {
            Dictionary<Material, MaterialData> matAtt = new Dictionary<Material, MaterialData>();
            var matf = new IniFile();

            foreach (string mat in Enum.GetNames(typeof(Material)))
            {
                float d, f, e;

                string ds = matf.Read("Density", mat);
                string fs = matf.Read("Friction", mat);
                string es = matf.Read("Elasticity", mat);

                d = float.Parse(ds, CultureInfo.InvariantCulture.NumberFormat);
                f = float.Parse(fs, CultureInfo.InvariantCulture.NumberFormat);
                e = float.Parse(es, CultureInfo.InvariantCulture.NumberFormat);

                matAtt.Add(Material.Parse(mat), new MaterialData(d, f, e));
            }
            return matAtt;
        }


        public static Dictionary<Material, MaterialData> MaterialAttributes
        {
            get
            {
                if (_materialAttributes != null)
                    return _materialAttributes;
                else
                {
                    _materialAttributes = ReadFromFile("");
                    return _materialAttributes;
                }
            }
        }

/*
        public static Dictionary<Material, MaterialData> MaterialAttributes = new Dictionary<Material, MaterialData>()
        {
            // MATERIAL,                 Density, Friction, Elasticity
            { Material.Air, new MaterialData(0.0f, 0.01f, 0.01f) },
            { Material.Acid, new MaterialData(1.0f, 0.05f, 0.01f) },
            { Material.Cardboard, new MaterialData(0.25f, 0.28f, 0.35f) },
            { Material.Concrete, new MaterialData(2.403f, 0.7f, 0.2f) },
            { Material.Fabric, new MaterialData(0.7f, 0.35f, 0.05f) },
            { Material.Flesh, new MaterialData(0.975f, 0.35f, 0.05f) },
            { Material.Glass, new MaterialData(1.619f, 0.28f, 0.15f) },
            { Material.GlassPane, new MaterialData(1.619f, 0.25f, 0.25f) },
            { Material.Grass, new MaterialData(0.9f, 0.4f, 0.1f) },
            { Material.Ground, new MaterialData(0.9f, 0.4f, 0.1f) },
            { Material.Ice, new MaterialData(0.819f, 0.02f, 0.15f) },
            { Material.Metal, new MaterialData(7.85f, 0.4f, 0.25f) },
            { Material.MetalGrate, new MaterialData(5.85f, 0.5f, 0.25f) },
            { Material.Mud, new MaterialData(0.9f, 0.4f, 0.1f) },
            { Material.Plastic, new MaterialData(0.7f, 0.3f, 0.5f) },
            { Material.Rock, new MaterialData(2.691f, 0.4f, 0.2f) },
            { Material.Sand, new MaterialData(1.602f, 0.5f, 0.05f) },
            { Material.Snow, new MaterialData(0.819f, 0.25f, 0.15f) },
            { Material.Water, new MaterialData(1.0f, 0.05f, 0.01f) },
            { Material.Wood, new MaterialData(0.35f, 0.48f, 0.2f) },
            { Material.WoodPlanks, new MaterialData(0.35f, 0.48f, 0.2f) }
        };
*/

        public MaterialData(float d, float f, float e)
        {
            Density = d;
            Friction = f;
            Elasticity = e;
        }
    }

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
}
