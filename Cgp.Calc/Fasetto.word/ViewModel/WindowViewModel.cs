
using System;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.word
{
    class WindowViewModel: BaseViewModel
    {
        #region Private Members
        /// <summary>
        /// The window this viewModel controls 
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// A region of space around the Window we can drop Shadow
        /// </summary>
        private int mOuterMaginSize { get; set; } = 10;

        /// <summary>
        /// The radius of the edges of the windows
        /// </summary>
        private int mWindowRadius { get; set; } = 6;
        #endregion

        /// <summary>
        /// Default Constructors
        /// </summary>
        /// <param name="window"></param>
        #region Constructor
        public WindowViewModel(Window window)
        {
            mWindow = window;

            //Listn out for windows reszing
            mWindow.StateChanged += (sender, e) =>
            {
                //Fires off all the properties affected by the resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            //Create Commands
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            //Fix Window Resize issue
            var resizer = new WindowResizer(mWindow);


        }

        private Point GetMousePosition()
        {
            //Position of the mouse relative to the window
            var position = Mouse.GetPosition(mWindow);

            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }
        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to show the system menu of the window
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion
        #region Public Properties

        /// <summary>
        /// The Smallest height the window can get
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 400;

        /// <summary>
        /// The Smallest Width the window can get
        /// </summary>

        public double WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        /// The size of resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        public Thickness InnerContentPadding { get { return new Thickness(ResizeBorder ); } }


        /// <summary>
        /// A region of space around the Window we can drop Shadow
        /// Value is Null if Window is Maximized for the window to maximize properly
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMaginSize;
            }
            set
            {
                mOuterMaginSize = value;
            }
        }

        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// The radius of the edges of the windows
        /// Value is Null if Window is Maximized for the window to maximize properly
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }

        /// <summary>
        /// The title bar that acommodates the icons, Caption and the buttons
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight); } }


        /// <summary>
        /// The radius of the edges of the windows
        /// Value is Null if Window is Maximized for the window to maximize properly
        /// </summary>
        public CornerRadius WindowCornerRadius { get {return new CornerRadius(WindowRadius); } }

        #endregion
    }
}
