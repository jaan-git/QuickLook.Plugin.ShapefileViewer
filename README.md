![quicklook-esri-logo.png](https://raw.github.com/birderyu/attachments/master/QuickLook.Plugin.ShapefileViewer/quicklook-esri-logo.png)

# QuickLook.Plugin.ShapefileViewer

This plugin allows [QuickLook](https://github.com/QL-Win/QuickLook) to preview ESRI Shapefile, without the requirement of installing other softwares.

## ESRI Shapefile

The [shapefile](https://www.esri.com/library/whitepapers/pdfs/shapefile.pdf) format is a popular geospatial vector data format for geographic information system (GIS) software. It is developed and regulated by [ESRI](https://www.esri.com) as a (mostly) open specification for data interoperability among ESRI and other GIS software products. The shapefile format can spatially describe vector features: points, lines, and polygons, representing, for example, water wells, rivers, and lakes. Each item usually has attributes that describe it, such as name or temperature.
Read [more](https://en.wikipedia.org/wiki/Shapefile).

## SharpMap
[SharpMap](https://github.com/SharpMap/SharpMap) is an easy-to-use mapping library for use in web and desktop applications. This plugin use SharpMap dynamic linking to parse and display shapefile.

## Try out

1. Go to [Release page](https://github.com/birderyu/QuickLook.Plugin.ShapefileViewer/releases) and download the latest version.

2. Make sure that you have QuickLook running in the background. Go to your Download folder, and press <key>Spacebar</key> on the downloaded `.qlplugin` file.

3. Click the “Install” button in the popup window.

4. Restart QuickLook.

5. Select the shapefile(extension to `.shp`) and press <key>Spacebar</key>, like this:
![shapefile-demo.png](https://raw.github.com/birderyu/attachments/master/QuickLook.Plugin.ShapefileViewer/shapefile-demo.png)
   

## Development

 1. Clone this project. Do not forget to update submodules.
 2. Build project with `Release` profile.
 3. Run `Scripts\pack-zip.ps1`.
 4. You should find a file named `QuickLook.Plugin.ShapefileViewer.qlplugin` in the project directory.

## License

MIT License.
