stopwatch
=========

This sample attemps unsuccessfully to reproduce a time measurament bug I've encountered during development: that is, that `System.Threading.Thread.Sleep` could sleep for less that the time passed (for example, 1.999 seconds instead of 2 seconds).

I cannot reproduce this issue with an Intel Core 2 Duo (maybe because it's too slow?).