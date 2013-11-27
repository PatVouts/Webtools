using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RefplusWebtools
{
    public partial class LoadingCircle : Control
    {
        // Constants =========================================================
        private const double NumberOfDegreesInCircle = 360;
        private const double NumberOfDegreesInHalfCircle = NumberOfDegreesInCircle / 2;
        private const int DefaultInnerCircleRadius = 8;
        private const int DefaultOuterCircleRadius = 10;
        private const int DefaultNumberOfSpoke = 10;
        private const int DefaultSpokeThickness = 4;
        private readonly Color _defaultColor = Color.DarkGray;

        private const int MacOSXInnerCircleRadius = 5;
        private const int MacOSXOuterCircleRadius = 11;
        private const int MacOSXNumberOfSpoke = 12;
        private const int MacOSXSpokeThickness = 2;

        private const int FireFoxInnerCircleRadius = 6;
        private const int FireFoxOuterCircleRadius = 7;
        private const int FireFoxNumberOfSpoke = 9;
        private const int FireFoxSpokeThickness = 4;

        private const int IE7InnerCircleRadius = 8;
        private const int IE7OuterCircleRadius = 9;
        private const int IE7NumberOfSpoke = 24;
        private const int IE7SpokeThickness = 4;

        // Enumeration =======================================================
        public enum StylePresets
        {
            MacOSX,
            Firefox,
            IE7,
            Custom
        }

        // Attributes ========================================================
        private readonly Timer _mTimer;
        private bool _mIsTimerActive;
        private int _mNumberOfSpoke;
        private int _mSpokeThickness;
        private int _mProgressValue;
        private int _mOuterCircleRadius;
        private int _mInnerCircleRadius;
        private PointF _mCenterPoint;
        private Color _mColor;
        private Color[] _mColors;
        private double[] _mAngles;
        private StylePresets _mStylePreset;

        // Properties ========================================================
        /// <summary>
        /// Gets or sets the lightest color of the circle.
        /// </summary>
        /// <value>The lightest color of the circle.</value>
        [TypeConverter("System.Drawing.ColorConverter"),
         Category("LoadingCircle"),
         Description("Sets the color of spoke.")]
        public Color Color
        {
            get
            {
                return _mColor;
            }
            set
            {
                _mColor = value;

                GenerateColorsPallet();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the outer circle radius.
        /// </summary>
        /// <value>The outer circle radius.</value>
        [Description("Gets or sets the radius of outer circle."),
         Category("LoadingCircle")]
        public int OuterCircleRadius
        {
            get
            {
                if (_mOuterCircleRadius == 0)
                    _mOuterCircleRadius = DefaultOuterCircleRadius;

                return _mOuterCircleRadius;
            }
            set
            {
                _mOuterCircleRadius = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the inner circle radius.
        /// </summary>
        /// <value>The inner circle radius.</value>
        [Description("Gets or sets the radius of inner circle."),
         Category("LoadingCircle")]
        public int InnerCircleRadius
        {
            get
            {
                if (_mInnerCircleRadius == 0)
                    _mInnerCircleRadius = DefaultInnerCircleRadius;

                return _mInnerCircleRadius;
            }
            set
            {
                _mInnerCircleRadius = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the number of spoke.
        /// </summary>
        /// <value>The number of spoke.</value>
        [Description("Gets or sets the number of spoke."),
        Category("LoadingCircle")]
        public int NumberSpoke
        {
            get
            {
                if (_mNumberOfSpoke == 0)
                    _mNumberOfSpoke = DefaultNumberOfSpoke;

                return _mNumberOfSpoke;
            }
            set
            {
                if (_mNumberOfSpoke != value && _mNumberOfSpoke > 0)
                {
                    _mNumberOfSpoke = value;
                    GenerateColorsPallet();
                    GetSpokesAngles();

                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see>
        ///     <cref>T:LoadingCircle</cref>
        /// </see>
        ///     is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        [Description("Gets or sets the number of spoke."),
        Category("LoadingCircle")]
        public bool Active
        {
            get
            {
                return _mIsTimerActive;
            }
            set
            {
                _mIsTimerActive = value;
                ActiveTimer();
            }
        }

        /// <summary>
        /// Gets or sets the spoke thickness.
        /// </summary>
        /// <value>The spoke thickness.</value>
        [Description("Gets or sets the thickness of a spoke."),
        Category("LoadingCircle")]
        public int SpokeThickness
        {
            get
            {
                if (_mSpokeThickness <= 0)
                    _mSpokeThickness = DefaultSpokeThickness;

                return _mSpokeThickness;
            }
            set
            {
                _mSpokeThickness = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the rotation speed.
        /// </summary>
        /// <value>The rotation speed.</value>
        [Description("Gets or sets the rotation speed. Higher the slower."),
        Category("LoadingCircle")]
        public int RotationSpeed
        {
            get
            {
                return _mTimer.Interval;
            }
            set
            {
                if (value > 0)
                    _mTimer.Interval = value;
            }
        }

        /// <summary>
        /// Quickly sets the style to one of these presets, or a custom style if desired
        /// </summary>
        /// <value>The style preset.</value>
        [Category("LoadingCircle"),
         Description("Quickly sets the style to one of these presets, or a custom style if desired"),
         DefaultValue(typeof(StylePresets), "Custom")]
        public StylePresets StylePreset
        {
            get { return _mStylePreset; }
            set
            {
                _mStylePreset = value;

                switch (_mStylePreset)
                {
                    case StylePresets.MacOSX:
                        SetCircleAppearance(MacOSXNumberOfSpoke,
                            MacOSXSpokeThickness, MacOSXInnerCircleRadius,
                            MacOSXOuterCircleRadius);
                        break;
                    case StylePresets.Firefox:
                        SetCircleAppearance(FireFoxNumberOfSpoke,
                            FireFoxSpokeThickness, FireFoxInnerCircleRadius,
                            FireFoxOuterCircleRadius);
                        break;
                    case StylePresets.IE7:
                        SetCircleAppearance(IE7NumberOfSpoke,
                            IE7SpokeThickness, IE7InnerCircleRadius,
                            IE7OuterCircleRadius);
                        break;
                    case StylePresets.Custom:
                        SetCircleAppearance(DefaultNumberOfSpoke,
                            DefaultSpokeThickness,
                            DefaultInnerCircleRadius,
                            DefaultOuterCircleRadius);
                        break;
                }
            }
        }

        // Construtor ========================================================
        /// <summary>
        /// Initializes a new instance of the <see>
        ///     <cref>T:LoadingCircle</cref>
        /// </see>
        ///     class.
        /// </summary>
        public LoadingCircle()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            _mColor = _defaultColor;

            GenerateColorsPallet();
            GetSpokesAngles();
            GetControlCenterPoint();

            _mTimer = new Timer();
            _mTimer.Tick += aTimer_Tick;
            ActiveTimer();

            Resize += LoadingCircle_Resize;
        }

        // Events ============================================================
        /// <summary>
        /// Handles the Resize event of the LoadingCircle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        void LoadingCircle_Resize(object sender, EventArgs e)
        {
            GetControlCenterPoint();
        }

        /// <summary>
        /// Handles the Tick event of the aTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        void aTimer_Tick(object sender, EventArgs e)
        {
            _mProgressValue = ++_mProgressValue % _mNumberOfSpoke;
            Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_mNumberOfSpoke > 0)
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                int intPosition = _mProgressValue;
                for (int intCounter = 0; intCounter < _mNumberOfSpoke; intCounter++)
                {
                    intPosition = intPosition % _mNumberOfSpoke;
                    DrawLine(e.Graphics,
                             GetCoordinate(_mCenterPoint, _mInnerCircleRadius, _mAngles[intPosition]),
                             GetCoordinate(_mCenterPoint, _mOuterCircleRadius, _mAngles[intPosition]),
                             _mColors[intCounter], _mSpokeThickness);
                    ++intPosition;
                }
            }

            base.OnPaint(e);
        }

        // Overridden Methods ================================================
        /// <summary>
        /// Retrieves the size of a rectangular area into which a control can be fitted.
        /// </summary>
        /// <param name="proposedSize">The custom-sized area for a control.</param>
        /// <returns>
        /// An ordered pair of type <see cref="T:System.Drawing.Size"></see> representing the width and height of a rectangle.
        /// </returns>
        public override Size GetPreferredSize(Size proposedSize)
        {
            proposedSize.Width =
                (_mOuterCircleRadius + _mSpokeThickness) * 2;

            return proposedSize;
        }

        // Methods ===========================================================
        /// <summary>
        /// Darkens a specified color.
        /// </summary>
        /// <param name="objColor">Color to darken.</param>
        /// <param name="intPercent">The percent of darken.</param>
        /// <returns>The new color generated.</returns>
        private Color Darken(Color objColor, int intPercent)
        {
            int intRed = objColor.R;
            int intGreen = objColor.G;
            int intBlue = objColor.B;
            return Color.FromArgb(intPercent, Math.Min(intRed, byte.MaxValue), Math.Min(intGreen, byte.MaxValue), Math.Min(intBlue, byte.MaxValue));
        }

        /// <summary>
        /// Generates the colors pallet.
        /// </summary>
        private void GenerateColorsPallet()
        {
            _mColors = GenerateColorsPallet(_mColor, Active, _mNumberOfSpoke);
        }

        /// <summary>
        /// Generates the colors pallet.
        /// </summary>
        /// <param name="objColor">Color of the lightest spoke.</param>
        /// <param name="blnShadeColor">if set to <c>true</c> the color will be shaded on X spoke.</param>
        /// <param name="intNbSpoke"></param>
        /// <returns>An array of color used to draw the circle.</returns>
        private Color[] GenerateColorsPallet(Color objColor, bool blnShadeColor, int intNbSpoke)
        {
            var objColors = new Color[NumberSpoke];

            // Value is used to simulate a gradient feel... For each spoke, the 
            // color will be darken by value in intIncrement.
            var bytIncrement = (byte)(byte.MaxValue / NumberSpoke);

            //Reset variable in case of multiple passes
            byte percentageOfDarken = 0;

            for (int intCursor = 0; intCursor < NumberSpoke; intCursor++)
            {
                if (blnShadeColor)
                {
                    if (intCursor == 0 || intCursor < NumberSpoke - intNbSpoke)
                        objColors[intCursor] = objColor;
                    else
                    {
                        // Increment alpha channel color
                        percentageOfDarken += bytIncrement;

                        // Ensure that we don't exceed the maximum alpha
                        // channel value (255)
                        if (percentageOfDarken > byte.MaxValue)
                            percentageOfDarken = byte.MaxValue;

                        // Determine the spoke forecolor
                        objColors[intCursor] = Darken(objColor, percentageOfDarken);
                    }
                }
                else
                    objColors[intCursor] = objColor;
            }

            return objColors;
        }

        /// <summary>
        /// Gets the control center point.
        /// </summary>
        private void GetControlCenterPoint()
        {
            _mCenterPoint = GetControlCenterPoint(this);
        }

        /// <summary>
        /// Gets the control center point.
        /// </summary>
        /// <returns>PointF object</returns>
        private PointF GetControlCenterPoint(Control objControl)
        {
// ReSharper disable once PossibleLossOfFraction
            return new PointF(objControl.Width / 2, objControl.Height / 2 - 1);
        }

        /// <summary>
        /// Draws the line with GDI+.
        /// </summary>
        /// <param name="objGraphics">The Graphics object.</param>
        /// <param name="objPointOne">The point one.</param>
        /// <param name="objPointTwo">The point two.</param>
        /// <param name="objColor">Color of the spoke.</param>
        /// <param name="intLineThickness">The thickness of spoke.</param>
        private void DrawLine(Graphics objGraphics, PointF objPointOne, PointF objPointTwo,
                              Color objColor, int intLineThickness)
        {
            using (var objPen = new Pen(new SolidBrush(objColor), intLineThickness))
            {
                objPen.StartCap = LineCap.Round;
                objPen.EndCap = LineCap.Round;
                objGraphics.DrawLine(objPen, objPointOne, objPointTwo);
            }
        }

        /// <summary>
        /// Gets the coordinate.
        /// </summary>
        /// <param name="objCircleCenter">The Circle center.</param>
        /// <param name="intRadius">The radius.</param>
        /// <param name="dblAngle"></param>
        /// <returns></returns>
        private PointF GetCoordinate(PointF objCircleCenter, int intRadius, double dblAngle)
        {
            double dblAngleCalc = Math.PI * dblAngle / NumberOfDegreesInHalfCircle;

            return new PointF(objCircleCenter.X + intRadius * (float)Math.Cos(dblAngleCalc),
                              objCircleCenter.Y + intRadius * (float)Math.Sin(dblAngleCalc));
        }

        /// <summary>
        /// Gets the spokes angles.
        /// </summary>
        private void GetSpokesAngles()
        {
            _mAngles = GetSpokesAngles(NumberSpoke);
        }

        /// <summary>
        /// Gets the spoke angles.
        /// </summary>
        /// <param name="intNumberSpoke"></param>
        /// <returns>An array of angle.</returns>
        private double[] GetSpokesAngles(int intNumberSpoke)
        {
            var angles = new double[intNumberSpoke];
            double dblAngle = NumberOfDegreesInCircle / intNumberSpoke;

            for (int shtCounter = 0; shtCounter < intNumberSpoke; shtCounter++)
                angles[shtCounter] = (shtCounter == 0 ? dblAngle : angles[shtCounter - 1] + dblAngle);

            return angles;
        }

        /// <summary>
        /// Actives the timer.
        /// </summary>
        private void ActiveTimer()
        {
            if (_mIsTimerActive)
                _mTimer.Start();
            else
            {
                _mTimer.Stop();
                _mProgressValue = 0;
            }

            GenerateColorsPallet();
            Invalidate();
        }

        /// <summary>
        /// Sets the circle appearance.
        /// </summary>
        /// <param name="numberSpoke">The number spoke.</param>
        /// <param name="spokeThickness">The spoke thickness.</param>
        /// <param name="innerCircleRadius">The inner circle radius.</param>
        /// <param name="outerCircleRadius">The outer circle radius.</param>
        public void SetCircleAppearance(int numberSpoke, int spokeThickness,
            int innerCircleRadius, int outerCircleRadius)
        {
            NumberSpoke = numberSpoke;
            SpokeThickness = spokeThickness;
            InnerCircleRadius = innerCircleRadius;
            OuterCircleRadius = outerCircleRadius;

            Invalidate();
        }
    }
}
