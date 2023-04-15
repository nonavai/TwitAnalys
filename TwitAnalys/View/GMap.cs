using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitAnalys.View
{
    public partial class GMap : Form
    {
        public GMap()
        {
            InitializeComponent();
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            double lat = Convert.ToDouble(40);
            double lon = Convert.ToDouble(-100.0);

            gMapControl1.Position = new PointLatLng(lat, lon);

            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 50;
            gMapControl1.Zoom = 4;

            gMapControl1.MapScaleInfoEnabled = true;
            GMapDraw.DrawPolygons();
            GMapOverlay polyOverlay = GMapDraw.Overlay;
            gMapControl1.Overlays.Add(polyOverlay);
        }


    }
}
