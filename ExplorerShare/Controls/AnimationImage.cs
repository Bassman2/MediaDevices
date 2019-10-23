using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace ExplorerCtrl.Controls
{
    public class AnimationImage : Image
    {
        private bool isInitialized;
        private GifBitmapDecoder gifDecoder;
        private Int32Animation animation;

        static AnimationImage()
        {
            VisibilityProperty.OverrideMetadata(typeof(AnimationImage), new FrameworkPropertyMetadata(OnVisibilityPropertyChanged));
        }
        
        private static void OnVisibilityPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if ((Visibility)e.NewValue == Visibility.Visible)
            {
                ((AnimationImage)sender).StartAnimation();
            }
            else
            {
                ((AnimationImage)sender).StopAnimation();
            }
        }

        private static readonly DependencyProperty FrameIndexProperty =
            DependencyProperty.Register("FrameIndex", typeof(int), typeof(AnimationImage), new UIPropertyMetadata(0, new PropertyChangedCallback(OnFrameIndexChange)));

        private int FrameIndex
        {
            get { return (int)GetValue(FrameIndexProperty); }
            set { SetValue(FrameIndexProperty, value); }
        }

        private static void OnFrameIndexChange(DependencyObject obj, DependencyPropertyChangedEventArgs ev)
        {
            ((Image)obj).Source = ((AnimationImage)obj).gifDecoder.Frames[(int)ev.NewValue];
        }
        
        public new string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public new static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(string), typeof(AnimationImage), new UIPropertyMetadata(string.Empty, OnAnimationSourcePropertyChanged));

        private static void OnAnimationSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as AnimationImage).Initialize();
            (sender as AnimationImage).StartAnimation();
        }

        private void Initialize()
        {
            gifDecoder = new GifBitmapDecoder(new Uri("pack://application:,,," + this.Source), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            this.animation = new Int32Animation(0, this.gifDecoder.Frames.Count - 1, new Duration(new TimeSpan(0, 0, 0, this.gifDecoder.Frames.Count / 10, (int)((this.gifDecoder.Frames.Count / 10.0 - this.gifDecoder.Frames.Count / 10) * 1000))));
            this.animation.RepeatBehavior = RepeatBehavior.Forever;
            base.Source = gifDecoder.Frames[0];
            this.isInitialized = true;
        }

        /// <summary>
        /// Starts the animation
        /// </summary>
        public void StartAnimation()
        {
            if (!this.isInitialized)
            {
                this.Initialize();
            }

            BeginAnimation(FrameIndexProperty, animation);
        }

        /// <summary>
        /// Stops the animation
        /// </summary>
        public void StopAnimation()
        {
            BeginAnimation(FrameIndexProperty, null);
        }

    }
}
