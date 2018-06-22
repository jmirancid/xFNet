using Microsoft.Practices.Unity.Configuration;
using System;
using System.Configuration;
using System.Text;
using Unity;

namespace xFNet.Repositories
{
    public class Factory
    {
        private static Lazy<UnityContainer> uContainer =
            new Lazy<UnityContainer>(() =>
            {
                return ConfigureContainer();
            });

        public static I Resolve<I>()
        {
            try
            {
                return uContainer.Value.Resolve<I>();
            }
            catch (Exception ex)
            {
                StringBuilder detail = new StringBuilder();
                detail.AppendLine(string.Format("Error al resolver el repositorio para la interfaz {0}. Verifique lo siguiente:", typeof(I).Name));
                detail.AppendLine("- Existencia del archivo de unity 'unity.repositories.config'.");
                detail.AppendLine(string.Format("- Existencia de la entrada correspondiente a la interfaz {0} en dicho archivo.", typeof(I).Name));
                detail.AppendLine("- Existencia del archivo binario de repositorio correspondiente 'MyProject.Repositories'.");

                throw new Exception(detail.ToString(), ex);
            }
        }

        private static UnityContainer ConfigureContainer()
        {
            var instance = new UnityContainer();

            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(instance);

            return instance;
        }
    }
}
