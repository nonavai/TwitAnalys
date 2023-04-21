using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;


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
