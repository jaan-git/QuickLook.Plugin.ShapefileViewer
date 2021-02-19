## 1. clone project

```shell
git clone https://github.com/jaan-git/QuickLook.Plugin.ShapefileViewer.git
```

## 2. update submodules

```shell
cd QuickLook.Plugin.ShapefileViewer
git submodule update --init --recursive
```

## 3. update-version.ps1

```shell
powershell
.\Scripts\update-version.ps1
```

## 4. Visual Studio打开解决方案，下载依赖，修改代码

```shell
Update-Package -reinstall
```

## 5. Build Release

```shell
dotnet build --configuration Release
```

## 6. 打包

```
cd .\Scripts
.\pack-zip.ps1
```

打包文件位置项目根目录下：QuickLook.Plugin.ShapefileViewer.qlplugin