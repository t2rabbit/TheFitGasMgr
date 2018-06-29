using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LmxPublic.Map
{
    public class TMapPoint
    {
       public TMapPoint(double getLng, double getLat)
       {
           this._getLng = getLng;
           this._getLat = getLat;
       }
        

        private double _getLng = InitConstants.InitFloat;
        private double _getLat = InitConstants.InitFloat;
        private double _setLng = InitConstants.InitFloat; 
        private double _setLat = InitConstants.InitFloat;


        public double GetLng
        {
            get { return _getLng; }
            set { _getLng = value; }
        }
        
        public double GetLat
        {
            get { return _getLat; }
            set { _getLat = value; }
        }

        public void SetLat(double getLat)
        {
             _getLat=getLat;
        }

        public void SetLng(double getLng)
        {
             _getLng=getLng;
        }
    }
}

