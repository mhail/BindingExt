using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using System.Reflection;

namespace BindingExt
{
	[ContentProperty ("Key")]
	public class BindingRefExtension : IMarkupExtension
	{
		public string Key {
			get;
			set;
		}

		Binding GetBindingFromRootObjectField (object rootObject)
		{
			var field = rootObject.GetType ().GetRuntimeField (Key);
			if (null != field) {
				return field.GetValue (rootObject) as Binding;
			}
			return null;
		}

		#region IMarkupExtension implementation

		public object ProvideValue (IServiceProvider serviceProvider)
		{
			var provider = serviceProvider.GetService (typeof(IRootObjectProvider)) as IRootObjectProvider;
			if (null == provider)
				throw new InvalidOperationException ("IRootObjectProvider");

			var binding = GetBindingFromRootObjectField (provider.RootObject);

			if (null != binding) {
				// The binding needs to be cloned or it will throw  an Instance Cannot Be Reused Exception
				return new Binding (binding.Path, binding.Mode, binding.Converter, binding.ConverterParameter, binding.StringFormat, binding.Source);
			}

			throw new InvalidOperationException (string.Format("Binding field '{0}' not found on object {1}", Key, provider.RootObject.GetType().Name));

		}

		#endregion
	}
}

