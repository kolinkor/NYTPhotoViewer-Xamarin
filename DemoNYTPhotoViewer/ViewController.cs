using System;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.NYTPhotoViewer;
using System.Threading.Tasks;

namespace DemoNYTPhotoViewer
{
    public partial class ViewController : UIViewController, INYTPhotosViewControllerDelegate
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        UIButton _buttonGallery;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            _buttonGallery = new UIButton(UIButtonType.System)
            {
                Frame = new CGRect(100, 100, 200, 50),
            };
            _buttonGallery.SetTitle("Start Gallery", UIControlState.Normal);
            View.AddSubview(_buttonGallery);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            _buttonGallery.TouchUpInside += _buttonGallery_TouchUpInside;
        }

        public override void ViewDidDisappear(bool animated)
        {
            _buttonGallery.TouchUpInside -= _buttonGallery_TouchUpInside;
            base.ViewDidDisappear(animated);
        }

        NYTPhotoViewerArrayDataSource _dataSource;
        NYTPhotosViewController _controller;
        void _buttonGallery_TouchUpInside(object sender, EventArgs e)
        {
            _dataSource = CreatePhotoDatasource();
            _controller = new NYTPhotosViewController(_dataSource, 0, null);
            _controller.WeakDelegate = this;
            PresentViewController(_controller, true, null);

            // load
            for (int i = 0; i < _dataSource.NumberOfPhotos.Int16Value; i++)
            {
                if (_dataSource.PhotoAtIndex(i) is CustomPhoto customPhoto)
                {
                    customPhoto.UpdateImage(UIImage.FromBundle(customPhoto.BundleName));
                }
            }
        }

        private NYTPhotoViewerArrayDataSource CreatePhotoDatasource()
        {
            CustomPhoto[] photos = new CustomPhoto[]
            {
                CustomPhoto.FromBundle("gallery_1.jpg"),
                CustomPhoto.FromBundle("gallery_2.jpg"),
                CustomPhoto.FromBundle("gallery_3.jpg"),
                CustomPhoto.FromBundle("gallery_4.jpg"),
            };

            NYTPhotoViewerArrayDataSource res = new NYTPhotoViewerArrayDataSource(photos);
            return res;
        }

        [Export("photosViewController:referenceViewForPhoto:")]
        public UIView ReferenceViewForPhoto(NYTPhotosViewController photosViewController, NYTPhoto photo)
        {
            return _buttonGallery;
        }

        [Export("photosViewController:loadingViewForPhoto:")]
        public UIView LoadingViewForPhoto(NYTPhotosViewController photosViewController, NYTPhoto photo)
        {
            return new UIActivityIndicatorView(UIActivityIndicatorViewStyle.White);
        }

        [Export("photosViewController:captionViewRespectsSafeAreaForPhoto:")]
        public bool CaptionViewRespectsSafeAreaForPhoto(NYTPhotosViewController photosViewController, NYTPhoto photo)
        {
            return true;
        }

        [Export("photosViewController:maximumZoomScaleForPhoto:")]
        public nfloat MaximumZoomScaleForPhoto(NYTPhotosViewController photosViewController, NYTPhoto photo)
        {
            return 3;
        }
    }

    public class CustomPhoto : NYTPhoto
    {
        public static CustomPhoto FromBundle(string bundleName)
        {
            return new CustomPhoto { BundleName = bundleName };
        }

        public static CustomPhoto FromRemote(string remotePath)
        {
            return new CustomPhoto { RemotePath = remotePath };
        }

        public string BundleName { get; set; }

        public string RemotePath { get; set; }

        public CustomPhoto()
        {
            AttributedCaptionTitle = CreateTitelAttr("Sample Photo Title");
            AttributedCaptionSummary = CreateSummaryAttr("Phasellus rutrum pretium nisl, at malesuada sapien porta in. Pellentesque convallis quis sapien non dignissim. In ac dui id nunc vestibulum bibendum. Fusce quis malesuada neque, sit amet faucibus sapien. Vivamus malesuada, turpis at vehicula scelerisque, metus nibh sodales ante, vel sagittis ex justo non turpis. Quisque laoreet, orci non iaculis tristique, dui ante accumsan felis, et mattis dolor augue varius mi. Curabitur faucibus mauris auctor rhoncus aliquet. Aliquam sollicitudin urna tortor, quis malesuada sem hendrerit vel. Phasellus eleifend, lorem ac iaculis malesuada, ex ante molestie ex, et mollis ipsum arcu et velit. Phasellus dictum ipsum eu luctus dictum. Aenean aliquet pretium vestibulum.");
        }

        private NSAttributedString CreateSummaryAttr(string summary)
        {
            NSMutableAttributedString attributedString = new NSMutableAttributedString(summary);
            attributedString.AddAttributes(new UIStringAttributes
            {
                Font = UIFont.ItalicSystemFontOfSize(14f),
                ForegroundColor = UIColor.White.ColorWithAlpha(0.7f)
            }, new NSRange(0, summary.Length));
            return attributedString;
        }

        private NSAttributedString CreateTitelAttr(string title)
        {
            NSMutableAttributedString attributedString = new NSMutableAttributedString(title);
            attributedString.AddAttributes(new UIStringAttributes 
            {
                Font = UIFont.SystemFontOfSize(16f),
                ForegroundColor = UIColor.White
            }, new NSRange(0, title.Length));
            return attributedString;
        }

        private UIImage _image;

        public void UpdateImage(UIImage image)
        {
            _image = image;
        }

        public override NSAttributedString AttributedCaptionCredit { get; }

        public override NSAttributedString AttributedCaptionSummary { get; }

        public override NSAttributedString AttributedCaptionTitle { get; }

        public override UIImage Image => _image;

        public override NSData ImageData => null;

        public override UIImage PlaceholderImage => null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _image?.Dispose();
                _image = null;
            }

            base.Dispose(disposing);
        }
    }
}
