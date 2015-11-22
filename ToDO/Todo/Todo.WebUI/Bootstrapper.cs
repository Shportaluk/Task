using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using FakeRepository;
using SqlRepository;
using Todo.WebUI.Code.Managers;

namespace Todo.WebUI
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();
      //string con_str = "Data Source=.\\SQLExpress;Initial Catalog=master;Integrated Security=True";
      string con_str = "Server=10.7.1.10;Database=SAP_TASK_TODO;User Id=sa;Password=123456;";
      // register all your components with the container here
      // it is NOT necessary to register your controllers

      SqlUserRepository _SqlUserRepository = new SqlUserRepository();

      container.RegisterType<ITaskRepository, SqlTaskRepository>( new InjectionConstructor( con_str ) );
      container.RegisterType<ISecurityManager, FormsSecurityManager>(new InjectionConstructor( _SqlUserRepository ));
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}