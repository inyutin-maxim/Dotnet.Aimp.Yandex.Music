using System.Diagnostics;
using AIMP.SDK;
using Aimp.Yandex.Music.Infrastructure;
using Aimp.Yandex.Music.UI;
using JetBrains.Annotations;

namespace Aimp.Yandex.Music
{
	/// <inheritdoc />
	[AimpPlugin(PluginName,
		PluginAuthor,
		PluginVersion,
		AimpPluginType = AimpPluginType.Addons,
		Description = PluginDescription)]
	[UsedImplicitly]
	public class YandexMusicPlugin : AimpPlugin
	{
		public const string PluginName = "Aimp.Yandex.Music";

		private const string PluginVersion = "1.0.0";

		private const string PluginDescription = "Поддержка сервиса Yandex.Music";

		private const string PluginAuthor = "inyutin-maxim";

		public const string PluginFileName = "aimp_yandex_music";

		/// <inheritdoc />
		public override void Initialize()
		{
			Trace.Listeners.Clear();
			Trace.Listeners.Add(new AimpTraceListener(Player.Core));
			var optionsForm = new OptionsFrame(Player);
			Player.Core.RegisterExtension(optionsForm);
		}

		/// <inheritdoc />
		public override void Dispose()
		{
		}
	}
}