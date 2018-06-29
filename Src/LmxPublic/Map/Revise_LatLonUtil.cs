using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LmxPublic.Map
{
    /// <summary>
    ///Revise_LatLonUtil 的摘要说明
    /// </summary>
    public class Revise_LatLonUtil
    {
        public Revise_LatLonUtil()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public static double pi = 3.14159265358979324;
        public static double a = 6378245.0;
        public static double ee = 0.00669342162296594323;
        public static double x_pi = 3.14159265358979324 * 3000.0 / 180.0;



        /// <summary>
        /// 将百度经纬度转国家加密经纬度
        /// </summary>
        /// <param name="bdLoc"></param>
        /// <returns></returns>
        public static TMapPoint bd_decrypt(TMapPoint bdLoc)
        {
            double x = bdLoc.GetLng - 0.0065;
            double y = bdLoc.GetLat - 0.006;
            double z = Math.Sqrt(x * x + y * y) - 0.00002 * Math.Sin(y * x_pi);
            double theta = Math.Atan2(y, x) - 0.000003 * Math.Cos(x * x_pi);
            return LocationMake(z * Math.Cos(theta), z * Math.Sin(theta));
        }

        public static TMapPoint LocationMake(double lng, double lat)
        {
            return new TMapPoint(lng, lat);
        }


        /// <summary>
        ///  将百度经纬度转国家加密经纬度
        /// </summary>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <returns></returns>
        public static double[] bd_decrypt(double lng, double lat)
        {
            double[] dArray = new double[2];
            double x = lng - 0.0065;
            double y = lat - 0.006;
            double z = Math.Sqrt(x * x + y * y) - 0.00002 * Math.Sin(y * x_pi);
            double theta = Math.Atan2(y, x) - 0.000003 * Math.Cos(x * x_pi);
            dArray[0] = z * Math.Cos(theta);
            dArray[1] = z * Math.Sin(theta);

            return dArray;
        }
        /// <summary>
        /// 将国家加密经纬度转真实经纬度
        /// </summary>
        /// <param name="gcLoc"></param>
        /// <returns></returns>
        public static TMapPoint transformFromGCJToWGS(TMapPoint gcLoc)
        {
            TMapPoint wgLoc = new TMapPoint(gcLoc.GetLng, gcLoc.GetLat);
            TMapPoint currGcLoc = null;
            TMapPoint dLoc = new TMapPoint(0.00, 0.00);
            while (true)
            {
                currGcLoc = transformFromWGSToGCJ(wgLoc);
                dLoc.SetLat(gcLoc.GetLat - currGcLoc.GetLat);
                dLoc.SetLng(gcLoc.GetLng - currGcLoc.GetLng);
                if (Math.Abs(dLoc.GetLat) < 1e-7 && Math.Abs(dLoc.GetLat) < 1e-7)
                {
                    return wgLoc;
                }
                wgLoc.SetLat(wgLoc.GetLat + dLoc.GetLat);
                wgLoc.SetLng(wgLoc.GetLng + dLoc.GetLng);
            }
        }

        /// <summary>
        /// 将国家加密经纬度转百度经纬度
        /// </summary>
        /// <param name="gcLoc"></param>
        /// <returns></returns>
        public static TMapPoint bd_encrypt(TMapPoint gcLoc)
        {
            double x = gcLoc.GetLng;
            double y = gcLoc.GetLat;
            double z = Math.Sqrt(x * x + y * y) + 0.00002 * Math.Sin(y * x_pi);
            double theta = Math.Atan2(y, x) + 0.000003 * Math.Cos(x * x_pi);
            return LocationMake(z * Math.Cos(theta) + 0.0065, z * Math.Sin(theta)
                    + 0.006);
        }


        public static double[] bd_encrypt(double lng, double lat)
        {
            double[] dArray = new double[2];
            double x = lng;
            double y = lat;
            double z = Math.Sqrt(x * x + y * y) + 0.00002 * Math.Sin(y * x_pi);
            double theta = Math.Atan2(y, x) + 0.000003 * Math.Cos(x * x_pi);


            dArray[0] = z * Math.Cos(theta) + 0.0065;
            dArray[1] = z * Math.Sin(theta)
                    + 0.006;
            return dArray;
        }

        public long GetOffset(long i, long j)
        {
            return ((i) + 660 * (j));
        }





        /// <summary>
        /// 判断真实经纬度是否在中国范围内
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        /// <returns></returns>
        public static bool outOfChina(double lat, double lon)
        {
            if (lon < 72.004 || lon > 137.8347)
                return true;
            if (lat < 0.8293 || lat > 55.8271)
                return true;
            return false;
        }

        /// <summary>
        /// 转换纬度
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double transformLat(double x, double y)
        {
            double ret = -100.0 + 2.0 * x + 3.0 * y + 0.2 * y * y + 0.1 * x * y
                    + 0.2 * Math.Sqrt(x > 0 ? x : -x);
            ret += (20.0 * Math.Sin(6.0 * x * pi) + 20.0 * Math.Sin(2.0 * x * pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(y * pi) + 40.0 * Math.Sin(y / 3.0 * pi)) * 2.0 / 3.0;
            ret += (160.0 * Math.Sin(y / 12.0 * pi) + 320 * Math.Sin(y * pi / 30.0)) * 2.0 / 3.0;
            return ret;
        }
        /// <summary>
        /// 转换经度
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static double transformLon(double x, double y)
        {
            double ret = 300.0 + x + 2.0 * y + 0.1 * x * x + 0.1 * x * y + 0.1 * Math.Sqrt(x > 0 ? x : -x);
            ret += (20.0 * Math.Sin(6.0 * x * pi) + 20.0 * Math.Sin(2.0 * x * pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(x * pi) + 40.0 * Math.Sin(x / 3.0 * pi)) * 2.0 / 3.0;
            ret += (150.0 * Math.Sin(x / 12.0 * pi) + 300.0 * Math.Sin(x / 30.0
                    * pi)) * 2.0 / 3.0;
            return ret;
        }
        /// <summary>
        /// 将真实经纬度转国家加密经纬度
        /// </summary>
        /// <param name="wgLoc"></param>
        /// <returns></returns>
        public static TMapPoint transformFromWGSToGCJ(TMapPoint wgLoc)
        {
            TMapPoint mgLoc = null;
            if (outOfChina(wgLoc.GetLat, wgLoc.GetLng))
            {
                mgLoc = wgLoc;
                return mgLoc;
            }
            else
            {
                mgLoc = new TMapPoint(0.00, 0.00);
            }
            double dLat = transformLat(wgLoc.GetLng - 105.0, wgLoc.GetLat - 35.0);
            double dLon = transformLon(wgLoc.GetLng - 105.0, wgLoc.GetLat - 35.0);
            double radLat = wgLoc.GetLat / 180.0 * pi;
            double magic = Math.Sin(radLat);
            magic = 1 - ee * magic * magic;
            double sqrtMagic = Math.Sqrt(magic);
            dLat = (dLat * 180.0) / ((a * (1 - ee)) / (magic * sqrtMagic) * pi);
            dLon = (dLon * 180.0) / (a / sqrtMagic * Math.Cos(radLat) * pi);
            mgLoc.SetLat(wgLoc.GetLat + dLat);
            mgLoc.SetLng(wgLoc.GetLng + dLon);

            return mgLoc;
        }

        /// <summary>
        /// 把真实转为百度经纬度
        /// </summary>
        /// <param name="lng"></param>
        /// <param name="lat"></param>
        /// <returns></returns>
        public static double[] TrueToBaidu(double lng, double lat)
        {

            double[] retu1 = new double[2];

            TMapPoint wgLoc = new TMapPoint(lng, lat);

            TMapPoint wgLocCountry = transformFromWGSToGCJ(wgLoc);

            TMapPoint wgLocBaidu = Revise_LatLonUtil.bd_encrypt(wgLocCountry);

            retu1[0] = wgLocBaidu.GetLng;
            retu1[1] = wgLocBaidu.GetLat;

            return retu1;
        }


    }

}
