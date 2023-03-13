using ItlaFlixApp.DAL.Context;

namespace ItlaFlixApp.DAL.Core
{
    public class ReposirotyBase<T>
    {
        private ItlaContext itlacontext;

        public ReposirotyBase(ItlaContext itlacontext)
        {
            this.itlacontext = itlacontext;
        }
    }
}