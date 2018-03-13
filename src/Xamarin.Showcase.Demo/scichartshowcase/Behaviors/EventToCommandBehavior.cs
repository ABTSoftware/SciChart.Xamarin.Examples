using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace scichartshowcase.Behaviors
{
	public class EventToCommandBehavior : BindableBehavior<View>
	{
		public static readonly BindableProperty EventNameProperty = BindableProperty.Create<EventToCommandBehavior, string>(p => p.EventName, null);
		public static readonly BindableProperty CommandProperty = BindableProperty.Create<EventToCommandBehavior, ICommand>(p => p.Command, null);
		public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create<EventToCommandBehavior, object>(p => p.CommandParameter, null);
		public static readonly BindableProperty EventArgsConverterProperty = BindableProperty.Create<EventToCommandBehavior, IValueConverter>(p => p.EventArgsConverter, null);
		public static readonly BindableProperty EventArgsConverterParameterProperty = BindableProperty.Create<EventToCommandBehavior, object>(p => p.EventArgsConverterParameter, null);

		private Delegate _handler;
		private EventInfo _eventInfo;

		public string EventName
		{
			get { return (string)GetValue(EventNameProperty); }
			set { SetValue(EventNameProperty, value); }
		}

		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}

		public object CommandParameter
		{
			get { return GetValue(CommandParameterProperty); }
			set { SetValue(CommandParameterProperty, value); }
		}

		public IValueConverter EventArgsConverter
		{
			get { return (IValueConverter)GetValue(EventArgsConverterProperty); }
			set { SetValue(EventArgsConverterProperty, value); }
		}

		public object EventArgsConverterParameter
		{
			get { return GetValue(EventArgsConverterParameterProperty); }
			set { SetValue(EventArgsConverterParameterProperty, value); }
		}

		protected override void OnAttachedTo(View visualElement)
		{
			base.OnAttachedTo(visualElement);

			var events = AssociatedObject.GetType().GetRuntimeEvents().ToArray();
			if (events.Any())
			{
				_eventInfo = events.FirstOrDefault(e => e.Name == EventName);
				if (_eventInfo == null)
					throw new ArgumentException(String.Format("EventToCommand: Can't find any event named '{0}' on attached type", EventName));

				AddEventHandler(_eventInfo, AssociatedObject, OnFired);
			}
		}

		protected override void OnDetachingFrom(View view)
		{
			if (_handler != null)
				_eventInfo.RemoveEventHandler(AssociatedObject, _handler);

			base.OnDetachingFrom(view);
		}

		private void AddEventHandler(EventInfo eventInfo, object item, Action<object, EventArgs> action)
		{
			var eventParameters = eventInfo.EventHandlerType
				.GetRuntimeMethods().First(m => m.Name == "Invoke")
				.GetParameters()
				.Select(p => Expression.Parameter(p.ParameterType))
				.ToArray();

			var actionInvoke = action.GetType()
				.GetRuntimeMethods().First(m => m.Name == "Invoke");

			_handler = Expression.Lambda(
				eventInfo.EventHandlerType,
				Expression.Call(Expression.Constant(action), actionInvoke, eventParameters[0], eventParameters[1]),
				eventParameters
			)
			.Compile();

			eventInfo.AddEventHandler(item, _handler);
		}

		private void OnFired(object sender, EventArgs eventArgs)
		{
			if (Command == null)
				return;

			var parameter = CommandParameter;

			if (eventArgs != null && eventArgs != EventArgs.Empty)
			{
				parameter = eventArgs;

				if (EventArgsConverter != null)
				{
					parameter = EventArgsConverter.Convert(eventArgs, typeof(object), EventArgsConverterParameter, CultureInfo.CurrentUICulture);
				}
			}

			if (Command.CanExecute(parameter))
			{
				Command.Execute(parameter);
			}
		}
	}

	public class BindableBehavior<T> : Behavior<T> where T : BindableObject
	{
		public T AssociatedObject { get; private set; }

		protected override void OnAttachedTo(T visualElement)
		{
			base.OnAttachedTo(visualElement);

			AssociatedObject = visualElement;

			if (visualElement.BindingContext != null)
				BindingContext = visualElement.BindingContext;

			visualElement.BindingContextChanged += OnBindingContextChanged;
		}

		private void OnBindingContextChanged(object sender, EventArgs e)
		{
			OnBindingContextChanged();
		}

		protected override void OnDetachingFrom(T view)
		{
			view.BindingContextChanged -= OnBindingContextChanged;
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			BindingContext = AssociatedObject.BindingContext;
		}
	}
}
