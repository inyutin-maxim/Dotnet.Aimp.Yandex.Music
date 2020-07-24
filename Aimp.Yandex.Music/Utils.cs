using System;
using System.Diagnostics;

namespace Aimp.Yandex.Music
{
	/// <summary>
	/// Методы расширения для работы с кодом
	/// </summary>
	public static class Utils
	{
		/// <summary>
		/// Попробовать выполнить действие
		/// </summary>
		/// <param name="action">Действие</param>
		/// <returns>
		/// <c>true</c> - если действие выполнено успешно, иначе <c>false</c>
		/// </returns>
		public static bool TryCatch(Action action)
		{
			try
			{
				action();

				return true;
			}
			catch (Exception ex)
			{
				HandleException(ex);

				return false;
			}
		}

		/// <summary>
		/// Попробовать выполнить функцию
		/// </summary>
		/// <param name="func">Функция</param>
		/// <param name="value">Параметр функции</param>
		/// <param name="result">Результат выполнения функции</param>
		/// <typeparam name="T">Тип входного параметра функции</typeparam>
		/// <typeparam name="TResult">Тип результата функции</typeparam>
		/// <returns>
		/// <c>true</c> - если функция выполнена успешно, иначе <c>false</c>
		/// </returns>
		public static bool TryCatch<T, TResult>(Func<T, TResult> func, T value, out TResult result)
		{
			try
			{
				result = func(value);

				return true;
			}
			catch (Exception ex)
			{
				HandleException(ex);
				result = default;

				return false;
			}
		}

		/// <summary>
		/// Обработка исключения
		/// </summary>
		/// <param name="ex">Исключение</param>
		private static void HandleException(Exception ex)
		{
			Trace.Fail(ex.ToString());
		}

		/// <summary>
		/// Выгрузить объекты из памяти
		/// </summary>
		/// <param name="obj">Объект памяти</param>
		/// <typeparam name="T">Тип объекта</typeparam>
		public static void Dispose<T>(ref T obj)
			where T : class, IDisposable
		{
			obj?.Dispose();
			obj = null;
		}
	}
}