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
            context.Title = $"{Path.GetFileName(path)}";
            try
            {
                var mapCtrl = new Map()
                {
                    Name = "mapCtrl",
                    //设置缩放
                    FunctionMode = FunctionMode.Pan,
                    Dock = DockStyle.Fill
                };
                WindowsFormsHost host = new WindowsFormsHost()
                {
                    Child = mapCtrl,
                };

                //添加shp图层
                var shp = Shapefile.OpenFile(path);
                mapCtrl.Layers.Add(shp);
                mapCtrl.ZoomToMaxExtent();
                mapCtrl.Refresh();

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

        public void Cleanup()
        {
            // do nothing
        }
    }
}