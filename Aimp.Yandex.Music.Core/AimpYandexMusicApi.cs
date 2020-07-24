using Yandex.Music.Api;

namespace Aimp.Yandex.Music.Core
{
	public static class AimpYandexMusicApi
	{
		private static readonly object padlock = new object();

		private static YandexMusicApi instance;

		public static YandexMusicApi Instance
		{
			get
			{
				lock (padlock)
				{
					return instance ??= new YandexMusicApi();
				}
			}
		}
	}
}