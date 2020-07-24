using AIMP.SDK;
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
		private const string PluginName = "Aimp.Yandex.Music";

		private const string PluginVersion = "1.0.0";

		private const string PluginDescription = "Поддержка сервиса Yandex.Music";

		private const string PluginAuthor = "inyutin-maxim";

		/// <inheritdoc />
		public override void Initialize()
		{
		}

		/// <inheritdoc />
		public override void Dispose()
		{
		}
	}
}