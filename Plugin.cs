using DotSpatial.Controls;
using DotSpatial.Data;
using QuickLook.Common.Plugin;
using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace QuickLook.Plugin.HelloWorld
{
    public class Plugin : IViewer
    {
        public int Priority => 0;

        private Map mapCtrl = null;
        private ContextObject _context = null;
        private Shapefile shp = null;

        public void Init()
        {
            // do nothing
        }

        public bool CanHandle(string path)
        {
            return !Directory.Exists(path) && path.ToLower().EndsWith(".shp");
        }

        public void Prepare(string path, ContextObject context)
        {
            context.SetPreferredSizeFit(new Size { Width = 1920, Height = 1440 }, 0.9);
        }

        public void View(string path, ContextObject context)
        {
            this._context = context;
            context.Title = $"{Path.GetFileName(path)}";
            try
            {
                mapCtrl = new Map()
                {
                    Name = "mapCtrl",
                    //设置缩放
                    FunctionMode = FunctionMode.Info,
                    Dock = DockStyle.Fill
                };
                WindowsFormsHost host = new WindowsFormsHost()
                {
                    Child = mapCtrl,
                };

                //添加shp图层
                shp = Shapefile.OpenFile(path);
                mapCtrl.Layers.Add(shp);
                mapCtrl.ZoomToMaxExtent();
                mapCtrl.Refresh();

                mapCtrl.MouseMove += MapCtrl_MouseMove;

                context.ViewerContent = host;
            }
            catch (Exception ex)
            {
                context.ViewerContent = new System.Windows.Controls.Label
                {
                    Content = $"Can not open shapefile because of: {ex.Message}"
                };
            }
            finally
            {
                context.IsBusy = false;
            }
        }

        private void MapCtrl_MouseMove(object sender, MouseEventArgs e)
        {
            //将地图和坐标函数绑定
            GeoMouseArgs args = new GeoMouseArgs(e, mapCtrl);

            //求X、Y轴坐标
            string xpanel = String.Format("X: {0:0.000000}", args.GeographicLocation.X);
            string ypanel = String.Format("Y: {0:0.000000}", args.GeographicLocation.Y);
            this._context.Title = xpanel + " " + ypanel + "    " + shp.Projection.Name;
        }

        public void Cleanup()
        {
            // do nothing
        }
    }
}