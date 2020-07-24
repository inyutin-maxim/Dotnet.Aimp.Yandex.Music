using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using AIMP.SDK.Options;
using AIMP.SDK.Player;
using Aimp.Yandex.Music.Core;

namespace Aimp.Yandex.Music.UI
{
	public partial class SettingsForm : Window
	{
		private IAimpOptionsDialogFrame _parentFrame;

		private IAimpPlayer _player;


		public SettingsForm(IntPtr parentWindow, IAimpPlayer player, IAimpOptionsDialogFrame parentFrame)
			: this()
		{
			SetParent(new WindowInteropHelper(this).Handle, parentWindow);
			_parentFrame = parentFrame;
			_player = player;
			Show();
			WindowState = WindowState.Maximized;
		}

		public SettingsForm()
		{
			InitializeComponent();
		}

		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		private void YandexAuthorize(object sender, RoutedEventArgs e)
		{
			AimpYandexMusicApi.Instance.Authorize(Login.Text, Password.Password);
		}
	}
}