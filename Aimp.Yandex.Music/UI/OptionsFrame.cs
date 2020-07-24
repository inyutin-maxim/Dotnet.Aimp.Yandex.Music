using System;
using System.Windows.Interop;
using AIMP.SDK.Options;
using AIMP.SDK.Player;

namespace Aimp.Yandex.Music.UI
{
	/// <summary>
	/// Фрейм для настроек
	/// </summary>
	public class OptionsFrame : IAimpOptionsDialogFrame, IAimpOptionsDialogFrameKeyboardHelper
	{
		private SettingsForm _settingsForm;

		private readonly IAimpPlayer _player;

		public OptionsFrame(IAimpPlayer player)
		{
			_player = player;
		}

		/// <inheritdoc />
		public string GetName()
		{
			return YandexMusicPlugin.PluginName;
		}

		/// <inheritdoc />
		public IntPtr CreateFrame(IntPtr parentWindow)
		{
			_settingsForm = new SettingsForm(parentWindow, _player, this);
			_settingsForm.Show();

			return new WindowInteropHelper(_settingsForm).Handle;
		}

		/// <inheritdoc />
		public void DestroyFrame()
		{
			_settingsForm.Hide();
			_settingsForm = null;
		}

		/// <inheritdoc />
		public void Notification(OptionsDialogFrameNotificationType id)
		{
		}

		/// <inheritdoc />
		public bool DialogKey(int charCode)
		{
			return true;
		}

		/// <inheritdoc />
		public bool SelectFirstControl()
		{
			return true;
		}

		/// <inheritdoc />
		public bool SelectNextControl(int findForward, int isTabKeyAction)
		{
			return true;
		}
	}
}