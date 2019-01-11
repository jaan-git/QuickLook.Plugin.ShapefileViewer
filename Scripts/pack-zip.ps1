Remove-Item ..\QuickLook.Plugin.ShapefileViewer.qlplugin -ErrorAction SilentlyContinue

$files = Get-ChildItem -Path ..\bin\Release\ -Exclude *.pdb,*.xml
Compress-Archive $files ..\QuickLook.Plugin.ShapefileViewer.zip
Move-Item ..\QuickLook.Plugin.ShapefileViewer.zip ..\QuickLook.Plugin.ShapefileViewer.qlplugin