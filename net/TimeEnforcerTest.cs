using NUnit.Framework;
using System;
using System.Diagnostics;

namespace edymtt
{
[TestFixture()]
public class MinimumTimeEnforcerTest
{
	[Test()]
	public void TestTimespanZeroWithSuccess()
	{
		TimeSpan minimumTime = TimeSpan.Zero;

		Assert.IsTrue(TimeSpan.FromSeconds(2) <= MeasureElapsed(() =>
		{
			using (var enforcer = new MinimumTimeEnforcer(minimumTime)) {
				System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
				enforcer.Complete(true);
			}
		}), "Elapsed less that 2 seconds");
	}


	private TimeSpan MeasureElapsed(Action action)
	{
		var sw = Stopwatch.StartNew();

		action();

		sw.Stop();
		Debug.WriteLine(sw.Elapsed);
		//La precisione (massima) dello stopwatch è maggiore della precisione
		//di thread.sleep, quindi il test può fallire perché vengono misurati 1.9999999 secondi
		//al posto di 2.
		//Per ovviare a questa approssimazione tollerabile, ottengo i millesecondi e ci aggiungo 1
		return TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds );
	}

	
}
}