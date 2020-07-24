using System;
using System.Diagnostics;
using System.IO;
using AIMP.SDK;
using AIMP.SDK.MessageDispatcher;

namespace Aimp.Yandex.Music.Infrastructure
{
	/// <inheritdoc />
	public class AimpTraceListener : TraceListener
	{
		private StreamWriter _stream;

		/// <inheritdoc />
		public AimpTraceListener(IAimpCore core)
		{
			var dirAppData = Path.Combine(core.GetPath(AimpCorePathType.AIMP_CORE_PATH_PROFILE), YandexMusicPlugin.PluginFileName);
			Directory.CreateDirectory(dirAppData);
			var logFile = Path.Combine(dirAppData, YandexMusicPlugin.PluginFileName + ".log");
			_stream = new StreamWriter(logFile, false) { AutoFlush = true };
		}

		/// <inheritdoc />
		public override void Close()
		{
			base.Close();
			Utils.Dispose(ref _stream);
		}

		/// <inheritdoc />
		public override void Write(string message)
		{
			WriteLine(message);
		}

		/// <inheritdoc />
		public override void WriteLine(string message)
		{
			WriteLine(message, string.Empty);
		}

		/// <inheritdoc />
		public override void WriteLine(string message, string category)
		{
			_stream?.WriteLine("{0:yyyy-MM-dd HH:mm:ss} [{1,20}] {2}", DateTime.Now, category, message);
		}

		/// <inheritdoc />
		public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
		{
			WriteLine(message, eventType.ToString().ToUpperInvariant());
		}

		/// <inheritdoc />
		public override void Fail(string message)
		{
			WriteLine(message, nameof(TraceEventType.Critical).ToUpperInvariant());
		}
	}
}