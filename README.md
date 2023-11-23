# NYTPhotoViewer for Xamarin.iOS

[![NuGet version](https://badge.fury.io/nu/Xamarin.NYTPhotoViewer.svg)](https://badge.fury.io/nu/Xamarin.NYTPhotoViewer)

- Latest release of NYTPhotoViewer
- Support loading remote image with FFImageLoading
- Nuget: https://www.nuget.org/packages/Xamarin.NYTPhotoViewer

```
Install-Package NET-iOS.NYTPhotoViewer
```

## Orignal library
https://github.com/NYTimes/NYTPhotoViewer

## Usage
```csharp
NYTPhotoViewerArrayDataSource dataSource = CreatePhotoDatasource();
NYTPhotosViewController controller = new NYTPhotosViewController(_dataSource, 0, null);
controller.WeakDelegate = this;
PresentViewController(controller, true, null);
```

- Checkout the Demo project to learn more
