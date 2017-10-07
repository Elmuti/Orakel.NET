using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

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

                Material curMat = (Material)Enum.Parse(typeof(Material), mat, true);
                matAtt.Add(curMat, new MaterialData(d, f, e));
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

        public MaterialData(float d, float f, float e)
        {
            Density = d;
            Friction = f;
            Elasticity = e;
        }
    }
}
