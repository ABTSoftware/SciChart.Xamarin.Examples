using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Xamarin.Examples.Demo.Droid.Components
{
    public class StepProgressBar : View
    {
        private readonly Paint _paint = new Paint();

        private float _barSize;
        private float _spacing;
        private bool _isVertical;
        private int _max;
        private Color _progressBackgroundColor;
        private Color _progressColor;
        private int _progress;

        public StepProgressBar(Context context) : base(context)
        {
            _paint.SetStyle(Paint.Style.Fill);
        }

        public StepProgressBar(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init(context, attrs, 0, 0);
        }

        public StepProgressBar(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init(context, attrs, defStyleAttr, 0);
        }

        public StepProgressBar(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Init(context, attrs, defStyleAttr, defStyleRes);
        }

        private void Init(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
        {
            _paint.SetStyle(Paint.Style.Fill);

            var typedArray = context.Theme.ObtainStyledAttributes(attrs, Resource.Styleable.StepProgressBar, defStyleAttr, defStyleRes);
            try
            {
                ProgressColor = typedArray.GetColor(Resource.Styleable.StepProgressBar_progressColor, Color.Green.ToArgb());
                ProgressBackgroundColor = typedArray.GetColor(Resource.Styleable.StepProgressBar_progressBackgroundColor, Color.Transparent.ToArgb());
                Progress = typedArray.GetInt(Resource.Styleable.StepProgressBar_progress, 0);
                Max = typedArray.GetInt(Resource.Styleable.StepProgressBar_max, 0);
                IsVertical = typedArray.GetBoolean(Resource.Styleable.StepProgressBar_isVertical, false);
                Spacing = typedArray.GetDimension(Resource.Styleable.StepProgressBar_spacing, 1f);
                BarSize = typedArray.GetDimension(Resource.Styleable.StepProgressBar_barSize, 10f);
            }
            finally
            {
                typedArray.Recycle();
            }
        }

        public float BarSize
        {
            get => _barSize;
            set
            {
                _barSize = value; 
                RequestLayout();
                Invalidate();
            }
        }

        public float Spacing
        {
            get => _spacing;
            set
            {
                _spacing = value;
                RequestLayout();
                Invalidate();
            }
        }

        public bool IsVertical
        {
            get => _isVertical;
            set
            {
                _isVertical = value;
                RequestLayout();
                Invalidate();
            }
        }

        public int Max
        {
            get => _max;
            set
            {
                _max = value;
                RequestLayout();
                Invalidate();
            }
        }

        public Color ProgressBackgroundColor
        {
            get => _progressBackgroundColor;
            set
            {
                _progressBackgroundColor = value; 
                Invalidate();
            }
        }

        public Color ProgressColor
        {
            get => _progressColor;
            set
            {
                _progressColor = value; 
                Invalidate();
            }
        }

        public int Progress
        {
            get => _progress;
            set
            {
                _progress = value; 
                Invalidate();
            }
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            var requiredSize = (int) (Max * BarSize + Spacing * (Max - 1));

            int width, height;
            if (IsVertical)
            {
                width = View.ResolveSizeAndState(SuggestedMinimumWidth, widthMeasureSpec, 0);
                height = requiredSize;
            }
            else
            {
                width = requiredSize;
                height = View.ResolveSizeAndState(SuggestedMinimumHeight, heightMeasureSpec, 0);
            }

            SetMeasuredDimension(width, height);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            if(canvas == null) return;

            var barSize = BarSize;
            var step = barSize + Spacing;

            var progress = Progress;
            var maxMinusProgress = Max - progress;

            if (IsVertical)
            {
                var width = Width;
                
                float position = Height;

                _paint.Color = ProgressColor;
                for (int i = 0; i < progress; i++)
                {
                    canvas.DrawRect(0, position - barSize, width, position, _paint);

                    position -= step;
                }

                _paint.Color = ProgressBackgroundColor;
                for (int i = 0; i < maxMinusProgress; i++)
                {
                    canvas.DrawRect(0, position - barSize, width, position, _paint);

                    position -= step;
                }
            }
            else
            {
                var height = Height;

                var position = 0f;

                _paint.Color = ProgressColor;
                for (int i = 0; i < progress; i++)
                {
                    canvas.DrawRect(position, 0f, position + barSize, height, _paint);

                    position += step;
                }

                _paint.Color = ProgressBackgroundColor;
                for (int i = 0; i < maxMinusProgress; i++)
                {
                    canvas.DrawRect(position, 0f, position + barSize, height, _paint);

                    position += step;
                }
            }
        }
    }
}