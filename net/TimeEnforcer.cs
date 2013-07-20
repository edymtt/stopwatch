using System;
using System.Diagnostics;

namespace edymtt
{
  public class MinimumTimeEnforcer : IDisposable
{




	private TimeSpan _minimumTime;

	private Stopwatch _stopWatch;

	private bool _completeCalled = false;

	private bool _succeeded = false;



	public MinimumTimeEnforcer(TimeSpan minimumTime)
	{
		_minimumTime = minimumTime;

		_stopWatch = Stopwatch.StartNew();

	}




	public void Complete(bool operationSucceeded)
	{
		_completeCalled = true;

		_succeeded = operationSucceeded;

	}




	private void _Wait()
	{

		if (!_completeCalled || !_succeeded) {
			_stopWatch.Stop();



			TimeSpan elapsedTime = default(TimeSpan);

			elapsedTime = _stopWatch.Elapsed;




			if (elapsedTime < _minimumTime) {
				System.Threading.Thread.Sleep(_minimumTime.Subtract(elapsedTime));

			}

		}

	}



	#region "IDisposable Support"


	public void Dispose()
	{
		_Wait();

	}

	#endregion



}
}