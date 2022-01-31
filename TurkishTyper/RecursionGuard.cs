using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkishTyper
{
    interface IScope : IDisposable
    {
        bool IsValid { get; }
    }

    class RecursionException : InvalidOperationException
    {

    }

    class RecursionGuard
    {
        class RecursionScope : IScope
        {
            private RecursionGuard m_Guard;

            public RecursionScope(RecursionGuard guard, bool valid)
            {
                m_Guard = guard;
                IsValid = valid;
            }

            public bool IsValid { get; private set; }

            #region IDisposable Support
            
            private void Dispose(bool disposing)
            {
                if (IsValid)
                {
                    m_Guard.ReleaseScope();
                    IsValid = false;
                }

                if(disposing)
                    GC.SuppressFinalize(this);
            }

            public void Dispose()
            {
                Dispose(true);
            }

            ~RecursionScope()
            {
                Dispose(false);
            }
            #endregion

        }

        private bool m_InScope = false;
        private readonly bool m_Throwing;

        public RecursionGuard(bool throwing = true)
        {
            m_Throwing = throwing;
        }

        public IScope Scope
        {
            get
            {
                if(m_InScope)
                {
                    if (m_Throwing)
                        throw new RecursionException();
                    return new RecursionScope(this, false);
                }
                else
                {
                    m_InScope = true;
                    return new RecursionScope(this, true);
                }
            }

        }

        private void ReleaseScope()
        {
            m_InScope = false;
        }


    }
}
