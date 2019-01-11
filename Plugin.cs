using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using QuickLook.Common.Plugin;
using SharpMap.Data.Providers;
using SharpMap.Forms;
using SharpMap.Layers;
using static SharpMap.Forms.MapBox;

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
                MapBox mapBox = new MapBox()
                {
                    Dock = DockStyle.Fill,
                    ActiveTool = Tools.Pan,
                    PreviewMode = PreviewModes.Fast
                };
                WindowsFormsHost host = new WindowsFormsHost()
                {
                    Child = mapBox,
                };
                VectorLayer layer = new VectorLayer(Path.GetFileName(path))
                {
                    DataSource = new ShapeFile(path, false, true)
                };
                mapBox.Map.Layers.Add(layer);
                mapBox.Map.ZoomToExtents();
                mapBox.Refresh();

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