using System;
using eCommercePro.Models.Interface;
using eCommercePro.Models.Method;
using Unity;
using eCommercePro.Method;

namespace eCommercePro
{    
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });
       
        public static IUnityContainer Container => container.Value;
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {         
            container.RegisterType<I_Helper, Helper>();
			container.RegisterType<I_Products, Products>();
		}
    }
}