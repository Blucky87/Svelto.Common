using System.Threading;
using UnityEngine;

namespace Svelto.Utilities
{
    public static class ThreadUtility
    {
        public static void MemoryBarrier()
        {
#if NETFX_CORE || NET_4_6
            Interlocked.MemoryBarrier();
#else
            Thread.MemoryBarrier();
#endif
        }

        public static void Yield()
        {
#if NETFX_CORE            
            Task.Yield();
#elif NET_4_6
            Thread.Yield(); 
#else
            Thread.Sleep(0);
            #endif    
        }
        
        public static void SleepZero()
        {
#if NETFX_CORE            
            Task.Yield();
#elif NET_4_6
            Thread.Sleep(0); 
#else
            Thread.Sleep(0);
            #endif    
        }
    }
#if NETFX_CORE || NET_4_6
    public sealed class ManualResetEventEx : ManualResetEventSlim
    {
        public new void Wait()
        {
            base.Wait();
        }

        public new void Reset()
        {
            base.Reset();
        }

        public new void Set()
        {
            base.Set();
        }

        public new void Dispose()
        {
            base.Dispose();
        }
    }
#else
    public class ManualResetEventEx : ManualResetEvent
    {
        
    }
#endif
}