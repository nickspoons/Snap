﻿/*
Snap v1.0
Copyright (c) 2010 Tyler Brinks
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
using Castle.DynamicProxy;

namespace Snap
{
    /// <summary>
    /// A class for fooling the ProxyGenerator that there are a given number of interceptors
    /// when there's really only one master proxy class.  The generated Castle instance checks for
    /// calls to "Invocation.Proceed" a specific number of times - one per interceptor.
    ///
    /// The Proxy does a few additional steps before and after each interceptor is
    /// invoked, so an empty placeholder is necessary in order to augment the
    /// "Invocation.Proceed" count.
    /// </summary>
    public class PseudoInterceptor : IInterceptor
    {
        public PseudoInterceptor()
        {
            ShouldProceed = false;
        }

        public void Intercept(IInvocation invocation)
        {
            if (ShouldProceed)
            {
                invocation.Proceed();
            }
            else
            {
                ShouldProceed = true;
            }
        }

        public bool ShouldProceed { get; set; }
    }
}