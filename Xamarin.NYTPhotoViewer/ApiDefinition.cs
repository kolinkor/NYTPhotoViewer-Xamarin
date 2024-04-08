using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Xamarin.NYTPhotoViewer
{
    // @interface NYTPhotoViewer (NSBundle)
    [Category]
    [BaseType(typeof(NSBundle))]
    interface NSBundle_NYTPhotoViewer
    {
        // +(instancetype)nyt_photoViewerResourceBundle;
        [Static]
        [Export("nyt_photoViewerResourceBundle")]
        NSBundle Nyt_photoViewerResourceBundle();
    }

    // @protocol NYTPhoto <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface NYTPhoto
    {
        // @required @property (readonly, nonatomic) UIImage * _Nullable image;
        [Abstract]
        [NullAllowed, Export("image")]
        UIImage Image { get; }

        // @required @property (readonly, nonatomic) NSData * _Nullable imageData;
        [Abstract]
        [NullAllowed, Export("imageData")]
        NSData ImageData { get; }

        // @required @property (readonly, nonatomic) UIImage * _Nullable placeholderImage;
        [Abstract]
        [NullAllowed, Export("placeholderImage")]
        UIImage PlaceholderImage { get; }

        // @required @property (readonly, nonatomic) NSAttributedString * _Nullable attributedCaptionTitle;
        [Abstract]
        [NullAllowed, Export("attributedCaptionTitle")]
        NSAttributedString AttributedCaptionTitle { get; }

        // @required @property (readonly, nonatomic) NSAttributedString * _Nullable attributedCaptionSummary;
        [Abstract]
        [NullAllowed, Export("attributedCaptionSummary")]
        NSAttributedString AttributedCaptionSummary { get; }

        // @required @property (readonly, nonatomic) NSAttributedString * _Nullable attributedCaptionCredit;
        [Abstract]
        [NullAllowed, Export("attributedCaptionCredit")]
        NSAttributedString AttributedCaptionCredit { get; }
    }

    interface INYTPhotoCaptionViewLayoutWidthHinting{}

    // @protocol NYTPhotoCaptionViewLayoutWidthHinting <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface NYTPhotoCaptionViewLayoutWidthHinting
    {
        // @required @property (nonatomic) CGFloat preferredMaxLayoutWidth;
        [Abstract]
        [Export("preferredMaxLayoutWidth")]
        nfloat PreferredMaxLayoutWidth { get; set; }
    }

    // @interface NYTPhotoCaptionViewLayoutWidthHinting (UILabel) <NYTPhotoCaptionViewLayoutWidthHinting>
    [Category]
    [BaseType(typeof(UILabel))]
    interface UILabel_NYTPhotoCaptionViewLayoutWidthHinting : INYTPhotoCaptionViewLayoutWidthHinting
    {
    }

    // @interface NYTPhotoCaptionView : UIView <NYTPhotoCaptionViewLayoutWidthHinting>
    [BaseType(typeof(UIView))]
    interface NYTPhotoCaptionView : INYTPhotoCaptionViewLayoutWidthHinting
    {
        // -(instancetype _Nonnull)initWithAttributedTitle:(NSAttributedString * _Nullable)attributedTitle attributedSummary:(NSAttributedString * _Nullable)attributedSummary attributedCredit:(NSAttributedString * _Nullable)attributedCredit __attribute__((objc_designated_initializer));
        [Export("initWithAttributedTitle:attributedSummary:attributedCredit:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] NSAttributedString attributedTitle, [NullAllowed] NSAttributedString attributedSummary, [NullAllowed] NSAttributedString attributedCredit);
    }

    interface INYTPhotoContainer{}

    // @protocol NYTPhotoContainer <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface NYTPhotoContainer
    {
        // @required @property (readonly, nonatomic) id<NYTPhoto> photo;
        [Abstract]
        [Export("photo")]
        NYTPhoto Photo { get; }
    }

    // // @interface NYTPhotoDismissalInteractionController : NSObject <UIViewControllerInteractiveTransitioning>
    // [BaseType(typeof(NSObject))]
    // interface NYTPhotoDismissalInteractionController : IUIViewControllerInteractiveTransitioning
    // {
    //     // @property (nonatomic) id<UIViewControllerAnimatedTransitioning> _Nonnull animator;
    //     [Export("animator", ArgumentSemantic.Assign)]
    //     UIViewControllerAnimatedTransitioning Animator { get; set; }
    //
    //     // @property (nonatomic) UIView * _Nullable viewToHideWhenBeginningTransition;
    //     [NullAllowed, Export("viewToHideWhenBeginningTransition", ArgumentSemantic.Assign)]
    //     UIView ViewToHideWhenBeginningTransition { get; set; }
    //
    //     // @property (nonatomic) BOOL shouldAnimateUsingAnimator;
    //     [Export("shouldAnimateUsingAnimator")]
    //     bool ShouldAnimateUsingAnimator { get; set; }
    //
    //     // -(void)didPanWithPanGestureRecognizer:(UIPanGestureRecognizer * _Nonnull)panGestureRecognizer viewToPan:(UIView * _Nonnull)viewToPan anchorPoint:(CGPoint)anchorPoint;
    //     [Export("didPanWithPanGestureRecognizer:viewToPan:anchorPoint:")]
    //     void DidPanWithPanGestureRecognizer(UIPanGestureRecognizer panGestureRecognizer, UIView viewToPan, CGPoint anchorPoint);
    // }
    
    // // @interface NYTPhotoTransitionAnimator : NSObject <UIViewControllerAnimatedTransitioning>
    // [BaseType(typeof(NSObject))]
    // interface NYTPhotoTransitionAnimator : IUIViewControllerAnimatedTransitioning
    // {
    //     // @property (nonatomic) UIView * _Nonnull startingView;
    //     [Export("startingView", ArgumentSemantic.Assign)]
    //     UIView StartingView { get; set; }
    //
    //     // @property (nonatomic) UIView * _Nonnull endingView;
    //     [Export("endingView", ArgumentSemantic.Assign)]
    //     UIView EndingView { get; set; }
    //
    //     // @property (nonatomic) UIView * _Nullable startingViewForAnimation;
    //     [NullAllowed, Export("startingViewForAnimation", ArgumentSemantic.Assign)]
    //     UIView StartingViewForAnimation { get; set; }
    //
    //     // @property (nonatomic) UIView * _Nullable endingViewForAnimation;
    //     [NullAllowed, Export("endingViewForAnimation", ArgumentSemantic.Assign)]
    //     UIView EndingViewForAnimation { get; set; }
    //
    //     // @property (getter = isDismissing, nonatomic) BOOL dismissing;
    //     [Export("dismissing")]
    //     bool Dismissing { [Bind("isDismissing")] get; set; }
    //
    //     // @property (nonatomic) CGFloat animationDurationWithZooming;
    //     [Export("animationDurationWithZooming")]
    //     nfloat AnimationDurationWithZooming { get; set; }
    //
    //     // @property (nonatomic) CGFloat animationDurationWithoutZooming;
    //     [Export("animationDurationWithoutZooming")]
    //     nfloat AnimationDurationWithoutZooming { get; set; }
    //
    //     // @property (nonatomic) CGFloat animationDurationFadeRatio;
    //     [Export("animationDurationFadeRatio")]
    //     nfloat AnimationDurationFadeRatio { get; set; }
    //
    //     // @property (nonatomic) CGFloat animationDurationEndingViewFadeInRatio;
    //     [Export("animationDurationEndingViewFadeInRatio")]
    //     nfloat AnimationDurationEndingViewFadeInRatio { get; set; }
    //
    //     // @property (nonatomic) CGFloat animationDurationStartingViewFadeOutRatio;
    //     [Export("animationDurationStartingViewFadeOutRatio")]
    //     nfloat AnimationDurationStartingViewFadeOutRatio { get; set; }
    //
    //     // @property (nonatomic) CGFloat zoomingAnimationSpringDamping;
    //     [Export("zoomingAnimationSpringDamping")]
    //     nfloat ZoomingAnimationSpringDamping { get; set; }
    //
    //     // +(UIView * _Nullable)newAnimationViewFromView:(UIView * _Nullable)view;
    //     [Static]
    //     [Export("newAnimationViewFromView:")]
    //     [return: NullAllowed]
    //     UIView NewAnimationViewFromView([NullAllowed] UIView view);
    // }

    // // @interface NYTPhotoTransitionController : NSObject <UIViewControllerTransitioningDelegate>
    // [BaseType(typeof(NSObject))]
    // interface NYTPhotoTransitionController : IUIViewControllerTransitioningDelegate
    // {
    //     // @property (nonatomic) UIView * _Nonnull startingView;
    //     [Export("startingView", ArgumentSemantic.Assign)]
    //     UIView StartingView { get; set; }
    //
    //     // @property (nonatomic) UIView * _Nonnull endingView;
    //     [Export("endingView", ArgumentSemantic.Assign)]
    //     UIView EndingView { get; set; }
    //
    //     // @property (nonatomic) BOOL forcesNonInteractiveDismissal;
    //     [Export("forcesNonInteractiveDismissal")]
    //     bool ForcesNonInteractiveDismissal { get; set; }
    //
    //     // -(void)didPanWithPanGestureRecognizer:(UIPanGestureRecognizer * _Nonnull)panGestureRecognizer viewToPan:(UIView * _Nonnull)viewToPan anchorPoint:(CGPoint)anchorPoint;
    //     [Export("didPanWithPanGestureRecognizer:viewToPan:anchorPoint:")]
    //     void DidPanWithPanGestureRecognizer(UIPanGestureRecognizer panGestureRecognizer, UIView viewToPan, CGPoint anchorPoint);
    // }

    [Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const _Nonnull NYTPhotoViewControllerPhotoImageUpdatedNotification;
        [Field("NYTPhotoViewControllerPhotoImageUpdatedNotification", "__Internal")]
        NSString NYTPhotoViewControllerPhotoImageUpdatedNotification { get; }
    }

    // @interface NYTPhotoViewController : UIViewController <NYTPhotoContainer>
    [BaseType(typeof(UIViewController))]
    interface NYTPhotoViewController : INYTPhotoContainer
    {
        // @property (readonly, nonatomic) NYTScalingImageView * _Nonnull scalingImageView;
        [Export("scalingImageView")]
        NYTScalingImageView ScalingImageView { get; }

        // @property (readonly, nonatomic) UIView * _Nullable loadingView;
        [NullAllowed, Export("loadingView")]
        UIView LoadingView { get; }

        // @property (readonly, nonatomic) UITapGestureRecognizer * _Nonnull doubleTapGestureRecognizer;
        [Export("doubleTapGestureRecognizer")]
        UITapGestureRecognizer DoubleTapGestureRecognizer { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        NYTPhotoViewControllerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<NYTPhotoViewControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(instancetype _Nonnull)initWithPhoto:(id<NYTPhoto> _Nullable)photo loadingView:(UIView * _Nullable)loadingView notificationCenter:(NSNotificationCenter * _Nullable)notificationCenter __attribute__((objc_designated_initializer));
        [Export("initWithPhoto:loadingView:notificationCenter:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] NYTPhoto photo, [NullAllowed] UIView loadingView, [NullAllowed] NSNotificationCenter notificationCenter);
    }

    // @protocol NYTPhotoViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface NYTPhotoViewControllerDelegate
    {
        // @optional -(void)photoViewController:(NYTPhotoViewController * _Nonnull)photoViewController didLongPressWithGestureRecognizer:(UILongPressGestureRecognizer * _Nonnull)longPressGestureRecognizer;
        [Export("photoViewController:didLongPressWithGestureRecognizer:")]
        void DidLongPressWithGestureRecognizer(NYTPhotoViewController photoViewController, UILongPressGestureRecognizer longPressGestureRecognizer);
    }

    interface INYTPhotoViewerDataSource { }

    // @protocol NYTPhotoViewerDataSource
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface NYTPhotoViewerDataSource
    {
        // @required @property (readonly, nonatomic) NSNumber * _Nullable numberOfPhotos;
        [Abstract]
        [NullAllowed, Export("numberOfPhotos")]
        NSNumber NumberOfPhotos { get; }

        // @required -(NSInteger)indexOfPhoto:(id<NYTPhoto> _Nonnull)photo;
        [Abstract]
        [Export("indexOfPhoto:")]
        nint IndexOfPhoto(NYTPhoto photo);

        // @required -(id<NYTPhoto> _Nullable)photoAtIndex:(NSInteger)photoIndex;
        [Abstract]
        [Export("photoAtIndex:")]
        [return: NullAllowed]
        NYTPhoto PhotoAtIndex(nint photoIndex);
    }

    // @interface NYTPhotoViewerArrayDataSource : NSObject <NYTPhotoViewerDataSource, NSFastEnumeration>
    [BaseType(typeof(NSObject))]
    interface NYTPhotoViewerArrayDataSource : NYTPhotoViewerDataSource//, NSFastEnumeration
    {
        // @property (readonly, nonatomic) NSArray<id<NYTPhoto>> * _Nonnull photos;
        [Export("photos")]
        NYTPhoto[] Photos { get; }

        // -(instancetype _Nonnull)initWithPhotos:(NSArray<id<NYTPhoto>> * _Nullable)photos __attribute__((objc_designated_initializer));
        [Export("initWithPhotos:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] NYTPhoto[] photos);

        // +(instancetype _Nonnull)dataSourceWithPhotos:(NSArray<id<NYTPhoto>> * _Nullable)photos;
        [Static]
        [Export("dataSourceWithPhotos:")]
        NYTPhotoViewerArrayDataSource DataSourceWithPhotos([NullAllowed] NYTPhoto[] photos);

        // -(id<NYTPhoto> _Nonnull)objectAtIndexedSubscript:(NSUInteger)idx;
        [Export("objectAtIndexedSubscript:")]
        NYTPhoto ObjectAtIndexedSubscript(nuint idx);
    }

    // @interface NYTPhotoViewerSinglePhotoDataSource : NSObject <NYTPhotoViewerDataSource>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface NYTPhotoViewerSinglePhotoDataSource : NYTPhotoViewerDataSource
    {
        // @property (readonly, nonatomic) id<NYTPhoto> _Nonnull photo;
        [Export("photo")]
        NYTPhoto Photo { get; }

        // -(instancetype _Nonnull)initWithPhoto:(id<NYTPhoto> _Nonnull)photo __attribute__((objc_designated_initializer));
        [Export("initWithPhoto:")]
        [DesignatedInitializer]
        IntPtr Constructor(NYTPhoto photo);

        // +(instancetype _Nonnull)dataSourceWithPhoto:(id<NYTPhoto> _Nonnull)photo;
        [Static]
        [Export("dataSourceWithPhoto:")]
        NYTPhotoViewerSinglePhotoDataSource DataSourceWithPhoto(NYTPhoto photo);
    }

    // @interface NYTPhotosOverlayView : UIView
    [BaseType(typeof(UIView))]
    interface NYTPhotosOverlayView
    {
        // @property (readonly, nonatomic) UINavigationBar * _Nonnull navigationBar;
        [Export("navigationBar")]
        UINavigationBar NavigationBar { get; }

        // @property (copy, nonatomic) NSString * _Nullable title;
        [NullAllowed, Export("title")]
        string Title { get; set; }

        // @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nullable titleTextAttributes;
        [NullAllowed, Export("titleTextAttributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> TitleTextAttributes { get; set; }

        // @property (nonatomic) UIBarButtonItem * _Nullable leftBarButtonItem;
        [NullAllowed, Export("leftBarButtonItem", ArgumentSemantic.Assign)]
        UIBarButtonItem LeftBarButtonItem { get; set; }

        // @property (copy, nonatomic) NSArray<UIBarButtonItem *> * _Nullable leftBarButtonItems;
        [NullAllowed, Export("leftBarButtonItems", ArgumentSemantic.Copy)]
        UIBarButtonItem[] LeftBarButtonItems { get; set; }

        // @property (nonatomic) UIBarButtonItem * _Nullable rightBarButtonItem;
        [NullAllowed, Export("rightBarButtonItem", ArgumentSemantic.Assign)]
        UIBarButtonItem RightBarButtonItem { get; set; }

        // @property (copy, nonatomic) NSArray<UIBarButtonItem *> * _Nullable rightBarButtonItems;
        [NullAllowed, Export("rightBarButtonItems", ArgumentSemantic.Copy)]
        UIBarButtonItem[] RightBarButtonItems { get; set; }

        // @property (nonatomic) UIView * _Nullable captionView;
        [NullAllowed, Export("captionView", ArgumentSemantic.Assign)]
        UIView CaptionView { get; set; }

        // @property (nonatomic) BOOL captionViewRespectsSafeArea;
        [Export("captionViewRespectsSafeArea")]
        bool CaptionViewRespectsSafeArea { get; set; }
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const _Nonnull NYTPhotosViewControllerDidNavigateToPhotoNotification;
        [Field("NYTPhotosViewControllerDidNavigateToPhotoNotification", "__Internal")]
        NSString NYTPhotosViewControllerDidNavigateToPhotoNotification { get; }

        // extern NSString *const _Nonnull NYTPhotosViewControllerWillDismissNotification;
        [Field("NYTPhotosViewControllerWillDismissNotification", "__Internal")]
        NSString NYTPhotosViewControllerWillDismissNotification { get; }

        // extern NSString *const _Nonnull NYTPhotosViewControllerDidDismissNotification;
        [Field("NYTPhotosViewControllerDidDismissNotification", "__Internal")]
        NSString NYTPhotosViewControllerDidDismissNotification { get; }
    }

    // @interface NYTPhotosViewController : UIViewController
    [BaseType(typeof(UIViewController))]
    interface NYTPhotosViewController
    {
        // @property (readonly, nonatomic) UIPanGestureRecognizer * _Nonnull panGestureRecognizer;
        [Export("panGestureRecognizer")]
        UIPanGestureRecognizer PanGestureRecognizer { get; }

        // @property (readonly, nonatomic) UITapGestureRecognizer * _Nonnull singleTapGestureRecognizer;
        [Export("singleTapGestureRecognizer")]
        UITapGestureRecognizer SingleTapGestureRecognizer { get; }

        // @property (readonly, nonatomic) UIPageViewController * _Nullable pageViewController;
        [NullAllowed, Export("pageViewController")]
        UIPageViewController PageViewController { get; }

        // @property (nonatomic, weak) id<NYTPhotoViewerDataSource> _Nullable dataSource;
        [NullAllowed, Export("dataSource", ArgumentSemantic.Weak)]
        INYTPhotoViewerDataSource DataSource { get; set; }

        // @property (readonly, nonatomic) id<NYTPhoto> _Nullable currentlyDisplayedPhoto;
        [NullAllowed, Export("currentlyDisplayedPhoto")]
        NYTPhoto CurrentlyDisplayedPhoto { get; }

        // @property (readonly, nonatomic) NYTPhotosOverlayView * _Nullable overlayView;
        [NullAllowed, Export("overlayView")]
        NYTPhotosOverlayView OverlayView { get; }

        // @property (nonatomic) UIBarButtonItem * _Nullable leftBarButtonItem;
        [NullAllowed, Export("leftBarButtonItem", ArgumentSemantic.Assign)]
        UIBarButtonItem LeftBarButtonItem { get; set; }

        // @property (copy, nonatomic) NSArray<UIBarButtonItem *> * _Nullable leftBarButtonItems;
        [NullAllowed, Export("leftBarButtonItems", ArgumentSemantic.Copy)]
        UIBarButtonItem[] LeftBarButtonItems { get; set; }

        // @property (nonatomic) UIBarButtonItem * _Nullable rightBarButtonItem;
        [NullAllowed, Export("rightBarButtonItem", ArgumentSemantic.Assign)]
        UIBarButtonItem RightBarButtonItem { get; set; }

        // @property (copy, nonatomic) NSArray<UIBarButtonItem *> * _Nullable rightBarButtonItems;
        [NullAllowed, Export("rightBarButtonItems", ArgumentSemantic.Copy)]
        UIBarButtonItem[] RightBarButtonItems { get; set; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        NYTPhotosViewControllerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<NYTPhotosViewControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(instancetype _Nonnull)initWithDataSource:(id<NYTPhotoViewerDataSource> _Nonnull)dataSource;
        [Export("initWithDataSource:")]
        IntPtr Constructor(INYTPhotoViewerDataSource dataSource);

        // -(instancetype _Nonnull)initWithDataSource:(id<NYTPhotoViewerDataSource> _Nonnull)dataSource initialPhotoIndex:(NSInteger)initialPhotoIndex delegate:(id<NYTPhotosViewControllerDelegate> _Nullable)delegate;
        [Export("initWithDataSource:initialPhotoIndex:delegate:")]
        IntPtr Constructor(INYTPhotoViewerDataSource dataSource, nint initialPhotoIndex, [NullAllowed] INYTPhotosViewControllerDelegate @delegate);

        // -(instancetype _Nonnull)initWithDataSource:(id<NYTPhotoViewerDataSource> _Nonnull)dataSource initialPhoto:(id<NYTPhoto> _Nullable)initialPhoto delegate:(id<NYTPhotosViewControllerDelegate> _Nullable)delegate __attribute__((objc_designated_initializer));
        [Export("initWithDataSource:initialPhoto:delegate:")]
        [DesignatedInitializer]
        IntPtr Constructor(INYTPhotoViewerDataSource dataSource, [NullAllowed] NYTPhoto initialPhoto, [NullAllowed] INYTPhotosViewControllerDelegate @delegate);

        // -(void)displayPhoto:(id<NYTPhoto> _Nullable)photo animated:(BOOL)animated;
        [Export("displayPhoto:animated:")]
        void DisplayPhoto([NullAllowed] NYTPhoto photo, bool animated);

        // -(void)updatePhotoAtIndex:(NSInteger)photoIndex;
        [Export("updatePhotoAtIndex:")]
        void UpdatePhotoAtIndex(nint photoIndex);

        // -(void)updatePhoto:(id<NYTPhoto> _Nonnull)photo;
        [Export("updatePhoto:")]
        void UpdatePhoto(NYTPhoto photo);

        // -(void)reloadPhotosAnimated:(BOOL)animated;
        [Export("reloadPhotosAnimated:")]
        void ReloadPhotosAnimated(bool animated);
    }

    interface INYTPhotosViewControllerDelegate{}

    // @protocol NYTPhotosViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface NYTPhotosViewControllerDelegate
    {
        // @optional -(void)photosViewController:(NYTPhotosViewController * _Nonnull)photosViewController didNavigateToPhoto:(id<NYTPhoto> _Nonnull)photo atIndex:(NSUInteger)photoIndex;
        [Export("photosViewController:didNavigateToPhoto:atIndex:")]
        void PhotosViewController(NYTPhotosViewController photosViewController, NYTPhoto photo, nuint photoIndex);

        // @optional -(void)photosViewControllerWillDismiss:(NYTPhotosViewController * _Nonnull)photosViewController;
        [Export("photosViewControllerWillDismiss:")]
        void PhotosViewControllerWillDismiss(NYTPhotosViewController photosViewController);

        // @optional -(void)photosViewControllerDidDismiss:(NYTPhotosViewController * _Nonnull)photosViewController;
        [Export("photosViewControllerDidDismiss:")]
        void PhotosViewControllerDidDismiss(NYTPhotosViewController photosViewController);

        // @optional -(UIView * _Nullable)photosViewController:(NYTPhotosViewController * _Nonnull)photosViewController captionViewForPhoto:(id<NYTPhoto> _Nonnull)photo;
        [Export("photosViewController:captionViewForPhoto:")]
        [return: NullAllowed]
        UIView CaptionViewForPhoto(NYTPhotosViewController photosViewController, NYTPhoto photo);

        // @optional -(BOOL)photosViewController:(NYTPhotosViewController * _Nonnull)photosViewController captionViewRespectsSafeAreaForPhoto:(id<NYTPhoto> _Nonnull)photo;
        [Export("photosViewController:captionViewRespectsSafeAreaForPhoto:")]
        bool CaptionViewRespectsSafeAreaForPhoto(NYTPhotosViewController photosViewController, NYTPhoto photo);

        // @optional -(NSString * _Nullable)photosViewController:(NYTPhotosViewController * _Nonnull)photosViewController titleForPhoto:(id<NYTPhoto> _Nonnull)photo atIndex:(NSInteger)photoIndex totalPhotoCount:(NSNumber * _Nullable)totalPhotoCount;
        [Export("photosViewController:titleForPhoto:atIndex:totalPhotoCount:")]
        [return: NullAllowed]
        string TitleForPhoto(NYTPhotosViewController photosViewController, NYTPhoto photo, nint photoIndex, [NullAllowed] NSNumber totalPhotoCount);

        // @optional -(UIView * _Nullable)photosViewController:(NYTPhotosViewController * _Nonnull)photosViewController loadingViewForPhoto:(id<NYTPhoto> _Nonnull)photo;
        [Export("photosViewController:loadingViewForPhoto:")]
        [return: NullAllowed]
        UIView LoadingViewForPhoto(NYTPhotosViewController photosViewController, NYTPhoto photo);

        // @optional -(UIView * _Nullable)photosViewController:(NYTPhotosViewController * _Nonnull)photosViewController referenceViewForPhoto:(id<NYTPhoto> _Nonnull)photo;
        [Export("photosViewController:referenceViewForPhoto:")]
        [return: NullAllowed]
        UIView ReferenceViewForPhoto(NYTPhotosViewController photosViewController, NYTPhoto photo);

        // @optional -(CGFloat)photosViewController:(NYTPhotosViewController * _Nonnull)photosViewController maximumZoomScaleForPhoto:(id<NYTPhoto> _Nonnull)photo;
        [Export("photosViewController:maximumZoomScaleForPhoto:")]
        nfloat MaximumZoomScaleForPhoto(NYTPhotosViewController photosViewController, NYTPhoto photo);

        // @optional -(BOOL)photosViewController:(NYTPhotosViewController * _Nonnull)photosViewController handleLongPressForPhoto:(id<NYTPhoto> _Nonnull)photo withGestureRecognizer:(UILongPressGestureRecognizer * _Nonnull)longPressGestureRecognizer;
        [Export("photosViewController:handleLongPressForPhoto:withGestureRecognizer:")]
        bool HandleLongPressForPhoto(NYTPhotosViewController photosViewController, NYTPhoto photo, UILongPressGestureRecognizer longPressGestureRecognizer);

        // @optional -(BOOL)photosViewController:(NYTPhotosViewController * _Nonnull)photosViewController handleActionButtonTappedForPhoto:(id<NYTPhoto> _Nonnull)photo;
        [Export("photosViewController:handleActionButtonTappedForPhoto:")]
        bool HandleActionButtonTappedForPhoto(NYTPhotosViewController photosViewController, NYTPhoto photo);

        // @optional -(void)photosViewController:(NYTPhotosViewController * _Nonnull)photosViewController actionCompletedWithActivityType:(NSString * _Nullable)activityType;
        [Export("photosViewController:actionCompletedWithActivityType:")]
        void ActionCompletedWithActivityType(NYTPhotosViewController photosViewController, [NullAllowed] string activityType);
    }

    // @interface NYTScalingImageView : UIScrollView
    [BaseType(typeof(UIScrollView))]
    interface NYTScalingImageView
    {
        // @property (readonly, nonatomic) UIImageView * _Nonnull imageView;
        [Export("imageView")]
        UIImageView ImageView { get; }

        // -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image frame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithImage:frame:")]
        [DesignatedInitializer]
        IntPtr Constructor(UIImage image, CGRect frame);

        // -(instancetype _Nonnull)initWithImageData:(NSData * _Nonnull)imageData frame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithImageData:frame:")]
        [DesignatedInitializer]
        IntPtr Constructor(NSData imageData, CGRect frame);

        // -(void)updateImage:(UIImage * _Nonnull)image;
        [Export("updateImage:")]
        void UpdateImage(UIImage image);

        // -(void)updateImageData:(NSData * _Nonnull)imageData;
        [Export("updateImageData:")]
        void UpdateImageData(NSData imageData);

        // -(void)centerScrollViewContents;
        [Export("centerScrollViewContents")]
        void CenterScrollViewContents();
    }
}
